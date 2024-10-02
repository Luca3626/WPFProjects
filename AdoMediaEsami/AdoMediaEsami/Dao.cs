using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoMediaEsami
{
    internal class Dao
    {
        public static DateTime MediaAnnoCorso(string? anno_corso)
        {
            try 
            {
                using (SqlCommand command = new("MediaAnno", DaoConnection.connection)) 
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue()
                }
            } 
            catch 
            { 
            }
        return null;
        }

    }
}
