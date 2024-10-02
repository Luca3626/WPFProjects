using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _11_GridLayout
{
    /// <summary>
    /// Logica di interazione per Visualizza.xaml
    /// </summary>
    public partial class Visualizza : Window
    {
        public Visualizza()
        {
            InitializeComponent();
        }

        /* Esempio di data binding qui sotto*/
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /* ItemSource è una property a cui possiamo 
             * dare unIEnumerable. Possiamo quindi dargli 
             * diverse collection (liste, set, array...). 
             * Gli diamo la lista ritornata dal nostro 
             * metodo LoadUser() in DaoUtente. Ma LoadUser 
             * lancia un'eccezione, quindi il codice va 
             * inglobato in un try-catch*/
            try
            {
                tabella.ItemsSource = DaoUtente.LoadUser();
                /* tabella è il nome di un oggetto di tipo DataGrid 
                 * definito all'interno del file XAML. Quando si 
                 * imposta tabella.ItemsSource = DaoUtente.LoadUser();, 
                 * si sta assegnando la proprietà ItemsSource dell'oggetto 
                 * tabella, che è un controllo di visualizzazione dei 
                 * dati di tipo DataGrid, con i risultati restituiti 
                 * dal metodo DaoUtente.LoadUser(). Questo significa 
                 * che i dati restituiti da LoadUser() verranno visualizzati 
                 * all'interno del DataGrid denominato tabella.*/
            }
            catch (Exception e1) 
            { 
                MessageBox.Show(e1.Message);
                
                /*this indica la finestra corrente, quindi 
                 * la finestra visualizza aperta, e close 
                 * chiude la finestra. (abbiamo fatto così 
                 */
                this.Close();   
            }
        }
    }
}
/* La riga tabella.ItemsSource = DaoUtente.LoadUser(); all'interno del metodo 
 * Window_Loaded della classe Visualizza sta assegnando la sorgente dati per 
 * il controllo DataGrid denominato tabella. In pratica, il metodo LoadUser 
 * della classe DaoUtente viene chiamato per ottenere una lista di oggetti 
 * Utente. Questa lista viene quindi assegnata alla proprietà ItemsSource del 
 * controllo DataGrid. Quando un controllo DataGrid ha una sorgente dati 
 * assegnata, visualizza automaticamente gli elementi della sorgente in una 
 * griglia. Ogni oggetto nell'elenco corrisponderà a una riga nella griglia, 
 * e le proprietà di ogni oggetto corrisponderanno alle colonne.
 * In breve, l'assegnazione di tabella.ItemsSource consente di visualizzare 
 * dinamicamente i dati degli utenti nella finestra Visualizza, rendendo il 
 * DataGrid capace di mostrare le informazioni degli utenti recuperate dal 
 * metodo LoadUser.
 * 
 * La proprietà ItemsSource è un concetto chiave nel data binding di WPF 
 * (Windows Presentation Foundation). Essenzialmente, consente di collegare 
 * una raccolta di dati a un controllo di visualizzazione, come ad esempio 
 * DataGrid, ListBox o ComboBox. Quando si imposta la proprietà ItemsSource 
 * su un controllo, si fornisce a tale controllo una raccolta di oggetti da 
 * visualizzare. Il controllo quindi itera attraverso questa raccolta e crea 
 * un elemento visuale corrispondente per ogni oggetto nella raccolta. 
 * Ad esempio, in un DataGrid, ogni oggetto nella raccolta può essere 
 * rappresentato come una riga nella tabella. La principale vantaggio 
 * dell'utilizzo di ItemsSource è che rende il processo di visualizzazione 
 * dei dati estremamente flessibile e dinamico. Se la raccolta sottostante 
 * cambia (ad esempio, se vengono aggiunti, rimossi o modificati elementi), 
 * il controllo di visualizzazione si aggiorna automaticamente per riflettere 
 * tali modifiche, senza la necessità di intervento manuale.
 * In sintesi, ItemsSource è uno strumento fondamentale per collegare dati 
 * agli elementi visivi in un'applicazione WPF, consentendo una gestione 
 * dei dati più efficace e una presentazione dinamica degli stessi.*/
