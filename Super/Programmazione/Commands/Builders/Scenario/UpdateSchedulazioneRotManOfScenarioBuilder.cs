using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Scenario
{
    public class UpdateSchedulazioneRotManOfScenarioBuilder : ICommandBuilder<UpdateSchedulazioneRotManOfScenario>
    {
        protected Guid _idPeriodoProgrammazione;
        protected Guid _idScenario;
        protected Guid _idCommittente;
        protected Guid _idLotto;
        protected Guid _idImpianto;
        protected Guid _idTipoIntervento;
        protected Guid _idAppaltatore;
        protected Guid _idCategoriaCommerciale;
        protected Guid _idDirezioneRegionale;
        protected string _note;
        protected WorkPeriod _workPeriod;
        private OggettoRotMan[] _oggetti;

        public UpdateSchedulazioneRotManOfScenarioBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public UpdateSchedulazioneRotManOfScenarioBuilder ForScenario(Guid idScenario)
        {
            _idScenario = idScenario;
            return this;
        }

        public UpdateSchedulazioneRotManOfScenarioBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public UpdateSchedulazioneRotManOfScenarioBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public UpdateSchedulazioneRotManOfScenarioBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public UpdateSchedulazioneRotManOfScenarioBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public UpdateSchedulazioneRotManOfScenarioBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public UpdateSchedulazioneRotManOfScenarioBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public UpdateSchedulazioneRotManOfScenarioBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public UpdateSchedulazioneRotManOfScenarioBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public UpdateSchedulazioneRotManOfScenarioBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public UpdateSchedulazioneRotManOfScenarioBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public UpdateSchedulazioneRotManOfScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateSchedulazioneRotManOfScenario Build(Guid id, Guid commitId, long version)
        {
            return new UpdateSchedulazioneRotManOfScenario(id,
                                                           commitId,
                                                           version,
                                                           _idPeriodoProgrammazione,
                                                           _idScenario,
                                                           _idCommittente,
                                                           _idLotto,
                                                           _idImpianto,
                                                           _idTipoIntervento,
                                                           _idAppaltatore,
                                                           _idCategoriaCommerciale,
                                                           _idDirezioneRegionale,
                                                           _workPeriod,
                                                           _note,
                                                           _oggetti);
        }
    }
}