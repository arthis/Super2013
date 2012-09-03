using System;
using CommonDomain.Core.Super.Domain.ValueObjects;

namespace CommonDomain.Core.Super.Domain.Builders
{
    public class OggettoRotManBuilder
    {
        Guid _idTipoOggettoInterventoRotMan;
        int _quantity;
        string _description;
        private Guid _idGruppoOggettoIntervento;

        public OggettoRotManBuilder OfQuantity(int value)
        {
            _quantity = value;
            return this;
        }

        public OggettoRotManBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public OggettoRotManBuilder OfType(Guid idTipoOggettoInterventoRotMan)
        {
            _idTipoOggettoInterventoRotMan = idTipoOggettoInterventoRotMan;
            return this;
        }

        public OggettoRotManBuilder ForGruppo(Guid idGruppoOggettoIntervento)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
            return this;
        }


        public OggettoRotMan Build()
        {
            return new OggettoRotMan(_description, _quantity, _idTipoOggettoInterventoRotMan, _idGruppoOggettoIntervento);
        }

    }
}