using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCode.ProductActions;

public class Product
{
    public string ConnectionString { get; set; } = "Host = ::1;Port=5432;Database=CategoryProduct; User Id=postgres; password=behruz22";
    public void ProductAdd(int id,string productName)
    {
        if (productName != null)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("CREATE TABLE IF NOT EXISTS Product (id SERIAL PRIMARY KEY,name VARCHAR,category_id integer,FOREIGN KEY (category_id) REFERENCES Category(id))", connection))
                {
                    command.ExecuteNonQuery();
                }

                using (NpgsqlCommand command = new NpgsqlCommand($"INSERT INTO Product (name,category_id) VALUES ('{productName}',{id})", connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Product added!");
                }
                connection.Close();
            }
        }


        else
            Console.WriteLine("Noto'g'ri ma'lumot kiritildi!");
    }

    public void ProductDelete(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        {
            connection.Open();

            using (NpgsqlCommand command = new NpgsqlCommand($"DELETE FROM Product WHERE id={id}", connection))
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Product deleted!");
            }
            connection.Close();

        }
    }

    public void ProductUpdate(int id, string Name)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        {
            connection.Open();

            using (NpgsqlCommand command = new NpgsqlCommand($"Update Product set name='{Name}' WHERE id={id}", connection))
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Product Update!");
            }
            connection.Close();

        }

    }


    public void ProductList()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        {
            connection.Open();

            using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM Product", connection))
            {
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0)}.{reader.GetString(1)}");
                }

            }
            connection.Close();

        }
    }

}
