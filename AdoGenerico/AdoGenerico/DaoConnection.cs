using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_AdoRubrica
{
    //Classe per impostare la connessione
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


/*NOTA 1: 
 * connection.ConnectionString = ConfigurationManager.ConnectionStrings["conServer"].ConnectionString;
 * 
 * connection.Open(); 
 * 
 * Queste due righe di codice sono parte della classe 
 * DaoConnection e sono utilizzate per gestire la connessione 
 * al database. Ecco una spiegazione dettagliata di ciascuna riga:
 * 1) connection.ConnectionString = ConfigurationManager.ConnectionStrings["conServer"].ConnectionString;
 * ConfigurationManager.ConnectionStrings è una classe fornita 
 * da .NET Framework che consente di accedere alle stringhe di 
 * connessione definite nel file di configurazione dell'applicazione 
 * (nel tuo caso, l'App.config). "conServer" è il nome associato 
 * alla stringa di connessione nel file di configurazione. Puoi 
 * trovarlo nel tag <add> all'interno del tag <connectionStrings> 
 * nel tuo file App.config.
 * ConnectionString è una proprietà dell'oggetto SqlConnection che 
 * viene utilizzata per impostare la stringa di connessione al database. 
 * In questo caso, stai impostando la stringa di connessione al 
 * valore associato a "conServer" nel file di configurazione.
 * 
 * 2)connection.Open();
 * connection.Open(); è il metodo che apre effettivamente la connessione 
 * al database. Una volta impostata la stringa di connessione, chiamare 
 * questo metodo avvia la connessione al database specificato nella 
 * stringa di connessione.
 * 
 * In breve, queste due righe sono responsabili di impostare la stringa 
 * di connessione per il database (utilizzando le informazioni dal file 
 * di configurazione) e successivamente aprire la connessione stessa. 
 * Questo è un passaggio critico quando si lavora con Ado.Net per interagire 
 * con un database, poiché apre la strada per eseguire comandi SQL e 
 * recuperare o modificare dati nel database.*/
