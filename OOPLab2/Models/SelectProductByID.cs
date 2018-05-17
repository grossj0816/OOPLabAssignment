using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace OOPLab2.Models
{
    public class SelectProductByID : Singleton, IReadIndRec
    {
        private static SqlConnection aConnection = null;


        List<NewProducts> indProdList = new List<NewProducts>();

        public List<NewProducts> GetSingleProduct(int pIdParam)
        {
            aConnection = Singleton.Instance();

            aConnection.Open();

            using (SqlCommand command = new SqlCommand(
                "SELECT * FROM Products WHERE ProductID = @pID", aConnection))
            {
                command.Parameters.AddWithValue("@pID", pIdParam);
                command.ExecuteNonQuery();

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {

                        int productIdRd = (int)reader["ProductID"];
                        string productNameRd = (string)reader["ProductName"];
                        string categoryIdRd = (string)reader["CategoryID"];
                        string supplierIdRd = (string)reader["SupplierID"];
                        string unitPriceRd = (string)reader["UnitPrice"];

                        NewProducts newProduct = new NewProducts();


                        newProduct.ProductID = productIdRd;
                        newProduct.ProductName = productNameRd;
                        newProduct.CategoryID = categoryIdRd;
                        newProduct.SupplierID = supplierIdRd;
                        newProduct.UnitPrice = unitPriceRd;

                        //stuff all the records in a list
                        indProdList.Add(newProduct);

                    }
                }
            }
            //close connection and return the view
            aConnection.Close();
            return indProdList;
        }
    }
}