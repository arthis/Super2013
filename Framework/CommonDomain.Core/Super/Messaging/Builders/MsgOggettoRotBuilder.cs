using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core.Super.Messaging.ValueObjects;


namespace CommonDomain.Core.Super.Messaging.Builders
{
    public class MsgOggettoRotBuilder
    {
        Guid _idTipoOggettoInterventoRot;
        int _quantity;
        string _description;
        private Guid _idGruppoOggettoIntervento;

        public MsgOggettoRotBuilder OfQuantity(int value)
        {
            _quantity = value;
            return this;
        }

        public MsgOggettoRotBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public MsgOggettoRotBuilder OfType(Guid idTipoOggettoInterventoRot)
        {
            _idTipoOggettoInterventoRot = idTipoOggettoInterventoRot;
            return this;
        }

        public MsgOggettoRotBuilder ForGruppo(Guid idGruppoOggettoInterventoRot)
        {
            _idGruppoOggettoIntervento = idGruppoOggettoInterventoRot;
            return this;
        }

        public OggettoRot Build()
        {
            return new OggettoRot(_description, _quantity, _idTipoOggettoInterventoRot,_idGruppoOggettoIntervento);
        }
       
    }
}
