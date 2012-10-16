using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Appaltatore.Events.Programmazione;

namespace Super.Appaltatore.Events.Builders
{
    public class InterventoAmbProgrammatoBuilder : IEventBuilder<InterventoAmbProgrammato>
    {
        private string _description;
        private Guid _idAppaltatore;
        private Guid _idCategoriaCommerciale;
        private Guid _idDirezioneRegionale;
        private Guid _idImpianto;
        private Guid _idTipoIntervento;
        private string _note;
        private WorkPeriod _period;
        private int _quantity;

        #region IEventBuilder<InterventoAmbProgrammato> Members

        public InterventoAmbProgrammato Build(Guid id, long version)
        {
            return new InterventoAmbProgrammato(id, Guid.NewGuid(),
                                                version,
                                                _idImpianto,
                                                _idTipoIntervento,
                                                _idAppaltatore,
                                                _idCategoriaCommerciale,
                                                _idDirezioneRegionale,
                                                _period,
                                                _note,
                                                _quantity,
                                                _description);
        }

        #endregion

        public InterventoAmbProgrammatoBuilder ForWorkPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }

        public InterventoAmbProgrammatoBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
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

        public InterventoAmbProgrammatoBuilder ForQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public InterventoAmbProgrammatoBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }
    }
}