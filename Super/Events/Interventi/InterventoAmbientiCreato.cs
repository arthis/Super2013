using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.Interventi
{
    [Serializable]
    public class InterventoAmbientiCreato
    {
        public int InterventoIdSuper { get; set; }
        public Guid IdAreaIntervento { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public int Quantita { get; set; }
        public string Descrizione { get; set; }
    }
}
