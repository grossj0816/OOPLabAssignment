using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace OOPLab2.Models
{
    public class SelectProducts : Singleton, IRead
    {
        //created a private connection variable that will be instantiated once
        private static SqlConnection aConnection = null;


        //create a list that we will read db records into
        List<NewProducts> fullProdList = new List<NewProducts>();
        //method which has one purpose: to get all products from the database
        public List<NewProducts> GetProducts()
        {
            //grab the single connection to the database
            aConnection = Singleton.Instance();

            //open the connection
            aConnection.Open();

            //create a command to execute SQL query in database 
            //that is found on the local machine
            using (SqlCommand command = new SqlCommand(
                "SELECT * FROM Products", aConnection))
            {
                //execute command
                command.ExecuteNonQuery();

                //set up a reader to read records from database into a list
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    //while we are reading 
                    //through db records
                    while(reader.Read())
                    {
                        //create a variable and cast the values read
                        //into our model as what we want them to be 
                        //classified as
                        int productIdRd = (int)reader["ProductID"];
                        string productNameRd = (string)reader["ProductName"];
                        string categoryIdRd = (string)reader["CategoryID"];
                        string supplierIdRd = (string)reader["SupplierID"];
                        string unitPriceRd = (string)reader["UnitPrice"];

                        //create a object to store all the db records
                        NewProducts newProduct = new NewProducts();

                        //pass the values read in for each field in
                        //an instance variable
                        newProduct.ProductID = productIdRd;
                        newProduct.ProductName = productNameRd;
                        newProduct.CategoryID = categoryIdRd;
                        newProduct.SupplierID = supplierIdRd;
                        newProduct.UnitPrice = unitPriceRd;

                        //stuff all the records in a list
                        fullProdList.Add(newProduct);

                    }
                }
            }
            //close connection and return the view
            aConnection.Close();
            return fullProdList;
        }

    }
}