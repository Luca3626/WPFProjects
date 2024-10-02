using _18_AdoRubrica;
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

namespace AdoGenerico
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
                var tabelle = Dao.LoadTabelle();
                com.ItemsSource = tabelle;
                griglia.ItemsSource = Dao.LoadTabelle();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void com_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string? nomi = com.SelectedValue.ToString();
            if (nomi == "Nazioni")
            {
                
                griglia.ItemsSource = Dao.LoadNazioni();
            }
            else 
            {
                
                griglia.ItemsSource = Dao.LoadContatti();
            }
        }
    }
}