using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core.Super.Messaging.ValueObjects;


namespace CommonDomain.Core.Super.Messaging.Builders
{
    public class OggettoRotBuilder
    {
        Guid _idTipoOggettoInterventoRot;
        int _quantity;
        string _description;

        public OggettoRotBuilder OfQuantity(int value)
        {
            _quantity = value;
            return this;
        }

        public OggettoRotBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public OggettoRotBuilder OfType(Guid idTipoOggettoInterventoRot)
        {
            _idTipoOggettoInterventoRot = idTipoOggettoInterventoRot;
            return this;
        }


        public OggettoRot Build()
        {
            return new OggettoRot(_description, _quantity, _idTipoOggettoInterventoRot);
        }
       
    }
}
