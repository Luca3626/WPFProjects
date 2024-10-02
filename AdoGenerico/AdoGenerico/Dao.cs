using _18_AdoRubrica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace AdoGenerico
{
    class Dao
    {
        public static DataView LoadTabelle() 
        {
            string query = "SELECT * FROM INFORMATION_SCHEMA.TABLES";
            try
            {
                using (SqlCommand command = new(query, DaoConnection.connection))
                {

                    SqlDataReader reader = command.ExecuteReader();

                    DataTable data = new DataTable();
                    data.Load(reader);
                    return data.DefaultView;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public static DataView LoadNazioni()
        {
            string query = "SELECT * FROM Nazioni";

            try
            {
                using (SqlCommand command = new(query, DaoConnection.connection))
                {

                    SqlDataReader reader = command.ExecuteReader();

                    DataTable data = new DataTable();
                    data.Load(reader);
                    return data.DefaultView;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
        public static DataView LoadContatti()
        {
            //string query = "SELECT IdContatti,Contatti.Nome as Nome,Cognome,Convert (varchar, Data_nascita,103) as data,Citta,Nazioni.Nome as nazione FROM Nazioni INNER JOIN Contatti ON Nazioni.IdNazione=Contatti.IdNazione";
            string query = "SELECT * FROM Contatti";
            try
            {
                using (SqlCommand command = new(query, DaoConnection.connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable data = new DataTable();
                    data.Load(reader);
                    return data.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
    }
}
