using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_GridLayout
{
    static class DaoUtente
    {
        public static void saveUser(Utente ut) 
        {
            /* Non uso Write che andrebbe a sovrascrivere*/
            File.AppendAllText("utenti.txt", $"{ut.Nome}#{ut.Cognome}#{ut.Data}{System.Environment.NewLine}");

            /* In questa parte della classe DaoUtente stiamo implementando 
             * il metodo saveUser, che prende in input un oggetto di tipo 
             * Utente e lo salva su un file di testo chiamato "utenti.txt". 
             * 
             * ▪ File.AppendAllText è un metodo statico della classe File che 
             * consente di aggiungere del testo a un file di testo esistente. 
             * Se il file non esiste, viene creato.
             * ▪ "utenti.txt" è il percorso del file di testo in cui verrà 
             * aggiunto il testo.
             * ▪ ${ut.Nome}#{ut.Cognome}#{ut.Data} è una stringa interpolata 
             * che contiene i dati dell'utente.
             * ▪ ut.Nome, ut.Cognome e ut.Data sono le proprietà dell'oggetto 
             * Utente che rappresentano rispettivamente il nome, il cognome e 
             * la data di nascita dell'utente.
             * ▪ # è un separatore utilizzato per distinguere i diversi campi 
             * dei dati dell'utente all'interno della riga.
             * ▪ ${System.Environment.NewLine} è una costante di sistema che 
             * rappresenta un carattere di nuova riga. Viene utilizzata per 
             * assicurarsi che ogni riga nel file di testo sia separata da una 
             * nuova riga, in modo che ogni utente venga inserito su una riga 
             * separata nel file.
             * 
             * Questa parte di codice prende i dati di un utente 
             * (Nome, Cognome, Data) e li concatena in una stringa, separando i 
             * campi con il carattere #. Questa stringa viene quindi aggiunta 
             * come una nuova riga nel file di testo "utenti.txt", garantendo 
             * che ogni utente sia inserito su una riga separata nel file.
             * In sintesi, questo metodo salva i dati di un utente specificato su un 
             * file di testo chiamato "utenti.txt", aggiungendo una nuova riga per ogni 
             * utente senza sovrascrivere i dati esistenti nel file. 
             * 
             * ******************************************************************
             * Metodo AppendAllText
             * 
             * Il metodo AppendAllText fa parte della classe File nel namespace 
             * System.IO e viene utilizzato per aggiungere testo a un file di testo 
             * esistente o, se il file non esiste, per crearlo e quindi aggiungere 
             * il testo. 
             * 
             * - Firma del metodo:
             * public static void AppendAllText(string path, string contents);
             * 
             * - Parametri: 
             * ▪ path: Il percorso del file di testo in cui aggiungere il testo.
             * ▪ contents: Il testo da aggiungere al file.
             * - Funzionamento:
             * Se il file specificato dal parametro path esiste, il metodo AppendAllText 
             * aggiunge il testo specificato dal parametro contents alla fine del file.
             * Se il file non esiste, il metodo crea un nuovo file con il nome specificato 
             * da path e vi scrive il testo specificato da contents.
             * - Considerazioni: 
             * Se il file specificato da path non può essere creato o scritto per 
             * qualche motivo (ad esempio, mancanza di autorizzazioni o file di sola 
             * lettura), verrà generata un'eccezione. Il testo specificato da contents 
             * viene aggiunto al file senza alcuna formattazione. Se è necessario formattare 
             * il testo prima di aggiungerlo al file (ad esempio, aggiungere una nuova riga),
             * questo deve essere fatto prima di passare il testo al metodo AppendAllText.
             * - Utilizzo comune:
             * string path = "miofile.txt";
             * string testoDaAggiungere = "Questo è il testo da aggiungere al file.";
             * File.AppendAllText(path, testoDaAggiungere);
             * In questo esempio, il testo specificato da testoDaAggiungere verrà aggiunto 
             * al file "miofile.txt". Se il file non esiste, verrà creato. Se il file esiste 
             * già, il testo verrà aggiunto alla fine del file. 
             * 
             * Nel contesto della nostra applicazione WPF, il file "utenti.txt" viene 
             * creato nella stessa directory in cui viene eseguito il programma. Quando 
             * il metodo File.AppendAllText("utenti.txt", ...) viene chiamato per la 
             * prima volta e il file "utenti.txt" non esiste ancora, il sistema operativo 
             * creerà il file nella directory di lavoro predefinita dell'applicazione, 
             * a meno che non venga specificato un percorso di file completo.
             * La directory di lavoro predefinita per un'applicazione WPF è solitamente 
             * la cartella in cui si trova il file eseguibile dell'applicazione. Quando 
             * si avvia un'applicazione WPF dall'ambiente di sviluppo come Visual Studio, 
             * di solito la directory di lavoro è la directory del progetto, ma quando si 
             * distribuisce l'applicazione, la directory di lavoro può essere diversa, 
             * a seconda di come è configurata l'esecuzione dell'applicazione.
             * Pertanto, se il file "utenti.txt" non esiste ancora e il metodo 
             * File.AppendAllText("utenti.txt", ...) viene chiamato per la prima volta, 
             * il file verrà creato nella directory di lavoro dell'applicazione, ovvero 
             * la directory in cui viene eseguito il programma. 
             * ( Come faccio a conoscere la directory di lavoro? 
             * Per determinare esattamente quale sia la directory di lavoro per una 
             * specifica esecuzione dell'applicazione, è possibile utilizzare il codice 
             * per stampare o registrare il percorso della directory di lavoro all'interno 
             * dell'applicazione. Ad esempio, in C# si può utilizzare Directory.GetCurrentDirectory() 
             * per ottenere il percorso della directory di lavoro corrente. )*/
        }

        //metodo che va a prendere i dati da un file e li inserisce in una lista. 
        public static List<Utente> LoadUser() 
        {
            List<Utente> utenti = new List<Utente>();

            /* Ilmetodo exists è un booleano. Vado a gestire
             * le eccezioni nel caso in cui il file non 
             * esiste*/
            if (!File.Exists("utenti.txt"))
                throw new Exception("Il file non esiste!");

            /* Il metodo ReadAllLines() legge tutte le righe 
             * di un file e ritorna un array di stringhe 
             * contenente tutte le righe del file.*/
            string[] righe = File.ReadAllLines("utenti.txt");
            string[] r;
            foreach (var riga in righe) 
            {
                r = riga.Split('#');

                /*new(){} metodo costruttore senza dare il nome, 
                 * inizializzato direttamente nelle graffe*/
                utenti.Add(new()
                {
                    Nome = r[0],
                    Cognome = r[1],
                    Data = DateOnly.Parse(r[2]),
                });
            }

            return utenti;
        }
        /* Il metodo LoadUser() all'interno della classe DaoUtente è responsabile 
         * per caricare i dati degli utenti da un file di testo chiamato "utenti.txt" 
         * e restituirli sotto forma di una lista di oggetti Utente.
         * 
         * - Creazione della lista di utenti: Si inizia creando una lista vuota di 
         * oggetti Utente chiamata utenti.
         * 
         * - Controllo dell'esistenza del file: Viene verificato se il file "utenti.txt" 
         * esiste nella directory corrente utilizzando File.Exists(). Se il file non 
         * esiste, viene generata un'eccezione con un messaggio che indica che il file 
         * non esiste. Il metodo File.Exists("utenti.txt") è un metodo statico fornito 
         * dalla classe File nella libreria .NET Framework. Questo metodo è progettato
         * per controllare se un file specificato esiste nella directory specificata.
         * ▪ Input: Il metodo accetta come argomento una stringa che rappresenta il 
         *   percorso del file da controllare. In questo caso, il percorso specificato 
         *   è "utenti.txt".
         * ▪ Controllo dell'esistenza del file: Il metodo esegue un controllo nel file 
         *   system per verificare se il file specificato esiste o meno.
         * ▪ Restituzione del risultato: Il risultato del controllo viene restituito 
         *   come valore booleano: true se il file esiste, false altrimenti.
         * In breve, File.Exists("utenti.txt") è un metodo utilizzato per verificare 
         * se un file di nome "utenti.txt" esiste nella directory corrente. È comunemente 
         * utilizzato per condizioni di controllo prima di operazioni di lettura o 
         * scrittura su file
         * ▪ Lancio dell'eccezione: La riga throw new Exception("Il file non esiste!"); 
         *   è un'istruzione che viene utilizzata per generare un'eccezione all'interno 
         *   di un programma in C#. 
         *   throw è una parola chiave riservata nel linguaggio C# utilizzata per generare 
         *   manualmente un'eccezione. new Exception("Il file non esiste!") è il 
         *   costruttore dell'eccezione Exception. Quando viene invocato 
         *   new Exception("Il file non esiste!"), viene creata un'istanza di Exception 
         *   con un messaggio specificato, che è "Il file non esiste!" in questo caso. 
         *   Questo messaggio sarà incluso nell'oggetto eccezione e sarà disponibile 
         *   per la gestione dell'eccezione in seguito.
         *   Dopo la creazione dell'oggetto eccezione, l'istruzione throw viene utilizzata 
         *   per "lanciare" effettivamente l'eccezione. Quando viene eseguito throw, 
         *   il flusso di esecuzione del programma viene interrotto e viene restituita 
         *   l'eccezione al contesto chiamante. Questo significa che se il codice contenuto 
         *   in un blocco try non riesce, viene generata l'eccezione specificata, e il 
         *   controllo passa al blocco catch corrispondente nel codice che ha chiamato 
         *   il metodo corrente.
         *   In breve, l'istruzione throw new Exception("Il file non esiste!"); viene 
         *   utilizzata per generare manualmente un'eccezione di tipo Exception con un 
         *   messaggio specificato, che verrà poi gestita nel contesto chiamante. In 
         *   questo caso, viene lanciata un'eccezione se il file "utenti.txt" non esiste 
         *   durante l'esecuzione del metodo LoadUser().
         *   L'eccezione lanciata in DaoUtente.cs viene gestita nel metodo Window_Loaded 
         *   della classe Visualizza.xaml.cs. Questo è evidenziato dal blocco try-catch 
         *   all'interno di Window_Loaded:
         *   
         *   try
         *   {
         *      tabella.ItemsSource = DaoUtente.LoadUser();
         *   } 
         *   catch(Exception e1) 
         *   { 
         *      MessageBox.Show(e1.Message);
         *      this.Close();   
         *   }
         *   
         *   Quando il metodo DaoUtente.LoadUser() viene chiamato nel caricamento della 
         *   finestra Visualizza, se il file "utenti.txt" non esiste, viene lanciata
         *   un'eccezione Exception. Questa eccezione viene catturata dal blocco catch, 
         *   che visualizza un messaggio di errore tramite MessageBox.Show e chiude la 
         *   finestra Visualizza con this.Close().
         * 
         * - Lettura delle righe dal file: Se il file esiste, viene letto il contenuto 
         * del file con File.ReadAllLines("utenti.txt"). Questo metodo restituisce un 
         * array di stringhe, ognuna delle quali rappresenta una riga del file.
         * Il metodo File.ReadAllLines("utenti.txt") è un metodo statico fornito dalla 
         * classe File del namespace System.IO in C#. Esso legge tutte le righe di un 
         * file di testo specificato e restituisce un array di stringhe, ognuna 
         * rappresentante una riga del file.
         * ▪ File.ReadAllLines: Questo è il metodo che viene chiamato per leggere tutte 
         *   le righe di un file. È statico, il che significa che può essere chiamato 
         *   direttamente dalla classe File senza creare un'istanza di File. Il metodo 
         *   prende come argomento il percorso del file da leggere.
         * ▪ "utenti.txt": È il percorso del file da cui leggere le righe. In questo 
         *   caso, il file è denominato "utenti.txt". Il percorso può essere assoluto 
         *   o relativo. Se il percorso non è specificato come un percorso assoluto, 
         *   il metodo File.ReadAllLines cerca il file nella directory di lavoro corrente 
         *   dell'applicazione.
         * ▪ Restituzione delle righe: Il metodo restituisce un array di stringhe, 
         *   ognuna rappresentante una riga del file "utenti.txt". Ogni elemento 
         *   dell'array corrisponde a una riga del file, nell'ordine in cui le righe 
         *   sono memorizzate nel file.
         * In breve, File.ReadAllLines("utenti.txt") legge tutte le righe dal file 
         * "utenti.txt" e restituisce un array di stringhe contenente il contenuto 
         * del file, una riga per elemento dell'array.
         * 
         * - Parsare le righe e aggiungere gli utenti alla lista: Viene eseguito un 
         * ciclo su tutte le righe lette dal file. Per ogni riga, viene divisa utilizzando 
         * il carattere #, poiché sembra che il file utilizzi un formato in cui i dati 
         * sono separati da questo carattere. I pezzi risultanti vengono assegnati ad 
         * un array r. Quindi viene creato un nuovo oggetto Utente utilizzando i dati 
         * estratti dalla riga corrente e viene aggiunto alla lista utenti.
         * - Restituzione della lista degli utenti: Alla fine del ciclo, la lista utenti 
         * contenente tutti gli utenti caricati dal file viene restituita.
         * In sintesi, questo metodo consente di caricare i dati degli utenti da un file 
         * di testo e restituirli come una lista di oggetti Utente, fornendo così una 
         * funzionalità fondamentale per la gestione degli utenti nell'applicazione.*/
    }
}
