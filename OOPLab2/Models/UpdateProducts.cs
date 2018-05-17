using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace OOPLab2.Models
{
    public class UpdateProducts : Singleton, IUpdate
    {

        private static SqlConnection aConnnection = null;

        public bool EditProducts(int pIdParam, string pNameParam, string catIdParam, string supIdParam, string priceParam)
        {
            bool flag = false;

            aConnnection = Singleton.Instance();

            aConnnection.Open();

            using (SqlCommand command = new SqlCommand("UPDATE Products " +
                "SET ProductName = @pname, CategoryID = @catID, SupplierID = @supID, UnitPrice = @price " +
                "WHERE ProductID = @pID", aConnnection))
            {
                command.Parameters.AddWithValue("@pID", pIdParam);
                command.Parameters.AddWithValue("@pname", pNameParam);
                command.Parameters.AddWithValue("@catID", catIdParam);
                command.Parameters.AddWithValue("@supID", supIdParam);
                command.Parameters.AddWithValue("@price", priceParam);
                command.ExecuteNonQuery();


                flag = true;
                aConnnection.Close();
                return flag;
            }

        }

    }
}