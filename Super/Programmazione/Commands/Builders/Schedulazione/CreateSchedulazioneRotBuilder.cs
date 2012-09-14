using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Schedulazione
{
    public class CreateSchedulazioneRotBuilder : ICommandBuilder<CreateSchedulazioneRot>
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
        private OggettoRot[] _oggetti;
        private Treno _trenoPartenza;
        private Treno _trenoArrivo;
        private string _turnoTreno;
        private string _rigaTurnoTreno;
        private string _convoglio;
        private Period _period;

        public CreateSchedulazioneRotBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public CreateSchedulazioneRotBuilder ForSchedulazione(Guid idSchedulazione)
        {
            _idSchedulazione = idSchedulazione;
            return this;
        }

        public CreateSchedulazioneRotBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public CreateSchedulazioneRotBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public CreateSchedulazioneRotBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public CreateSchedulazioneRotBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public CreateSchedulazioneRotBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public CreateSchedulazioneRotBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public CreateSchedulazioneRotBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public CreateSchedulazioneRotBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public CreateSchedulazioneRotBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public CreateSchedulazioneRotBuilder ForPeriod(Period period)
        {
            _period = period;
            return this;
        }
        public CreateSchedulazioneRotBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public CreateSchedulazioneRotBuilder WithTrenoArrivo(Treno trenoArrivo)
        {
            _trenoArrivo = trenoArrivo;
            return this;
        }

        public CreateSchedulazioneRotBuilder WithTrenoPartenza(Treno trenoPartenza)
        {
            _trenoPartenza = trenoPartenza;
            return this;
        }

        public CreateSchedulazioneRotBuilder WithTurnoTreno(string turnoTreno)
        {
            _turnoTreno = turnoTreno;
            return this;
        }

        public CreateSchedulazioneRotBuilder WithRigaTurnoTreno(string rigaTurnoTreno)
        {
            _rigaTurnoTreno = rigaTurnoTreno;
            return this;
        }

        public CreateSchedulazioneRotBuilder ForConvoglio(string convoglio)
        {
            _convoglio = convoglio;
            return this;
        }

        public CreateSchedulazioneRot Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateSchedulazioneRot Build(Guid id, Guid commitId, long version)
        {
            return new CreateSchedulazioneRot(id,
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
                                                     _oggetti,
                                                     _trenoPartenza,
                                                     _trenoArrivo,
                                                     _turnoTreno,
                                                     _rigaTurnoTreno,
                                                     _convoglio);
        }
    }
}