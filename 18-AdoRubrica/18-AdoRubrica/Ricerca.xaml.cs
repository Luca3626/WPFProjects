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

namespace _18_AdoRubrica
{
    /// <summary>
    /// Logica di interazione per Ricerca.xaml
    /// </summary>
    public partial class Ricerca : Window
    {
        public Ricerca()
        {
            
            InitializeComponent();
            
        }

        private void comRicerca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            int id = int.Parse((sender as ComboBox).SelectedValue.ToString());
            grigliaRicerca.ItemsSource = DaoContatto.Ricerca(id);
            */
            int id = int.Parse(comRicerca.SelectedValue.ToString());

            grigliaRicerca.ItemsSource = DaoContatto.LoadContattiprocedure(id, out string conta);
            txtConta.Text = conta;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var nazioni = DaoNazione.LoadNazioni();
            comRicerca.ItemsSource = nazioni;
            

        }
    }
}
