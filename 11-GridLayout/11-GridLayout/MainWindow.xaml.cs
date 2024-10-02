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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _11_GridLayout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSalva_Click(object sender, RoutedEventArgs e)
        {
            DaoUtente.saveUser(new()
            {
                Nome = txtNome.Text,
                Cognome = txtCognome.Text,
                Data = DateOnly.Parse(txtData.Text)
            });
        }

        private void btnVisualizza_Click(object sender, RoutedEventArgs e)
        {
            /* Qui aggiungiamo un'altra finestra WPF che 
             * verrà visualizzata una volta che premiamo 
             * il pulsante Visualizza. Abbiamo creato 
             * un'altra finestra WPF chiamata Visualizza 
             * (crea una classe Visualizza)*/

            new Visualizza().ShowDialog();
        }
    }
}
/* Questo progetto è un'applicazione WPF che gestisce gli utenti attraverso 
 * una semplice interfaccia grafica: 
 * 
 * 1) MainWindow.xaml:
 * Questo file definisce la finestra principale dell'applicazione, che consente 
 * all'utente di inserire le informazioni dell'utente (nome, cognome, data di 
 * nascita) e di salvare tali informazioni. Utilizza un layout di tipo Grid con 
 * quattro righe e due colonne.Alcuni TextBlock vengono utilizzati per etichettare 
 * i campi di input. Ci sono tre TextBox per l'inserimento del nome e del cognome, 
 * e per selezionare la data di nascita. Due bottoni (btnSalva e btnVisualizza) 
 * consentono rispettivamente di salvare le informazioni inserite e di visualizzare 
 * gli utenti salvati.
 * 
 * 2) MainWindow.xaml.cs:
 * Questo file contiene la logica dietro la finestra principale. Nel costruttore 
 * viene inizializzata la finestra. Il metodo btnSalva_Click viene chiamato quando 
 * l'utente preme il pulsante "Salva". Questo metodo salva le informazioni 
 * dell'utente utilizzando il metodo saveUser della classe DaoUtente. Il metodo 
 * btnVisualizza_Click viene chiamato quando l'utente preme il pulsante "Visualizza". 
 * Apre una nuova finestra Visualizza che mostra tutti gli utenti salvati.
 * 
 * 3) Utente.cs:
 * Questa classe rappresenta un singolo utente e contiene le proprietà Nome, Cognome 
 * e Data (di tipo DateOnly).
 * 
 * 4) DaoUtente.cs:
 * Questa classe contiene metodi per salvare e caricare gli utenti da un file di testo 
 * (utenti.txt). Il metodo saveUser aggiunge un nuovo utente al file di testo. 
 * Il metodo LoadUser legge tutti gli utenti dal file di testo e li restituisce 
 * come lista di oggetti Utente.
 * 
 * 5) Visualizza.xaml:
 * Questo file definisce una finestra per visualizzare gli utenti salvati. Utilizza 
 * un controllo DataGrid per mostrare i dati degli utenti.
 * 
 * 6) Visualizza.xaml.cs:
 * Questo file contiene la logica dietro la finestra di visualizzazione. Nel metodo 
 * Window_Loaded, viene caricata la lista degli utenti utilizzando il metodo LoadUser 
 * della classe DaoUtente e impostata come ItemsSource del DataGrid.
 * 
 * In breve, questo progetto consente agli utenti di inserire informazioni su di sé 
 * (nome, cognome, data di nascita), salva tali informazioni in un file di testo e 
 * consente loro di visualizzare gli utenti salvati in una tabella.*/
