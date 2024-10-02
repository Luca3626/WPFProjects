using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17___DataBinding
{
    /* INotifyPropertyChanged è un'interfaccia definita nel 
     * namespace System.ComponentModel del .NET Framework. 
     * Essa fornisce un meccanismo standard per notificare 
     * agli ascoltatori (tipicamente l'interfaccia utente) 
     * che una proprietà di un oggetto è stata modificata. 
     * Questo è particolarmente utile in scenari in cui si 
     * utilizza il data-binding, come in applicazioni WPF 
     * (Windows Presentation Foundation). Quando implementi 
     * INotifyPropertyChanged in una classe come User, stai 
     * essenzialmente dichiarando che questa classe è in grado 
     * di notificare agli ascoltatori (ad esempio, nel nostro
     * caso, la listbox lst che mostra la lista utenti) quando 
     * una delle sue proprietà cambia di valore. Ciò è importante 
     * perché in un'applicazione WPF, quando associ una proprietà 
     * di un oggetto (come User.Nome_Cognome) a un controllo UI 
     * (come un TextBlock o una casella di testo), desideri che 
     * il controllo UI si aggiorni automaticamente quando il 
     * valore della proprietà cambia. Senza INotifyPropertyChanged, 
     * il controllo UI non sarebbe consapevole dei cambiamenti 
     * nella proprietà e non si aggiornerebbe di conseguenza.
     * Implementando INotifyPropertyChanged, ogni volta che 
     * viene modificato il valore di User.Nome_Cognome (attraverso 
     * il data-binding o in altro modo), User notificherà agli 
     * ascoltatori (in questo caso, la UI) che la proprietà è 
     * stata modificata, permettendo alla UI di aggiornarsi di 
     * conseguenza.
     * In sintesi, abbiamo implementato INotifyPropertyChanged 
     * nella classe User perché desideriamo che la UI reagisca 
     * dinamicamente ai cambiamenti nei dati degli utenti, 
     * consentendo un'esperienza utente più reattiva e coerente 
     * quando si utilizza il data-binding in WPF.*/
    internal class User : INotifyPropertyChanged 
    {
        //public string? Nome_Cognome { get; set; }
        private string? nome_cognome;
        public string? Nome_Cognome
        {
            get => nome_cognome;
            set {
                nome_cognome = value;

                //deve eseguire PropertuChangedEventHandler PropertyChange
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("nome_cognome"));
            }
        }


        /* PropertyChangedEventHandler è il delegate associato 
         * all'evento che viene lanciato.*/
        public event PropertyChangedEventHandler? PropertyChanged;
        /* PropertyChanged è un evento dell'interfaccia INotifyPropertyChanged. 
         * Questo evento viene utilizzato nelle applicazioni WPF per notificare 
         * agli ascoltatori, di solito gli elementi dell'interfaccia utente (UI), 
         * che una proprietà di un oggetto è stata modificata. Ecco come funziona:
         * - Implementazione dell'interfaccia INotifyPropertyChanged: Quando una 
         *   classe implementa l'interfaccia INotifyPropertyChanged, deve fornire 
         *   un evento PropertyChanged che viene attivato quando una proprietà di 
         *   un oggetto della classe viene modificata.
         * - Firing dell'evento PropertyChanged: Quando il valore di una proprietà 
         *   viene modificato, il codice dell'oggetto deve attivare l'evento  
         *   PropertyChanged, fornendo il nome della proprietà che è stata modificata 
         *   come parametro. Questo è spesso fatto all'interno del setter della 
         *   proprietà stessa.
         * - Registrazione degli ascoltatori: Gli elementi dell'interfaccia utente 
         *   (UI), come i controlli WPF, possono registrarsi per ascoltare l'evento 
         *   PropertyChanged degli oggetti che desiderano monitorare. Di solito questo 
         *   avviene durante il binding delle proprietà dell'oggetto UI alle proprietà 
         *   dell'oggetto sorgente dei dati.
         * - Aggiornamento dell'UI: Quando viene attivato l'evento PropertyChanged, 
         *   gli ascoltatori, ossia gli elementi dell'interfaccia utente che si sono 
         *   registrati per ricevere notifiche sui cambiamenti delle proprietà, 
         *   ricevono l'evento e possono agire di conseguenza. Di solito, questo 
         *   comporta l'aggiornamento dell'elemento dell'interfaccia utente per 
         *   riflettere il nuovo valore della proprietà modificata.
         * Ecco un esempio semplificato di come viene utilizzato l'evento PropertyChanged:
         * 
         * // Classe che implementa l'interfaccia INotifyPropertyChanged
         * public class Person : INotifyPropertyChanged
         * {
         *     private string name;
         *     public string Name
         *     {
         *         get { return name; }
         *         set
         *         {
         *              if (value != name)
         *              {
         *                  name = value;
         *                  OnPropertyChanged("Name");
         *              }
         *         }
         *     }
         * 
         *     public event PropertyChangedEventHandler PropertyChanged;
         *     protected virtual void OnPropertyChanged(string propertyName)
         *     {
         *         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
         *     }
         * }
         * 
         * 
         * // Esempio di utilizzo
         * var person = new Person();
         * person.PropertyChanged += (sender, e) =>
         * {
         *     if (e.PropertyName == "Name")
         *     {
         *         // Aggiorna l'UI in base al nuovo valore della proprietà Name
         *         Console.WriteLine("Il nome è stato modificato!");
         *     }
         * };
         * person.Name = "Nuovo nome"; // Questo attiva l'evento PropertyChanged
         * 
         * In questo esempio, quando il valore della proprietà Name viene modificato, 
         * viene attivato l'evento PropertyChanged, e qualsiasi oggetto che si è 
         * registrato per ascoltare questo evento riceverà la notifica e potrà aggiornare 
         * di conseguenza l'interfaccia utente.*/
    }
}
