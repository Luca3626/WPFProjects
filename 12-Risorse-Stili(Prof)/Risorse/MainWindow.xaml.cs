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

namespace Risorse
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

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            string? risorsa_globale = Application.Current.FindResource("resource_global") as string;
            //  string? risorsa_globale = (string) Application.Current.FindResource("resource_global");
            string? risorsa_window = this.FindResource("resource_window") as string;
            string? risorsa_local = pannello.FindResource("resource_local") as string;

            lst.Items.Clear();
            lst.Items.Add(risorsa_globale);
            lst.Items.Add(risorsa_window);
            lst.Items.Add(risorsa_local);

            string[]? arr = pannello.FindResource("voci") as string[];
            //combo.SelectedItem = arr[0];
            //combo.SelectedIndex = 0;
            string s = string.Empty;
            foreach (var item in arr)
            {
                s += $"{item} ";
            }
            MessageBox.Show(s);

        }
    }
}