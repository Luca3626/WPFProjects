using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _18_AdoRubrica
{

    /* In questa classe Dao*/

    class DaoNazione
    {
        public static DataView LoadNazioni() 
        {
            string query = "SELECT * FROM Nazioni";

            try 
            {
                 using (SqlCommand command = new(query, DaoConnection.connection)) 
                {
                    

                    //Questo comando ExecuteReader prende la query
                    //e la connessione contenuti in
                    //command e ritorna il risultato
                    //della query
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable data = new DataTable();

                    /* Per fare in modo che il risultato della query 
                     * venga inserito in questo oggetto DataTable 
                     * dichiarato qui sopra, facciamo così:   */
                    data.Load(reader);

                    /* Non possiamo associare un oggetto DataTable 
                     * successivamente all'ItemSource (che prende solo
                     * oggetti di un certo tipo, e dà errore con 
                     * oggetti DataTable) per inserirlo    
                     * nella Combobox. Usiamo la proprietà 
                     * DefaultView sull'oggetto data e lo facciamo 
                     * ritornare. */
                    return data.DefaultView;
                }
                
            } 
            catch (Exception e) 
            {
                MessageBox.Show(e.Message);
                return null;
            }

            //NOTA 1
      
        }

        //Un altro metodo che ritorna non un DataView ma una lista di nazioni
        public static List<Nazione> GetNazioni() 
        {
            string query = "SELECT * FROM Nazioni";
            List<Nazione> nazioni = new();
            try 
            {
                using (SqlCommand command = new(query, DaoConnection.connection)) 
                {
                    SqlDataReader reader = command.ExecuteReader();
                    //Continua il file fin quando il metodo Read non ritorna false.
                    while(reader.Read()) 
                    {
                        nazioni.Add(new() 
                        { IdNazione = int.Parse(reader["IdNazione"].ToString()), Nome = reader["Nome"].ToString() 
                        });
                        /* La parentesi quadra reader["IdNazione"].ToString() 
                         * è utilizzata per accedere al valore della colonna 
                         * specificata (in questo caso "IdNazione") nel risultato 
                         * della query restituito dal lettore dati (SqlDataReader). 
                         * In questo contesto, reader["IdNazione"].ToString() accede 
                         * al valore nella colonna "IdNazione" del risultato della 
                         * query attuale e lo converte in una stringa. Quindi, stai 
                         * creando un nuovo oggetto Nazione e stai assegnando i 
                         * valori delle sue proprietà IdNazione e Nome utilizzando 
                         * i valori ottenuti dal lettore dati. La sintassi tra 
                         * parentesi graffe { ... } è utilizzata per inizializzare 
                         * le proprietà dell'oggetto Nazione direttamente durante 
                         * la creazione dell'oggetto.*/
                    }
                    return nazioni;
                }
            } 
            catch (Exception) 
            {
                return null;
            }
        }
    }

    class DaoContatto 
    {
        public static void SaveContatto(Contatto c) 
        {
            string sql = "INSERT INTO Contatti (Nome,Cognome,Data_Nascita,Citta,IdNazione) VALUES (@Nome,@Cognome,@Data,@Citta,@IdNazione)";

            using (SqlCommand cmd = new(sql, DaoConnection.connection)) 
            {
                //Parameters ritorna una collection di
                //oggetti SqlParameters.
                //AddWithValue va a creare l'oggetto
                //SqlParameter con quei dati e lo va
                //ad aggiungere alla collection.
                //Prende come argomento il parametro
                //impostato all'interno della query
                //parametrica e il campo relativo
                //della classe in questo caso Contatti:
                cmd.Parameters.AddWithValue("@Nome", c.Nome);
                cmd.Parameters.AddWithValue("@Cognome", c.Cognome);
                cmd.Parameters.AddWithValue("@Data",DateTime.Parse(c.Data_Nascita.ToString()));
                cmd.Parameters.AddWithValue("@Citta", c.Citta);
                cmd.Parameters.AddWithValue("@IdNazione", c.Nazione?.IdNazione);

                //Esegue la query di comando
                cmd.ExecuteNonQuery();

                //NOTA 2
            }
        }

        public static DataView LoadContatti()
        {
            string query = "SELECT IdContatti,Contatti.Nome as Nome,Cognome,Convert (varchar, Data_nascita,103) as data,Citta,Nazioni.Nome as nazione FROM Nazioni INNER JOIN Contatti ON Nazioni.IdNazione=Contatti.IdNazione"; 
            try
            {
                using (SqlCommand command = new(query, DaoConnection.connection))
                {
                    SqlDataReader reader = command.ExecuteReader();//contiene il risultato della query
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

        /* In argomento del metodo una lista di id che deve andare a 
         * cancellare (ricorda che si possono selezionare più voci insieme, 
         * dato che nel tag DataGrid SelectionMode="Extended")*/
        public static void DeleteContatti(List<int> ids) 
        {
            string sql = "DELETE FROM Contatti WHERE IdContatti = @Id";
            try
            {

                using (SqlCommand cmd = new(sql, DaoConnection.connection))
                {
                    foreach (var id in ids)
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();

                        //quando si va ad addizionare l'altro parametro.
                        cmd.Parameters.Clear();
                    }
                }

            }
            catch (Exception e) 
            {
                MessageBox.Show(e.Message);
            }
            
        }

        public static DataView Ricerca(int id) 
        {
            string query = "SELECT IdContatti,Contatti.Nome as Nome,Cognome,Convert (varchar, Data_nascita,103) as data,Citta,Nazioni.Nome as nazione FROM Nazioni INNER JOIN Contatti ON Nazioni.IdNazione=Contatti.IdNazione WHERE Nazioni.IdNazione=@Id";

            try
            {
                using (SqlCommand command = new(query, DaoConnection.connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
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

        /* Con il parametro di tipo out, il metodo ritorna un 
         * oggetto DataView, ma se inseriamo il parametro out 
         * possiamo fare in modo di far tornare due valori. 
         * Con le reference, modificando il parametro qui 
         * dentro lo possiamo utilizzare anche al di fuori*/
        public static DataView? LoadContattiprocedure(int id, out string conta) 
        {
            /* Non devo impostare la query qui, perché 
             * l'ho già impostata nel database Microsoft SQL. 
             * All'Interno dell costruttore di SqlCommand cmd,
             * il primo argomento sarà il nome del file in cui 
             * è contenuta la Stored Procedure*/
            try
            {
                using (SqlCommand cmd = new("RicercaContatti", DaoConnection.connection))
                {
                    /* Dobbiamo dire all'oggetto cmd che 
                     * stiamo lavorando con una procedure. 
                     * Usiamo la property CommandType:*/
                    cmd.CommandType = CommandType.StoredProcedure;

                    /* Qui sotto. come argomento il nome del 
                     * parametro che però deve corrispondere col 
                     * nome del parametro inserito nella stored 
                     * procedure*/
                    cmd.Parameters.AddWithValue("@IdNazione", id);

                    /* Dato che il secondo parametro (@Conta) 
                     * nella stored Procedure è di tipo OUT, 
                     * va fatto così:*/
                    SqlParameter par = new SqlParameter("@Conta", SqlDbType.Int);
                    /**/
                    par.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(par);

                    /* Come vedi qui noi non impostiamo il valore,
                     * del parametro @Conta 
                     * che invece verrà calcolato e impostato 
                     * nella stored procedure (essendo una conta 
                     * di elementi della tabella contatti 
                     * appartenenti a uno specifico elemento della 
                     * tabella nazioni.*/

                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable data = new DataTable();
                    data.Load(reader);

                    conta = cmd.Parameters["@Conta"].Value.ToString();
                    
                    return data.DefaultView;

                    
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}

/*NOTA 1 
 * 
 * public static DataView LoadNazioni()
 * 
 * Questo metodo LoadNazioni è responsabile di recuperare 
 * i dati relativi alle nazioni da un database e restituirli 
 * sotto forma di DataView. 
 * 
 * *****************************************************************
 * 
 * using (SqlCommand command = new(query, DaoConnection.connection)) 
 * 
 * La sintassi using in C# è utilizzata per garantire che le 
 * risorse vengano correttamente rilasciate dopo il loro utilizzo. 
 * Nel contesto di ADO.NET, è comunemente utilizzata con oggetti 
 * che implementano l'interfaccia IDisposable, come SqlCommand. 
 * L'oggetto SqlCommand è responsabile dell'esecuzione di comandi 
 * SQL sul database. La riga di codice specifica crea un nuovo 
 * oggetto SqlCommand all'interno di un blocco using. Questo blocco 
 * using assicura che l'oggetto SqlCommand venga rilasciato 
 * correttamente, cioè che vengano chiamati i metodi Dispose 
 * dell'oggetto quando il blocco viene completato, indipendentemente 
 * da come il blocco è terminato (normalmente o a causa di un'eccezione).
 * - Creazione dell'oggetto SqlCommand:
 * using (SqlCommand command = new(query, DaoConnection.connection))
 * {
 *    // ... codice all'interno del blocco using ...
 * }
 * Viene creato un nuovo oggetto SqlCommand e assegnato alla 
 * variabile command. Il costruttore SqlCommand richiede due parametri:
 * 1) query: la query SQL da eseguire.
 * 2) DaoConnection.connection: l'oggetto SqlConnection che rappresenta 
 *    la connessione al database.
 * - Esecuzione del codice all'interno del blocco using:
 * Tutto il codice all'interno delle parentesi graffe del blocco using 
 * sarà eseguito all'interno del contesto del blocco. L'oggetto command 
 * è disponibile solo all'interno di questo blocco.
 * - Rilascio delle risorse:
 * Al termine del blocco using, quando il flusso del programma esce 
 * dalle parentesi graffe, il metodo Dispose dell'oggetto command viene 
 * chiamato automaticamente. Questo assicura che le risorse utilizzate 
 * dall'oggetto SqlCommand vengano correttamente rilasciate, come la 
 * chiusura di eventuali connessioni al database.
 * - Vantaggi dell'utilizzo di using:
 * Utilizzando using, si ottiene una sintassi più pulita e sicura rispetto 
 * alla gestione manuale delle risorse. Inoltre, aiuta a prevenire perdite 
 * di memoria e garantisce che le risorse siano rilasciate anche in caso 
 * di eccezioni.
 * In breve, l'utilizzo di using con oggetti IDisposable è una pratica 
 * consigliata in C# per garantire una corretta gestione delle risorse 
 * e favorire la manutenibilità del codice. 
 * 
 * L’istruzione using offre una comoda sintassi per l’uso corretto delle 
 * istanze di classe che implementano l’interfaccia IDisposable.
 * I file, per esempio, sono gestiti da classi del framework .NET le quali 
 * accedono a risorse non gestite, che sono allocate dal sistema operativo 
 * (handle di file). Ci sono molti esempi di classi del framework che 
 * incapsulano risorse non gestite, come ad esempio tutte le classi che 
 * gestiscono i servizi di rete (System.Net), le classi che gestiscono 
 * l’accesso al database SQL Server (System.Data.SqlClient). Tutte queste 
 * classi implementano l’interfaccia IDisposable e per un corretto uso degli 
 * oggetti occorre abbinare l’uso del blocco using.
 * L’interfaccia IDisposable dichiara il metodo Dispose, pertanto le classi 
 * che implementano tale interfaccia provvedono ad una definizione del metodo 
 * per eseguire attività per rilasciare o reimpostare risorse non gestite.
 * Questo implica che quando si utilizzano istanze di classi (oggetti) che 
 * implementano IDisposable, per un corretto funzionamento dell’applicazione 
 * occorre rilasciare le risorse non gestite richiamando il metodo Dispose, 
 * e deve essere fatto in ogni condizione, anche quando si verificano delle 
 * eccezioni, cioè degli errori.
 * Per semplificare la scrittura del codice, e renderlo allo stesso tempo robusto, 
 * evitando che il programmatore possa dimenticare la chiamata al metodo Dispose, 
 * è stato introdotto il blocco using che automaticamente esegue le chiamate 
 * al metodo quando il codice è stato completato.
 * Per analizzare la sintassi prendiamo il caso della classe StreamWriter 
 * per scrivere un file di testo:
 * 
 * using (StreamReader sr = new StreamReader(nomeFile))
 * {
 *    //istruzioni
 * }
 * 
 * Di fatto, l’istruzione using viene convertita dal compilatore in un blocco 
 * try/finally per gestire la chiamata del metodo Dispose. Il blocco using 
 * precedente si espande nel codice seguente in fase di compilazione (si notino 
 * le parentesi graffe aggiuntive per creare l’ambito limitato per l’oggetto):
 * 
 * {
 *    StreamReader sr = new StreamReader(nomeFile));
 *    try
 *    {
 *       //istruzioni
 *    }
 *    finally
 *    {
 *       if (sr != null)
 *          ((IDisposable)sr).Dispose();
 *    }
 * }
 * 
 * Quindi quando uso il blocco using, in realtà si sta usando un blocco 
 * try/finally che garantisce che Dispose venga chiamato anche se si verifica 
 * un’eccezione.
 * 
 * *********************************************************
 * 
 * SqlCommand
 * 
 * SqlCommand è una classe in ADO.NET, che è la tecnologia fornita 
 * da Microsoft per accedere e manipolare dati in database relazionali. 
 * SqlCommand fa parte del namespace System.Data.SqlClient e viene 
 * utilizzata per rappresentare un comando SQL che può essere eseguito 
 * su un database SQL Server.
 * 1. Creazione di un oggetto SqlCommand:
 * SqlCommand command = new SqlCommand();
 * Puoi creare un nuovo oggetto SqlCommand utilizzando il costruttore 
 * senza parametri (noi abbiamo usato direttamente il costruttore con
 * due parametri, la query e la connection). Successivamente, puoi 
 * impostare la proprietà CommandText con la tua query SQL e associare 
 * una connessione utilizzando la proprietà Connection:
 * command.CommandText = "SELECT * FROM Tabella";
 * command.Connection = unaConnessioneSql;
 * 
 * 2. Utilizzo di parametri:
 * Puoi utilizzare parametri nelle tue query per rendere più sicuro 
 * e flessibile il tuo codice, evitando potenziali problemi di sicurezza 
 * come SQL injection. Ecco un esempio di come aggiungere parametri a 
 * un oggetto SqlCommand:
 * command.CommandText = "INSERT INTO Tabella (Nome, Età) VALUES (@Nome, @Età)";
 * command.Parameters.AddWithValue("@Nome", "John");
 * command.Parameters.AddWithValue("@Età", 25);
 * 
 * 3. Esecuzione di comandi:
 * Per eseguire un comando SQL, puoi utilizzare vari metodi a seconda 
 * dell'azione che vuoi compiere. Alcuni esempi comuni includono:
 * - ExecuteNonQuery(): Utilizzato per eseguire comandi che non restituiscono 
 * dati, come INSERT, UPDATE o DELETE:
 * int rowsAffected = command.ExecuteNonQuery();
 * - ExecuteReader(): Utilizzato per eseguire comandi che restituiscono 
 * un set di risultati, come SELECT:
 * SqlDataReader reader = command.ExecuteReader();
 * - ExecuteScalar(): Utilizzato per eseguire comandi che restituiscono 
 * una singola valore, come SELECT COUNT(*):
 * object result = command.ExecuteScalar();
 * 
 * 4. Gestione delle transazioni:
 * Puoi utilizzare SqlCommand insieme a oggetti SqlTransaction per gestire 
 * le transazioni, garantendo che un insieme di comandi venga eseguito in 
 * modo atomico (tutto o nulla).
 * using (SqlTransaction transaction = connection.BeginTransaction())
 * {
 *    command.Transaction = transaction;
 *    // Esegui qui i tuoi comandi
 *    transaction.Commit(); // O transaction.Rollback() in caso di errore
 * }
 * 
 * 5. Rilascio delle risorse:
 * Poiché SqlCommand implementa l'interfaccia IDisposable, è una buona 
 * pratica utilizzarla all'interno di un blocco using per garantire 
 * che le risorse vengano rilasciate correttamente dopo l'utilizzo:
 * using (SqlCommand command = new SqlCommand("SELECT * FROM Tabella", connection))
 * {
 *    // Codice qui
 * }
 * 
 * In sintesi, SqlCommand è uno strumento potente per interagire con 
 * un database SQL Server utilizzando C#. Consentendo la scrittura e 
 * l'esecuzione di comandi SQL, fornisce un'interfaccia flessibile e 
 * robusta per l'accesso ai dati.
 * *******************************************************************
 * 
 * DataView 
 * 
 * La classe DataView in C# è molto simile alle viste in SQL Server. 
 * Quindi, utilizzando DataView, possiamo visualizzare o rappresentare 
 * i dati di un DataTable in vari stili o formati. Ad esempio, utilizzando 
 * DataView possiamo visualizzare i dati del DataTable in diversi ordini 
 * di ordinamento e possiamo anche filtrare i dati del DataTable. E il 
 * punto più importante è che possiamo creare qualsiasi numero di DataViews 
 * per un singolo DataTable per rappresentare i dati in formati diversi.
 * Secondo MSDN, DataView rappresenta una vista personalizzata e vincolabile 
 * dei dati di un DataTable per ordinamento, filtraggio, ricerca, modifica 
 * e navigazione. DataView non memorizza i dati, ma rappresenta piuttosto 
 * una vista connessa del corrispondente DataTable. Le modifiche ai dati 
 * di DataView influenzeranno il DataTable originale. Le modifiche ai dati 
 * del DataTable influenzeranno anche tutte le DataViews associate al DataTable.
 * ********************************************************************* 
 * 
 * SqlDataReader reader = command.ExecuteReader();
 * Questa riga di codice: è utilizzata per eseguire una query SQL e ottenere 
 * un lettore dati (SqlDataReader). Vediamo una spiegazione più dettagliata:
 * command: È un oggetto della classe SqlCommand. Questo oggetto rappresenta 
 * una query SQL o una stored procedure che verrà eseguita sul database. 
 * La query da eseguire è specificata come primo argomento quando si crea 
 * l'oggetto SqlCommand.
 * ExecuteReader(): Questo metodo viene chiamato sull'oggetto command e avvia 
 * l'esecuzione della query nel database. Restituisce un oggetto SqlDataReader 
 * che rappresenta un flusso di dati risultante dalla query.
 * SqlDataReader: È una classe in ADO.NET che fornisce un modo efficiente per 
 * leggere i dati in un flusso progressivo da un database SQL Server. Questo 
 * oggetto consente di iterare attraverso le righe restituite dalla query una 
 * alla volta.
 * Quindi, quando esegui command.ExecuteReader(), stai effettivamente eseguendo 
 * la query specificata in command sul database e ottenendo un SqlDataReader. 
 * Questo lettore dati può essere utilizzato per leggere le righe restituite 
 * dalla query, una alla volta, in modo efficiente. Ad esempio, puoi accedere 
 * ai valori delle colonne per ogni riga durante l'iterazione attraverso il 
 * lettore dati.
 * ************************************************************************ 
 * 
 * DataTable data = new DataTable();
 * data.Load(reader); 
 * 
 * Queste righe di codice sono utilizzate per caricare i dati ottenuti da un 
 * lettore dati (SqlDataReader) in un oggetto DataTable. 
 * DataTable data = new DataTable();: Viene creata un'istanza della classe DataTable. 
 * Un oggetto DataTable rappresenta una tabella di dati in memoria, simile a una 
 * tabella in un database relazionale. Questo oggetto può contenere colonne 
 * e righe di dati.
 * data.Load(reader);: Il metodo Load di DataTable viene chiamato, e come 
 * argomento viene passato il lettore dati (SqlDataReader) ottenuto dalla 
 * query eseguita in precedenza. Questo metodo popola l'oggetto DataTable 
 * con i dati presenti nel lettore dati.
 * In altre parole, data.Load(reader) legge ogni riga di dati dal lettore 
 * dati e la aggiunge come una riga nel DataTable. Ogni colonna nel DataTable 
 * corrisponde a una colonna nel risultato della query.
 * Quindi, alla fine di questa sequenza di codice, l'oggetto data conterrà 
 * i dati risultanti dalla query SQL, organizzati come un set di righe e colonne 
 * in un DataTable. Questo DataTable può quindi essere utilizzato come origine 
 * dati per controlli di interfaccia utente come DataGrid o ComboBox.
 * **************************************************************************** 
 * 
 * return data.DefaultView;
 * 
 * Questa riga di codice restituisce la vista predefinita (DefaultView) di 
 * un oggetto DataTable. Restituisce la vista predefinita del DataTable.
 * Una DataView fornisce una rappresentazione dinamica, filtrabile e ordinabile 
 * dei dati. Quando si utilizza questa vista come origine dati per controlli 
 * di interfaccia utente come DataGrid o ComboBox, è possibile beneficiare 
 * delle funzionalità di ordinamento, filtraggio e visualizzazione dinamica 
 * dei dati fornite dalla classe DataView. Inoltre, le modifiche apportate 
 * alla vista verranno riflesse nel DataTable sottostante. Questa separazione 
 * consente una gestione più flessibile e interattiva dei dati all'interno 
 * dell'interfaccia utente. 
 * La ragione principale per cui non puoi associare direttamente un oggetto 
 * DataTable alla proprietà ItemsSource di alcuni controlli di interfaccia 
 * utente, come DataGrid o ComboBox, è che tali controlli richiedono una 
 * collezione di oggetti, mentre DataTable è una rappresentazione tabellare 
 * dei dati con colonne e righe.
 * La soluzione comune è utilizzare la proprietà DefaultView di DataTable, 
 * che restituisce un oggetto DataView. Un oggetto DataView può essere 
 * utilizzato come origine dati per la maggior parte dei controlli di 
 * interfaccia utente, poiché fornisce una vista dei dati che può essere 
 * facilmente visualizzata e manipolata. Ecco un esempio di come potresti 
 * utilizzare DefaultView:
 * 
 * DataGrid dataGrid = new DataGrid();
 * DataTable dataTable = new DataTable();
 * // Popola il DataTable con i dati...
 * // Usa il DefaultView come origine dati per il DataGrid
 * dataGrid.ItemsSource = dataTable.DefaultView;
 * 
 * In questo modo, il DataGrid può interagire con la vista dei dati fornita 
 * da DefaultView. La vista può essere ordinata, filtrata e manipolata, e le 
 * modifiche verranno riflesse nel DataTable sottostante.
 * In sintesi, l'utilizzo di DefaultView consente di superare la limitazione 
 * di associare direttamente un oggetto DataTable a controlli di interfaccia 
 * utente che richiedono una collezione di oggetti. 
 * ************************************************************************* 
 * 
 * NOTA 2 string 
 * 
 * sql = "INSERT INTO Contatti (Nome,Cognome,Data_Nascita,Citta,IdNazione) VALUES (@Nome,@Cognome,@Data,@Citta,@IdNazione)";
 * 
 * (Nome,Cognome,Data_Nascita,Citta,IdNazione): Elenca i nomi delle colonne 
 * nella tabella "Contatti" in cui vogliamo inserire i dati.
 * VALUES (@Nome,@Cognome,@Data,@Citta,@IdNazione): Specifica i valori che 
 * vogliamo inserire nelle rispettive colonne. Tuttavia, al posto dei valori 
 * effettivi, utilizziamo dei parametri rappresentati da '@' seguito dal nome 
 * del campo. Questi parametri saranno sostituiti con valori reali prima 
 * dell'esecuzione effettiva della query.
 * Quindi, questa stringa SQL è progettata per inserire un nuovo record nella 
 * tabella "Contatti", fornendo i valori per le colonne Nome, Cognome, Data_Nascita, 
 * Citta e IdNazione attraverso i parametri '@Nome', '@Cognome', '@Data', '@Citta' 
 * e '@IdNazione'. La sostituzione di questi parametri con valori effettivi 
 * avviene successivamente nel codice quando si definiscono i parametri della 
 * query.
 * ***************************************************************************
 * 
 * cmd.Parameters.AddWithValue
 * 
 * E' un metodo utilizzato per aggiungere parametri a un oggetto SqlCommand 
 * in ADO.NET. Questo metodo consente di creare e aggiungere un nuovo parametro 
 * alla raccolta di parametri associata a un oggetto SqlCommand. Di solito, 
 * viene utilizzato in combinazione con una query SQL parametrizzata per evitare 
 * problemi di sicurezza come l'SQL injection.
 * SqlCommand: Rappresenta un'istruzione SQL o una stored procedure da eseguire 
 * sul database.
 * Parameters: È la raccolta di parametri associata a un oggetto SqlCommand. 
 * I parametri sono utilizzati per passare valori a un'istruzione SQL in modo 
 * sicuro.
 * AddWithValue: È un metodo di Parameters che consente di aggiungere un nuovo 
 * parametro alla raccolta. Questo metodo richiede due argomenti:
 * Il primo argomento è il nome del parametro nella query SQL preceduto dal 
 * carattere "@" (ad esempio, @Nome). Il secondo argomento è il valore da associare 
 * al parametro. Quindi, quando si esegue il codice come:
 * 
 * cmd.Parameters.AddWithValue("@Nome", c.Nome);
 * 
 * Stai aggiungendo un parametro chiamato @Nome con il valore della proprietà 
 * Nome dell'oggetto Contatto (c). Questo è particolarmente utile quando si 
 * lavora con query SQL parametrizzate, in quanto aiuta a prevenire l'SQL injection 
 * e gestisce in modo sicuro i valori dei parametri. 
 * Nel metodo btnSalva_Click, stai creando un nuovo oggetto Contatto e lo stai 
 * popolando con i valori provenienti dai controlli della tua interfaccia utente (UI). Ecco come:
 * 
 * DaoContatto.SaveContatto(new()
 * {
 *   Nome = txtNome.Text,
 *   Cognome = txtCognome.Text,
 *   Data_Nascita = DateOnly.Parse(txtNascita.Text),
 *   Citta = txtCitta.Text,
 *   Nazione = new() 
 *   {
 *      IdNazione = int.Parse(comNazioni.SelectedValue.ToString())
 *   }
 * });
 * 
 * Nome, Cognome, Data_Nascita, Citta sono impostati rispettivamente con i valori 
 * dei campi di testo (TextBox) txtNome, txtCognome, txtNascita e txtCitta.
 * Nazione è un oggetto Nazione all'interno di Contatto. Il suo IdNazione viene 
 * impostato ottenendo il valore selezionato dalla ComboBox comNazioni.
 * Una volta creato e popolato l'oggetto Contatto, lo stai passando al metodo 
 * SaveContatto di DaoContatto. Questo metodo utilizzerà i valori dell'oggetto 
 * Contatto per eseguire l'operazione di inserimento nel database.
 * ************************************************************************* 
 * 
 * cmd.ExecuteNonQuery()
 * 
 * La riga di codice cmd.ExecuteNonQuery(); esegue la query SQL associata 
 * all'oggetto SqlCommand sulla connessione del database, senza restituire 
 * dati risultanti come in una query di selezione. Questo metodo viene spesso 
 * utilizzato per eseguire comandi SQL che non generano un insieme di risultati, 
 * come le query di inserimento, aggiornamento o eliminazione.
 * cmd: È l'oggetto SqlCommand che rappresenta un'istruzione SQL da eseguire 
 * sul database.
 * ExecuteNonQuery(): È un metodo di SqlCommand che esegue un comando SQL sul 
 * database senza restituire dati. Restituisce il numero di righe interessate 
 * dall'operazione (ad esempio, il numero di righe inserite, aggiornate o eliminate).
 * Quando chiami cmd.ExecuteNonQuery(); nel contesto del tuo progetto, stai 
 * eseguendo l'operazione di inserimento dei dati del contatto nel database, 
 * come definito dalla tua query di inserimento SQL all'interno del metodo 
 * SaveContatto di DaoContatto.
 * Ad esempio, la tua query di inserimento è la seguente:
 * string sql = "INSERT INTO Contatti (Nome,Cognome,Data_Nascita,Citta,IdNazione) VALUES (@Nome,@Cognome,@Data,@Citta,@IdNazione)";
 * cmd.ExecuteNonQuery(); eseguirà questa query, inserendo i valori specificati 
 * nel comando nei rispettivi campi della tabella Contatti nel data*/
