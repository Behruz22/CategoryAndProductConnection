using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExamCode.CategoryActions;

public class Category
{
    public string ConnectionString { get; set; } = "Host = ::1;Port=5432;Database=CategoryProduct; User Id=postgres; password=behruz22";
    public void CategoryAdd(string categoryName)
    {
        if (categoryName != null)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("CREATE TABLE IF NOT EXISTS Category (id SERIAL PRIMARY KEY,name VARCHAR)", connection))
                {
                    command.ExecuteNonQuery();
                }

                using (NpgsqlCommand command = new NpgsqlCommand($"INSERT INTO Category (name) VALUES ('{categoryName}')", connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Category added!");
                }
                connection.Close();
            }
        }


        else
            Console.WriteLine("Noto'g'ri ma'lumot kiritildi!");
    }

    public void CategoryDelete(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        {
            connection.Open();

            using (NpgsqlCommand command = new NpgsqlCommand($"DELETE FROM Category WHERE id={id}", connection))
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Category deleted!");
            }
            connection.Close();

        }
    }
     
    public void CategoryUpdate(int id,string categoryName)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        {
            connection.Open();

            using (NpgsqlCommand command = new NpgsqlCommand($"Update Category set name='{categoryName}' WHERE id={id}", connection))
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Category Update!");
            }
            connection.Close();

        }

    }


    public void CategoryList()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        {
            connection.Open();

            using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM Category", connection))
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

  
