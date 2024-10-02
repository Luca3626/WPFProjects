using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace DynamicGrid
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
            string[] arr = ["7", "8", "9", "4", "5", "6", "1", "2", "3", "C", "0", "MOSTRA" ];
            /*
               imposto la RowDefinitions per ler righe 
             */
            for (int i = 0; i < 4; i++)
            {
                var row=new RowDefinition();
                row.Height=new GridLength(1, GridUnitType.Star); // height="*"
                griglia.RowDefinitions.Add(row);
            }
            /*
               imposto la ColDefinitions per ler righe 
             */
            for (int i = 0;i<3;++i)
            {
                var col = new ColumnDefinition();
                col.Width = new GridLength(1, GridUnitType.Star);
                griglia.ColumnDefinitions.Add(col);
            }
         
            int indice = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button btn = new Button();
                    btn.Content = arr[indice++];
                    Grid.SetColumn(btn, j);// imposto la proprietà Grid.Column=j di btn (bottone corrente) 
                    Grid.SetRow(btn,i);    // imposto la proprietà Grid.Row=i di btn (bottone corrente) 
                    btn.Click += Btn_click;
                    griglia.Children.Add(btn);  
                }
            }
            /*
            //ciclo la griglia con name=griglia
            foreach (Button btn in griglia.Children)
            {
                btn.Click += Btn_click;
            }
            */


        }
        private void Btn_click(object sender, RoutedEventArgs e)
        {
            Button? btn = sender as Button;
            switch(btn?.Content)
            {
                case "MOSTRA":
                    MessageBox.Show(txtPwd.Password);
                    break;
                case "C":
                    txtPwd.Clear();
                    break;
                default:
                    txtPwd.Password+=btn.Content.ToString();
                    break;
                     
            
            }

        }
    }
}