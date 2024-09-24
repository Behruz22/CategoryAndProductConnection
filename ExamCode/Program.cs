
using ExamCode.CategoryActions;
using ExamCode.ProductActions;
using Npgsql;

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Category category = new Category();
            Product product = new Product();
            bool choice = true;
            while (choice)
            {
                Console.WriteLine("1.Category\n2.Product\n3.Exit");
                Console.Write("Enter one: ");

                int selection = default;
                bool identify = int.TryParse(Console.ReadLine(), out selection);

                switch (selection)
                {
                    case 1:
                        Console.Clear();
                        bool choiceCategory = true;
                        while (choiceCategory)
                        {
                            Console.WriteLine("1.Category add");
                            Console.WriteLine("2.Category update");
                            Console.WriteLine("3.Category delete");
                            Console.WriteLine("4.Category list");
                            Console.WriteLine("5.Exit");
                            Console.Write("Enter one: ");
                            int selectionCategory = default;
                            bool identifyCategory = int.TryParse(Console.ReadLine(), out selectionCategory);
                            switch (selectionCategory)
                            {
                                case 1://Category Add
                                    Console.Write("Category Name: ");
                                    string categoryName= Console.ReadLine();
                                    category.CategoryAdd(categoryName);
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case 2://Category update
                                    Console.Write("Category id: ");
                                    int categoryid = default;
                                    bool identityid = int.TryParse(Console.ReadLine(), out categoryid);
                                    if (identityid)
                                    {
                                        Console.Write("Category Name: ");
                                        string categoryname = Console.ReadLine();
                                        category.CategoryUpdate(categoryid, categoryname);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error data");
                                        continue;
                                    }
                                    
                                    Console.ReadKey();
                                    break;
                                case 3://Category delete
                                    Console.Write("Category id: ");
                                    int categoryId = default;
                                    bool identityId=int.TryParse(Console.ReadLine(),out categoryId);
                                    if (identityId)
                                        category.CategoryDelete(categoryId);
                                    else
                                        Console.WriteLine("Error data");
                                    Console.ReadKey();
                                    
                                    break;
                                case 4://Category list
                                    category.CategoryList();
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case 5:
                                    choiceCategory = false;
                                    Console.Clear();
                                    break;

                                default:
                                    Console.WriteLine("Xato ma'lumot kiritdingiz!");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                            }
                            Console.Clear();
                        }
                        break;
                    case 2:
                        Console.Clear();
                        bool choiceProduct = true;
                        while (choiceProduct)
                        {
                            Console.WriteLine("1.Product add");
                            Console.WriteLine("2.Product update");
                            Console.WriteLine("3.Product delete");
                            Console.WriteLine("4.Product list");
                            Console.WriteLine("5.Exit");
                            Console.Write("Enter one: ");

                            int selectionProduct = default;
                            bool identifyProduct = int.TryParse(Console.ReadLine(), out selectionProduct);

                            switch (selectionProduct)
                            {
                                case 1://Product Add
                                    Console.Write("Category id: ");
                                    int categoryId = default;
                                    bool identityId = int.TryParse(Console.ReadLine(), out categoryId);
                                    if (identityId)
                                    {
                                        Console.Write("Product Name: ");
                                        string productName = Console.ReadLine();
                                        product.ProductAdd(categoryId, productName);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error data");
                                        continue;
                                    }
                                    Console.ReadKey();
                                    break;
                                case 2://Product update
                                    Console.Write("Product id: ");
                                    int proid = default;
                                    bool idenid = int.TryParse(Console.ReadLine(), out proid);
                                    if (idenid)
                                    {
                                        Console.Write("Product Name: ");
                                        string proName = Console.ReadLine();
                                        product.ProductUpdate(proid, proName);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error data");
                                        continue;
                                    }
                                    Console.ReadKey();
                                    break;
                                case 3://Product delete
                                    Console.Write("Product id: ");
                                    int productId = default;
                                    bool identityProductId = int.TryParse(Console.ReadLine(), out productId);
                                    if (identityProductId)
                                        product.ProductDelete(productId);
                                    else
                                        Console.WriteLine("Error data");
                                    Console.ReadKey();
                                    break;
                                case 4://Product list
                                    product.ProductList();
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    choiceProduct = false;
                                    Console.Clear();
                                    break;

                                default:
                                    Console.WriteLine("Xato ma'lumot kiritdingiz!");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                            }
                            Console.Clear();
                        }
                        Console.Clear();
                        break;
                    case 3:
                        choice = false;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Xato ma'lumot kiritdingiz!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

            }
        }
        catch (Exception)
        {
            Console.WriteLine("Dasturda xatolik!");
        }
    }


}
