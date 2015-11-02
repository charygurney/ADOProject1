using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ADOProject
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayOrders();
            Console.ReadLine();
        }

        static void DisplayOrders()
        {
            string connectionString;
            connectionString = ConfigurationManager
                .ConnectionStrings["Northwind"]
                .ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select Products.productName, Categories.CategoryName, Categories.[Description], Products.UnitPrice, Products.UnitsInStock from Products inner join Categories on Products.CategoryID = Categories.CategoryID";
                cmd.Connection = cn;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Console.WriteLine(@"ProductName = {0}
CategoryName = {1} 
Description = {2} 
UnitPrice = {3} 
UnitsInStock = {4}

************",
dr["productName"].ToString(), 
                            dr["CategoryName"].ToString(), dr["Description"].ToString(), dr["UnitPrice"].ToString(),
                            dr["UnitsInStock"].ToString());
                    }
                }
            }
        }
    }
}
