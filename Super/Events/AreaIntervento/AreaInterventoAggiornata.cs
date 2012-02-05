using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.AreaIntervento
{
    [Serializable]
    public class AreaInterventoAggiornata
    {
        public Guid Id { get; set; }
        public int IdAreaInterventoSuper { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime? Fine { get; set; }
        public string Descrizione { get; set; }
    }
}
