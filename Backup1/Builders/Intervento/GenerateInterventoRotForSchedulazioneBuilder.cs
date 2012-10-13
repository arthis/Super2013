using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Intervento;

namespace Super.Programmazione.Commands.Builders.Intervento
{
    public class GenerateInterventoRotForSchedulazioneBuilder : ICommandBuilder<GenerateInterventoRotForSchedulazione>
    {
        protected Guid _idPeriodoProgrammazione;
        protected Guid _idProgram;
        private Guid _idSchedulazione;
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
        private Guid _idInterventoGeneration;


        public GenerateInterventoRotForSchedulazioneBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public GenerateInterventoRotForSchedulazioneBuilder ForProgram(Guid idProgram)
        {
            _idProgram = idProgram;
            return this;
        }

        public GenerateInterventoRotForSchedulazioneBuilder ForSchedulazione(Guid idSchedulazione)
        {
            _idSchedulazione = idSchedulazione;
            return this;
        }

        public GenerateInterventoRotForSchedulazioneBuilder ForInterventoGeneration(Guid idInterventoGeneration)
        {
            _idInterventoGeneration = idInterventoGeneration;
            return this;
        }

        public GenerateInterventoRotForSchedulazioneBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public GenerateInterventoRotForSchedulazioneBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public GenerateInterventoRotForSchedulazioneBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public GenerateInterventoRotForSchedulazioneBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public GenerateInterventoRotForSchedulazioneBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public GenerateInterventoRotForSchedulazioneBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public GenerateInterventoRotForSchedulazioneBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public GenerateInterventoRotForSchedulazioneBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public GenerateInterventoRotForSchedulazioneBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public GenerateInterventoRotForSchedulazioneBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public GenerateInterventoRotForSchedulazioneBuilder WithTrenoArrivo(Treno trenoArrivo)
        {
            _trenoArrivo = trenoArrivo;
            return this;
        }

        public GenerateInterventoRotForSchedulazioneBuilder WithTrenoPartenza(Treno trenoPartenza)
        {
            _trenoPartenza = trenoPartenza;
            return this;
        }

        public GenerateInterventoRotForSchedulazioneBuilder WithTurnoTreno(string turnoTreno)
        {
            _turnoTreno = turnoTreno;
            return this;
        }

        public GenerateInterventoRotForSchedulazioneBuilder WithRigaTurnoTreno(string rigaTurnoTreno)
        {
            _rigaTurnoTreno = rigaTurnoTreno;
            return this;
        }

        public GenerateInterventoRotForSchedulazioneBuilder ForConvoglio(string convoglio)
        {
            _convoglio = convoglio;
            return this;
        }

        public GenerateInterventoRotForSchedulazione Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public GenerateInterventoRotForSchedulazione Build(Guid id, Guid commitId, long version)
        {
            return new GenerateInterventoRotForSchedulazione(id,
                                                 commitId,
                                                 version,
                                                 _idPeriodoProgrammazione,
                                                 _idProgram,
                                                 _idSchedulazione,
                                                 _idInterventoGeneration,
                                                 _idCommittente,
                                                 _idLotto,
                                                 _idImpianto,
                                                 _idTipoIntervento,
                                                 _idAppaltatore,
                                                 _idCategoriaCommerciale,
                                                 _idDirezioneRegionale,
                                                 _workPeriod,
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