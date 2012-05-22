using System;

namespace Super.Appaltatore.Commands
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
