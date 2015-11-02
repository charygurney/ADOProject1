using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.Data.Model;
using ADO.Data.Settings;

namespace ADO.Data.Repository
{
   public class DataRepository
    {
        public List<Product> GetAllProducts()
        {

            List<Product> products = new List<Product>();

            using (SqlConnection cn = new SqlConnection(Settings.Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select Products.ProductID, Products.productName, Categories.CategoryName, Categories.[Description], Products.UnitPrice, Products.UnitsInStock from Products inner join Categories on Products.CategoryID = Categories.CategoryID";
                cmd.Connection = cn;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        products.Add(PopulateFromDataReader(dr));
                    }
                }
            }
            return products;
        }


       public Product GetProductByProductID(int productID)
       {
           Product product = new Product();

           using (SqlConnection cn = new SqlConnection(Settings.Settings.ConnectionString))
           {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select Products.ProductID, Products.productName, Categories.CategoryName, Categories.[Description], Products.UnitPrice, Products.UnitsInStock from Products inner join Categories on Products.CategoryID = Categories.CategoryID where @ProductID = Products.ProductID";
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@ProductID", productID);
                cn.Open();

               using (SqlDataReader dr = cmd.ExecuteReader())
               {
                   while (dr.Read())
                   {
                       product = PopulateFromDataReader(dr);
                   }
               }
               
           }
           return product;
       }
        

        public Product PopulateFromDataReader(SqlDataReader dr)
        {
            Product product = new Product();
            

            product.ProductID = (int)dr["ProductID"];
            product.ProductName = dr["ProductName"].ToString();
            product.CategoryName = dr["CategoryName"].ToString();
            product.Description = dr["Description"].ToString();
            product.UnitPrice = (decimal)dr["UnitPrice"];
            product.UnitsInStock = (short)dr["UnitsInStock"];

            return product;
        }
    }
}
