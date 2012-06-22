using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core.Super.Messaging.Builders;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Appaltatore.Events.Programmazione;

namespace Super.Appaltatore.Events.Builders
{

    public class InterventoAmbProgrammatoBuilder
    {
        private Guid _id;
        private Guid _idAreaIntervento;
        private Guid _idTipoIntervento;
        private Guid _idAppaltatore;
        private Guid _idCategoriaCommerciale;
        private Guid _idDirezioneRegionale;
        private WorkPeriod _period;
        private string _note;
        private  int _quantity;
        private string _description;


        public InterventoAmbProgrammatoBuilder ForPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }

        public InterventoAmbProgrammatoBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

        public InterventoAmbProgrammatoBuilder ForArea(Guid idAreaIntervento)
        {
            _idAreaIntervento = idAreaIntervento;
            return this;
        }

        public InterventoAmbProgrammatoBuilder OfType(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public InterventoAmbProgrammatoBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public InterventoAmbProgrammatoBuilder OfCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public InterventoAmbProgrammatoBuilder OfDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public InterventoAmbProgrammatoBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public InterventoAmbProgrammatoBuilder WithQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public InterventoAmbProgrammatoBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

 

        public InterventoAmbProgrammato Build()
        {
            return new InterventoAmbProgrammato(_id,
                                      _idAreaIntervento,
                                      _idTipoIntervento,
                                      _idAppaltatore,
                                      _idCategoriaCommerciale,
                                      _idDirezioneRegionale,
                                      _period,
                                      _note,
                                      _quantity,
                                      _description);
        }

    }
}
