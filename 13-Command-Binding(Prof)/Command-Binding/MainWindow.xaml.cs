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

namespace Command_Binding
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

        private void CommandCopy_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = txtTesto != null && txtTesto.SelectionLength != 0;
        }

        private void CommandCopy_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtTesto.Copy();
        }

        private void CommandCut_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = txtTesto != null && txtTesto.SelectionLength != 0;
        }

        private void CommandCut_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtTesto.Cut();
        }

        private void CommandPaste_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Clipboard.ContainsText();

        }

        private void CommandPaste_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtTesto.Paste();
        }
    }
}