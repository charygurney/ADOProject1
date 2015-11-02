using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.Data;
using ADO.Data.Repository;
using ADO.Data.Model;

namespace ADOProject2A
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            string userInput2;
            int productID;

            do
            {
                Console.Write("Do you want to see all the products? (Y/N)");
                userInput = Console.ReadLine();

                if (userInput.ToUpper() == "Y")
                {
                    Console.Clear();
                    ShowAllProducts();
                    Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("Maybe next time!!!");
                    Console.ReadLine();
                }

            } while (userInput.ToUpper() != "Y");

            do
            {
                Console.WriteLine("Please indicate a product ID number...(1-77)");
                userInput2 = Console.ReadLine();
                productID = int.Parse(userInput2);
                if (productID >= 1 && productID <= 77)
                {
                    Console.Clear();
                    ShowProductByProductID(productID);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("That was not a vallid product ID. Please re-enter an ID between 1 & 77");
                    Console.ReadLine();
                }
            } while (productID < 1 || productID > 77);
        }

        private static void ShowAllProducts()
        {
            DataRepository repo = new DataRepository();
            Console.WriteLine("All Products");
            Console.WriteLine("----------------------");

            foreach (var product in repo.GetAllProducts())
            {
                Console.WriteLine(@"ProductID = {0} 
Product Name = {1}
Category Name = {2}
Description = {3}
Unit Price ={4}
Units In Stock = {5}

********************************", product.ProductID, product.ProductName, product.CategoryName, product.Description, product.UnitPrice, product.UnitsInStock);
            }
        }

        private static void ShowProductByProductID(int productID)
        {
            DataRepository repo = new DataRepository();
            Product product = repo.GetProductByProductID(productID);

            Console.WriteLine(@"ProductID = {0} 
Product Name = {1}
Category Name = {2}
Description = {3}
Unit Price ={4}
Units In Stock = {5}

********************************", product.ProductID, product.ProductName, product.CategoryName, product.Description, product.UnitPrice, product.UnitsInStock);

        }


    }
}
