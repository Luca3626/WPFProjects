using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _18_AdoRubrica
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try 
            {
                DaoConnection.Connessione();
                foreach (MenuItem item in menu.Items) 
                {
                    //stiamo prendendo tutti i menu item all'interno del
                    //menu item col name = menu
                    item.Click += GestioneMenu;
                }
            }
            catch (Exception e1) 
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void GestioneMenu(object sender, RoutedEventArgs e) 
        {
            MenuItem item = (MenuItem)e.Source;
            //Oppure in maniera equivalente potremmo scrivere: 
            //MenuItem item = sender as MenuItem
            //Questo ci serve per prendere l'elemento item 

            /* Qui usiamo le proprietà del poliformismo, dato che 
             * tutte le finestre che verranno aperte dal menù item, 
             * (Inserimento, Visualizza,...) ereditano dalla classe 
             * Window*/
            Window fin = null;
            switch (item.Header) 
            {
                case "Inserimento":
                    fin = new Inserimento();
                    break;
                case "Visualizza":
                    fin = new Visualizza();
                    break;
                case "Ricerca":
                    fin = new Ricerca();
                    break;
                case "Esci":
                    this.Close();
                    break;
            }

            //Owner ci dice la finestra di cui l'oggetto Inserimento o
            //Visualizza sono figli
            fin.Owner = this;

            //Qui sotto inserisce le finestre Inserimento e Visualizzazione
            //al centro della finestra padre (CenterOwner), ovvero
            //MainWindow.
            fin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            fin.ResizeMode = ResizeMode.NoResize;
            fin.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Vuoi uscire dal programma?", "RubricaAdo", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                DaoConnection.CloseConnection();
                System.Environment.Exit(0);
            }
            //Il Cancel cancella l'evento (in questo caso la chiusura)
            e.Cancel = true;
        }
    }
}