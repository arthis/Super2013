using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Schedulazione
{
    public class CreateSchedulazioneRotManBuilder : ICommandBuilder<CreateSchedulazioneRotMan>
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
        protected Period _period;
        private OggettoRotMan[] _oggetti;

        public CreateSchedulazioneRotManBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public CreateSchedulazioneRotManBuilder ForSchedulazione(Guid idSchedulazione)
        {
            _idSchedulazione = idSchedulazione;
            return this;
        }

        public CreateSchedulazioneRotManBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public CreateSchedulazioneRotManBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public CreateSchedulazioneRotManBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public CreateSchedulazioneRotManBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public CreateSchedulazioneRotManBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public CreateSchedulazioneRotManBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public CreateSchedulazioneRotManBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public CreateSchedulazioneRotManBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public CreateSchedulazioneRotManBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public CreateSchedulazioneRotManBuilder ForPeriod(Period period)
        {
            _period = period;
            return this;
        }

        public CreateSchedulazioneRotManBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public CreateSchedulazioneRotMan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateSchedulazioneRotMan Build(Guid id, Guid commitId, long version)
        {
            return new CreateSchedulazioneRotMan(id,
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
                                                        _oggetti);
        }
    }
}