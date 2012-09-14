using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Schedulazione
{
    public class CreateSchedulazioneAmbBuilder : ICommandBuilder<CreateSchedulazioneAmb>
    {
        protected Guid _idPeriodoProgrammazione;
        protected Guid _idSchedulazione;
        protected Guid _idCommittente;
        protected Guid _idLotto;
        protected Guid _idImpianto;
        protected Guid _idTipoIntervento;
        protected Guid _idAppaltatore;
        protected Guid _idCategoriaCommerciale;
        protected Guid _idDirezioneRegionale;
        protected string _note;
        protected WorkPeriod _workPeriod;
        private int _quantity;
        private string _description;
        private Period _period;

        public CreateSchedulazioneAmbBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public CreateSchedulazioneAmbBuilder ForSchedulazione(Guid idSchedulazione)
        {
            _idSchedulazione = idSchedulazione;
            return this;
        }

        public CreateSchedulazioneAmbBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public CreateSchedulazioneAmbBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public CreateSchedulazioneAmbBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public CreateSchedulazioneAmbBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public CreateSchedulazioneAmbBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public CreateSchedulazioneAmbBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public CreateSchedulazioneAmbBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public CreateSchedulazioneAmbBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public CreateSchedulazioneAmbBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public CreateSchedulazioneAmbBuilder ForPeriod(Period period)
        {
            _period = period;
            return this;
        }


        public CreateSchedulazioneAmbBuilder ForQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public CreateSchedulazioneAmbBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public CreateSchedulazioneAmb Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateSchedulazioneAmb Build(Guid id, Guid commitId, long version)
        {
            return new CreateSchedulazioneAmb(id,
                                                commitId,
                                                version,
                                                _idPeriodoProgrammazione,
                                                _idSchedulazione,
                                                _idCommittente,
                                                _idLotto,
                                                _idImpianto,
                                                _idTipoIntervento,
                                                _idAppaltatore,
                                                _idCategoriaCommerciale,
                                                _idDirezioneRegionale,
                                                _workPeriod,
                                                _period,
                                                _note,
                                                _quantity,
                                                _description);
        }
    }
}