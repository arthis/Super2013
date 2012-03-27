using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interventi.Consuntivazione
{
    public interface IOggettoInterventoRotContainer
    {
        IEnumerable<OggettoInterventoRot> Oggetti { get; }
        void AddOggetto(string descrizione, Guid idTipoOggettoInterventoRot, int quantita);
    }

    public interface IOggettoInterventoRotManContainer
    {
        IEnumerable<OggettoInterventoRotMan> Oggetti { get; }
        void AddOggetto(string descrizione, Guid idTipoOggettoInterventoRotMan, int quantita);
    }
}
