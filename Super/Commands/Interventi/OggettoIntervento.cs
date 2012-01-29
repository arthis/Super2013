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

    public class OggettoInterventoRotabile : OggettoIntervento
    {
        public Guid IdTipoOggettoInterventoRotabile { get; set; }
    }

    public class OggettoInterventoRotabileInManutenzione : OggettoIntervento
    {
        public Guid IdTipoOggettoInterventoRotabileInManutenzione { get; set; }
    }
}
