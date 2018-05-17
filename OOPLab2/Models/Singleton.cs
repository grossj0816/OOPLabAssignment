using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace OOPLab2.Models
{
    public class Singleton
    {
        //create a connection variable that we set to be null.
        private static SqlConnection aConnection = null;

        //create an instance to be used for other strategy methods
        public static SqlConnection Instance()
        {
            //instance variable that will set the connection variable above
            SqlConnection sqlConnection;

            //if connection is null
            if (Singleton.aConnection == null)
            {
                //createn a new connection to sql server
                sqlConnection = new SqlConnection(@"Server=localhost;Database=Northwind;Trusted_Connection=True;");
            }
            else
            {
                //get the current connection
                sqlConnection = Singleton.aConnection;
            }

            return sqlConnection;
        }

    }
}