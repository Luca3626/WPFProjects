using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoMediaEsami
{
    static class DaoConnection
    {
        public static readonly SqlConnection connection = new();
        
        public static void Connessione() 
        {
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["conLocale"].ConnectionString;
            connection.Open();
        }

        public static void CloseConnection() 
        {
            if (connection == null || connection.State == ConnectionState.Closed)
                return;
            
            connection.Close();
            
        }

    }
}
