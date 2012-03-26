using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.Interventi
{
    [Serializable]
    public class OggettoInterventoRotAdded
    {
        public string Descrizione { get; set; }
        public int Quantita { get; set; }
        public Guid IdTipoOggettoInterventoRot { get; set; }
    }
}
