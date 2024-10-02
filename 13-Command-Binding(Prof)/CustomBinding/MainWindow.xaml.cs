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

namespace CustomBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, string> keys = new()
        {
            {"Figura1","figura1.jpg" },
            {"Figura2","figura2.jpg" },
            {"Figura3","figura3.jpg" },

        };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CommandClose_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandClose_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void CommandImg_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandImg_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MenuItem? obj = e.Source as MenuItem;
            obj.IsChecked = true;
            string name_current = obj.Name;
            foreach (MenuItem item in pannello.Items)
            {
                if (item.Name != name_current)
                    item.IsChecked = false;
            }
            img.Source = new BitmapImage(new Uri($"/Images/{keys[name_current]}",UriKind.RelativeOrAbsolute));


        }
    }
}