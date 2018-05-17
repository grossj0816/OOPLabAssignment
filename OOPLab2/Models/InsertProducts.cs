using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace OOPLab2.Models
{
    public class InsertProducts : Singleton, IInsert
    {
        private static SqlConnection aConnection = null;

        public bool AddProducts(string pNameParam, string catIdParam, string supIdParam, string unitPriceParam)
        {
            //create a flag that will set true whenever we
            //succeed at inserting records into Northwind DB
            bool flag = false;

            //get connection to the database
            aConnection = Singleton.Instance();

            //open a connection to the database
            aConnection.Open();

            //create our command that will execute our sql query
            //in our database table
            using (SqlCommand command = new SqlCommand("INSERT INTO Products" +
                "(ProductName, CategoryID, SupplierID, UnitPrice)" +
                "VALUES(@pName, @catID, @sID, @unitPrice)", aConnection))
            {
                command.Parameters.AddWithValue("@pName", pNameParam);
                command.Parameters.AddWithValue("@catID", catIdParam);
                command.Parameters.AddWithValue("@sID", supIdParam);
                command.Parameters.AddWithValue("@unitPrice", unitPriceParam);
                command.ExecuteNonQuery();


                flag = true;
                aConnection.Close();
                return flag;
            }


        }
    }
}