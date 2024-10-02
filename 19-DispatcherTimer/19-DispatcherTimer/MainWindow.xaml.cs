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
using System.Windows.Threading;

namespace _19_DispatcherTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> citta;
        private DispatcherTimer timer;
        private int indice = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            citta = new()
            {
                "Roma",
                "Napoli",
                "Milano",
                "Torino",
                "Venezia" 
            };

            timer = new();

            /* Interval una property a cui possiamo assegnare un  
             * TimeSpan. TimeSpan ha un metodo statico che si 
             * chiama FromSecond. Assegniamo 1 a FromSecond. 
             * Quindi, ogni secondo deve svolgere un'operazione.*/
            timer.Interval = TimeSpan.FromSeconds(1);

            //Gli passiamo il delegate dichiarando un nuovo
            //oggetto EventHandler, a cui assegniamo la nostra
            //funzione personalizzata.
            timer.Tick += new EventHandler( (sender, e) => {
                txt.Text = citta[indice++];
                if (indice >= citta.Count())
                    indice = 0;
            } );
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            indice = 0;
            txt.Text = string.Empty;
        }
    }
}