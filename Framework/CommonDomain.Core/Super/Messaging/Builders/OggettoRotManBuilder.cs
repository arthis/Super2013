using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core.Super.Messaging.ValueObjects;


namespace CommonDomain.Core.Super.Messaging.Builders
{
    public class OggettoRotManBuilder
    {
        Guid _idTipoOggettoInterventoRot;
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

        public OggettoRotManBuilder OfType(Guid idTipoOggettoInterventoRot)
        {
            _idTipoOggettoInterventoRot = idTipoOggettoInterventoRot;
            return this;
        }

        public OggettoRotManBuilder ForGruppo(Guid idGruppoOggettoInterventoRot)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoInterventoRot;
            return this;
        }


        public OggettoRotMan Build()
        {
            return new OggettoRotMan(_description, _quantity, _idTipoOggettoInterventoRot,_idGruppoOggettoIntervento);
        }
       
    }
}
