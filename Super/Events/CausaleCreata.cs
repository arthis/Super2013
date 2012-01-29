using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events
{
    [Serializable]
    public class CausaleCreata
    {
        public string Tipo { get; set; }
        public string Mnemo { get; set; }
        public string Descrizione { get; set; }
        public Guid IdSettoreIntervento { get; set; }
    }
}
