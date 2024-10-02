using System;
using System.Collections.Generic;
using System.Data;
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

namespace _18_AdoRubrica
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            griglia.ItemsSource = DaoContatto.LoadContatti();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            /* La griglia ha un insieme di oggetti del tipo DataView poiché 
             * abbiamo applicato la proprietà ItemSource della griglia 
             * con DataV ((che è una collection del tipo DataRowView))*/

            List<int> ids = new();
            foreach (DataRowView riga in griglia.SelectedItems) //Qui non usiamo griglia.Items ma griglia.SelectedItems che va a lavorare sugli elementi selezionati
            {
                /* siccome riga e di tipo collection, posso accedere agli
                 * elementi con le []*/
                ids.Add(int.Parse(riga["IdContatti"].ToString()));
            }
            DaoContatto.DeleteContatti(ids);
            griglia.ItemsSource = DaoContatto.LoadContatti();
        }
    }
}
