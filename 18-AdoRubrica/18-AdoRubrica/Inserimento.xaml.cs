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
    /// Logica di interazione per Inserimento.xaml
    /// </summary>
    public partial class Inserimento : Window
    {
        public Inserimento()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var nazioni = DaoNazione.LoadNazioni();
            //var nazioni = DaoNazione.GetNazioni();
            comNazioni.ItemsSource = nazioni;
        }

        private void btnSalva_Click(object sender, RoutedEventArgs e)
        {
            DaoContatto.SaveContatto(new()
            {
                Nome = txtNome.Text,
                Cognome = txtCognome.Text,
                Data_Nascita = DateOnly.Parse(txtNascita.Text),
                Citta = txtCitta.Text,
                Nazione = new() 
                {
                    IdNazione = int.Parse(comNazioni.SelectedValue.ToString())

                }
            });
            Reset();
        }

        public void Reset() 
        {
            //foreach(UIElement item in griglia.Childern)
            foreach (var item in griglia.Children)
            {
                if (item is TextBox)
                    (item as TextBox).Clear();
                else if (item is DatePicker)
                {
                    (item as DatePicker).Text = string.Empty;
                }
                else if (item is ComboBox) 
                {
                    (item as ComboBox).Text = string.Empty;
                }
            }
        }
    }
}
