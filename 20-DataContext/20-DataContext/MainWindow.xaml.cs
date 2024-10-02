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

namespace _20_DataContext
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //this.DataContext = this;
            //possiamo scrivere anche così:
            DataContext = this;
            /* Impostando con la property DataContext che il 
             * contesto è la finestra corrente, non abbiamo 
             * bisogno di impostare l'attributo ElementName 
             * all'interno dei tag impostati nella MainWindow:*/

        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            /* L'attributo UpdateSourceTrigger nel namespace 
             * binding nel file xaml ha i seguenti valori: 
             * 1- default: permette di aggiornare la proprietà 
             *    della componente di destinazione (nel nostro 
             *    caso la finestra) solo quando il controllo
             *    perde il focus. 
             * 2- PropertyChanged permette di aggiornare la 
             *    proprietà della componente ogni volta che 
             *    scriviamo il testo nella TextBox (componente 
             *    sorgente). 
             * 3- Explicit disabilita l'aggiornamento in modo 
             *    tale che il binding viene eseguito da codice. 
             *    Nel nostro caso quando clicchiamo sul bottone.*/
            BindingExpression bindingWidth = widthFin.GetBindingExpression(TextBox.TextProperty);

            bindingWidth.UpdateSource();
            
            heightFin.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            
            //this.Width = double.Parse(widthFin.Text);
        }
    }
}

/* 1) DataContext = this
 * 
 * L'istruzione this.DataContext = this; nel costruttore della 
 * classe MainWindow è un'assegnazione che imposta il contesto 
 * dei dati (DataContext) dell'istanza corrente della finestra 
 * (MainWindow) su se stessa.
 * In WPF (Windows Presentation Foundation), il contesto dei dati 
 * è un concetto fondamentale che permette di collegare gli 
 * elementi dell'interfaccia utente (UI) ai dati sottostanti. 
 * Il contesto dei dati è ciò a cui gli elementi dell'interfaccia 
 * utente si "collegano" per ottenere o visualizzare i dati.
 * Quando si imposta il contesto dei dati su this, si sta 
 * essenzialmente dicendo all'interfaccia utente della finestra 
 * di cercare i dati all'interno della stessa istanza della 
 * finestra (MainWindow). Questo significa che se hai proprietà 
 * pubbliche nella classe MainWindow, possono essere utilizzate 
 * per il binding negli elementi dell'interfaccia utente. 
 * Quando si utilizza DataContext = this;, non è necessario 
 * specificare l'attributo ElementName nei tag dei controlli 
 * all'interno della finestra XAML per riferirsi alla finestra 
 * stessa come contesto dei dati. In altre parole, invece di fare 
 * riferimento a un elemento specifico per ottenere il contesto 
 * dei dati tramite ElementName, si può semplicemente fare 
 * riferimento al contesto dei dati della finestra stessa.
 * Ecco un esempio per chiarire:
 * Senza impostare DataContext sulla finestra stessa nel codice 
 * dietro, potresti dover fare qualcosa del genere nel XAML:
 * 
 * <TextBox Text="{Binding ElementName=fin, Path=SomeProperty}" />
 * 
 * In questo caso, fin sarebbe il nome dell'elemento di cui si 
 * vuole ottenere il contesto dei dati. Ma se imposti DataContext = this; 
 * nel codice dietro, puoi omettere ElementName e fare semplicemente:
 * 
 * <TextBox Text="{Binding Path=SomeProperty}" />
 * 
 * Poiché il contesto dei dati è impostato sulla finestra stessa (this), 
 * i controlli all'interno della finestra possono accedere direttamente 
 * alle proprietà pubbliche della finestra senza specificare esplicitamente 
 * l'elemento tramite ElementName. 
 * ****************************************************************************
 * 
 * 2) Metodo btn_Click() 
 * 
 * Il metodo btn_Click è associato all'evento di clic del pulsante 
 * "Aggiorna" (btn). Questo metodo viene eseguito quando l'utente 
 * fa clic sul pulsante "Aggiorna" all'interno dell'interfaccia 
 * utente dell'applicazione. 
 * - private void btn_Click(object sender, RoutedEventArgs e): Questa 
 * è la firma del metodo che specifica i parametri del gestore evento 
 * clic. sender rappresenta l'oggetto che ha generato l'evento, nel 
 * nostro caso il pulsante "Aggiorna", mentre e contiene i dettagli 
 * dell'evento.
 * - BindingExpression bindingWidth = widthFin.GetBindingExpression(TextBox.TextProperty);: 
 * Qui viene ottenuta un'espressione di binding per la proprietà Text 
 * del TextBox widthFin. Questo permette di accedere al binding 
 * attualmente applicato al TextBox.
 * - bindingWidth.UpdateSource();: Questo metodo UpdateSource() viene 
 * chiamato sull'espressione di binding della larghezza (bindingWidth). 
 * Questo metodo forza l'aggiornamento della proprietà di origine del 
 * binding con il valore corrente della proprietà di destinazione del 
 * controllo. In sostanza, questo aggiorna il valore nella proprietà 
 * Width del contesto dei dati (presumibilmente la finestra principale) 
 * utilizzando il valore attuale del TextBox widthFin.
 * - heightFin.GetBindingExpression(TextBox.TextProperty).UpdateSource();: 
 * Qui viene eseguito un passaggio simile a quello sopra, ma per il TextBox 
 * heightFin. Viene ottenuta un'espressione di binding per la proprietà 
 * Text del TextBox heightFin, e poi viene chiamato UpdateSource() su di 
 * essa per aggiornare il valore della proprietà Height nel contesto dei dati.
 * //this.Width = double.Parse(widthFin.Text);: Questo è un commento che 
 * indica una possibile alternativa che è stata commentata. Questa linea 
 * di codice avrebbe impostato la larghezza della finestra (this.Width) 
 * utilizzando il valore testuale presente nel TextBox widthFin. Tuttavia, 
 * sembra che questa linea sia stata commentata e il valore della larghezza 
 * viene aggiornato tramite il binding come descritto sopra.
 * In sintesi, quando l'utente fa clic sul pulsante "Aggiorna", questo metodo 
 * assicura che i valori dei TextBox widthFin e heightFin vengano aggiornati 
 * nel contesto dei dati dell'applicazione, consentendo così un aggiornamento 
 * immediato delle dimensioni della finestra o di altri aspetti legati ai dati.*/