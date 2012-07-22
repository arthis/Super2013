using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Programmazione.Events.Builders
{

    public class InterventoAmbGeneratedBuilder : IEventBuilder<InterventoAmbGenerated>
    {
        private Guid _idImpianto;
        private Guid _idTipoIntervento;
        private Guid _idAppaltatore;
        private Guid _idCategoriaCommerciale;
        private Guid _idDirezioneRegionale;
        private WorkPeriod _period;
        private string _note;
        private int _quantity;
        private string _description;


        public InterventoAmbGeneratedBuilder ForQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public InterventoAmbGeneratedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public InterventoAmbGeneratedBuilder ForPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }

        public InterventoAmbGeneratedBuilder OfType(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public InterventoAmbGeneratedBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public InterventoAmbGeneratedBuilder OfCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public InterventoAmbGeneratedBuilder OfDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public InterventoAmbGeneratedBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public InterventoAmbGeneratedBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public InterventoAmbGenerated Build(Guid id, long version)
        {
            var cmd = new InterventoAmbGenerated(id, Guid.NewGuid(), version,
                                      _idImpianto,
                                      _idTipoIntervento,
                                      _idAppaltatore,
                                      _idCategoriaCommerciale,
                                      _idDirezioneRegionale,
                                      _period,
                                      _note,
                                      _quantity,
                                      _description);

            return cmd;
        }

    }
}
