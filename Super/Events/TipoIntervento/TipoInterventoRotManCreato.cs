using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.TipoIntervento
{
    [Serializable]
    public class TipoInterventoRotManCreato
    {
        public Guid Id { get; set; }
        public int IdTipoInterventoSuper { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime? Fine { get; set; }
        public DateTime CreationDate { get; set; }
        public string Descrizione { get; set; }
    }
}
