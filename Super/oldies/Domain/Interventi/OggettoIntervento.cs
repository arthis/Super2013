using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interventi
{
    public abstract class OggettoIntervento
    {
        public string Descrizione { get; set; }
        public int Quantita { get; set; }
        
    }

    public class OggettoInterventoRot : OggettoIntervento
    {
        public Guid IdTipoOggettoInterventoRot { get; set; }
    }

    public class OggettoInterventoRotMan : OggettoIntervento
    {
        public Guid IdTipoOggettoInterventoRotMan { get; set; }
    }

}
