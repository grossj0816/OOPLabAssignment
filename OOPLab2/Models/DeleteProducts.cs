using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace OOPLab2.Models
{
    public class DeleteProducts : Singleton, IDelete 
    {

        private static SqlConnection aConnection = null;

        public bool DestroyProducts(int pIdParam)
        {
            bool flag = false;

            aConnection = Singleton.Instance();

            aConnection.Open();

            using (SqlCommand command = new SqlCommand("DELETE FROM Products WHERE ProductID = @pID", aConnection))
            {
                command.Parameters.AddWithValue("@pID", pIdParam);
                command.ExecuteNonQuery();

                flag = true;
                aConnection.Close();
                return flag;
            }
        }


    }
}