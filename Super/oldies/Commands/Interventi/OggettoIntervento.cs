using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commands.Interventi
{
    public abstract class OggettoIntervento
    {
        public string Descrizione { get; set; }
        public int Quantita { get; set; }

    }

    public class OggettoRot : OggettoIntervento
    {
        public Guid IdTipoOggettoInterventoRot { get; set; }
    }

    public class OggettoRotMan : OggettoIntervento
    {
        public Guid IdTipoOggettoInterventoRotMan { get; set; }
    }
}
