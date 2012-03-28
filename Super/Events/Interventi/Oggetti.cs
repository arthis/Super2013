using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.Interventi
{
    public class OggettoRot
    {
        public int Quantita { get; set; }
        public string Descrizione { get; set; }
        public Guid IdTipoOggettoInterventoRot { get; set; }
    }

    public class OggettoRotMan
    {
        public int Quantita { get; set; }
        public string Descrizione { get; set; }
        public Guid IdTipoOggettoInterventoRotMan { get; set; }
    }
}
