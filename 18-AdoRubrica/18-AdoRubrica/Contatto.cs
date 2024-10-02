using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_AdoRubrica
{
    internal class Contatto
    {
        public int IdContatto { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }

        public DateOnly Data_Nascita {  get; set; }
        public string? Citta { get; set; }
        //public int IdNazione { get; set; }
        /* Come facevamo in Hibernate, gli passiamo 
         * un oggetto Nazione*/
        public Nazione? Nazione { get; set; }
    }
}
