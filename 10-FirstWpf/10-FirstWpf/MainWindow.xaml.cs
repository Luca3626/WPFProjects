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

/* Questa classe è come Window di Swing, la quale viene 
 * ereditata di JFrame.*/

namespace _10_FirstWpf
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


        /* sender è l'oggetto che ha generato l'evento. 
         * Su bottone ha creato automaticamente la proprietà Clik.*/
        private void Invia_Click(object sender, RoutedEventArgs e)
        {
            /* nome è ciò che abbiamo associato all'attributo 
             * x:Name del tag TextBox*/
            if (nome.Text == string.Empty)
            {
                /* MessageBox rappresenta le finestre di
                 * dialogo*/
                MessageBox.Show("Inserire il nome!");
            }
            else {
                MessageBox.Show($"Mi chiamo {nome.Text}");
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            /* Metodo che fa il clear di ciò che sta 
             * dentro la TextBox*/
            nome.Clear();

            /* Focus è un metodo che va a mettere il 
             * cursore nella TextBox. Il cursore va ad 
             * applicarsi a quella componente a cui 
             * abbiamo applicato il focus (nel nostro 
             * caso la TextBox).*/
            nome.Focus();
        }

        /* Metodo che va a gestire la chiusura della 
         * finestra.*/
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /* Lo inseriamo in una variabile MessageBoxResult di nome 
             * result perché il metodo Show ritorna un enumeratore.
             */
            MessageBoxResult result = MessageBox.Show("Vuoi chiudere l'applicazione?","FirstWpf",MessageBoxButton.YesNo);
      
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true; //cancella l'evento di chiusura della form. (Annullo l'evento)
            }

           
        }
    }
}
