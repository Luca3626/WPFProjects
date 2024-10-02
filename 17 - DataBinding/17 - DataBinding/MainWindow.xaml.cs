using System.Collections.ObjectModel;
using System.Configuration;
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

namespace _17___DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private List<User> users;
        private ObservableCollection<User>? users;
        /* ObservableCollection è una classe che estende Collection<T>
         * (che a sua volta estende IEnumerable<T>; questo significa 
         * che eredita tutte le funzionalità di Collection<T> e di 
         * IEnumerable<T>, comprese le operazioni di aggiunta, rimozione 
         * e iterazione sugli elementi della collezione.)
         * e implementa l'interfaccia INotifyCollectionChanged.
         * INotifyCollectionChanged consente di notificare quando la 
         * collezione viene modificata (elementi aggiunti, rimossi, 
         * ordinati, ecc.). Un ObservableCollection<User> è particolarmente 
         * utile in scenari legati a interfaccia utente (come WPF) 
         * perché notifica automaticamente la GUI quando la collezione 
         * cambia, in modo che la visualizzazione possa essere aggiornata 
         * di conseguenza.
         * In sostanza, la modifica da List<User> a ObservableCollection<User>
         * rende il tuo elenco di utenti "osservabile" dalla tua interfaccia 
         * utente. Ciò significa che se vengono apportate modifiche alla 
         * raccolta, la tua interfaccia utente sarà automaticamente informata 
         * di tali modifiche e sarà in grado di rifletterle dinamicamente 
         * senza richiedere interventi manuali. Questo è particolarmente 
         * utile quando lavori con tecnologie legate a dati in tempo reale, 
         * come WPF, in cui le modifiche nella raccolta devono essere riflesse 
         * automaticamente nell'interfaccia utente.




*/

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            users = new()
            {
                new()
                {
                Nome_Cognome = "Mario Rossi"
                },
                new()
                {
                Nome_Cognome = "Mario Verdi"
                },
                new()
                {
                Nome_Cognome = "Mario Esposito"
                }
            };
            /* Questa riga di codice qui sotto:*/
            lst.ItemsSource = users;
            /* è responsabile di impostare la proprietà ItemsSource 
             * del nostro controllo ListBox (lst) sull'istanza della 
             * lista users. In WPF, ItemsSource è una proprietà che 
             * determina la raccolta di dati che verrà utilizzata per 
             * popolare il controllo che la ospita (nel nosotr caso, 
             * una ListBox). Quando ItemsSource viene assegnato a una 
             * raccolta di dati, il controllo WPF associa dinamicamente 
             * gli elementi della raccolta ai controlli figlio del controllo 
             * che supporta l'associazione dati. Nel nostro codice, 
             * users è una lista di oggetti User. Quando assegniamo 
             * users a lst.ItemsSource, stiamo dicendo al ListBox di 
             * utilizzare gli oggetti nella lista users come dati da 
             * visualizzare. In questo modo, ogni oggetto User nella 
             * lista verrà rappresentato come un elemento nella ListBox, 
             * e la proprietà Nome_Cognome di ciascun oggetto User sarà 
             * utilizzata per visualizzare il testo di ogni elemento nella 
             * lista.*/
        }

        private void Click_Add(object sender, RoutedEventArgs e)
        {
            users.Add(new User { Nome_Cognome = "New User" });
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //(lst.SelectedItem as User).Nome_Cognome = "Update User";
            /* Sto andando a modificare la proprietà Nome_Cognome 
             * dell'oggetto selezionato sulla lista della listbox. 
             * Ma ancora non funziona. Deve generare un evento nel 
             * momento in cui cambia la proprietà. Usiamo un'interfaccia 
             * che ha un evento col quale possiamo gestire la modifica 
             * delle proprietà. Andiamo nella classe User e facciamo sì 
             * che erediti INotifyPropertyChanged.*/

            /* Usiamo il SelectedItems invece del SelectedItem per cambiare 
             * più elementi insieme*/
            foreach(User us in lst.SelectedItems) 
            {
                us.Nome_Cognome = "Update user";
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var us = lst.SelectedItems;
            while(us.Count != 0) 
            {
                users.RemoveAt(lst.SelectedIndex);
            }
        }
    }
}