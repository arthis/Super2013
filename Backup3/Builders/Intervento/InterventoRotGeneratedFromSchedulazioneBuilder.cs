using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Intervento;

namespace Super.Programmazione.Events.Builders.Intervento
{
    public class InterventoRotGeneratedFromSchedulazioneBuilder : IEventBuilder<InterventoRotGeneratedFromSchedulazione>
    {
        protected Guid _idPeriodoProgrammazione;
        protected Guid _idProgramm;
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
        private Guid _idInterventoGeneration;

        public InterventoRotGeneratedFromSchedulazioneBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public InterventoRotGeneratedFromSchedulazioneBuilder ForProgram(Guid idProgramm)
        {
            _idProgramm = idProgramm;
            return this;
        }

        public InterventoRotGeneratedFromSchedulazioneBuilder ForSchedulazione(Guid idSchedualzione)
        {
            _idSchedulazione = idSchedualzione;
            return this;
        }

        public InterventoRotGeneratedFromSchedulazioneBuilder ForInterventoGeneration(Guid idInterventoGeneration)
        {
            _idInterventoGeneration = idInterventoGeneration;
            return this;
        }

        public InterventoRotGeneratedFromSchedulazioneBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public InterventoRotGeneratedFromSchedulazioneBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public InterventoRotGeneratedFromSchedulazioneBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public InterventoRotGeneratedFromSchedulazioneBuilder OfType(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public InterventoRotGeneratedFromSchedulazioneBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public InterventoRotGeneratedFromSchedulazioneBuilder OfCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public InterventoRotGeneratedFromSchedulazioneBuilder OfDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public InterventoRotGeneratedFromSchedulazioneBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public InterventoRotGeneratedFromSchedulazioneBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public InterventoRotGeneratedFromSchedulazioneBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }



        public InterventoRotGeneratedFromSchedulazioneBuilder WithTrenoArrivo(Treno trenoArrivo)
        {
            _trenoArrivo = trenoArrivo;
            return this;
        }

        public InterventoRotGeneratedFromSchedulazioneBuilder WithTrenoPartenza(Treno trenoPartenza)
        {
            _trenoPartenza = trenoPartenza;
            return this;
        }

        public InterventoRotGeneratedFromSchedulazioneBuilder WithTurnoTreno(string turnoTreno)
        {
            _turnoTreno = turnoTreno;
            return this;
        }

        public InterventoRotGeneratedFromSchedulazioneBuilder WithRigaTurnoTreno(string rigaTurnoTreno)
        {
            _rigaTurnoTreno = rigaTurnoTreno;
            return this;
        }

        public InterventoRotGeneratedFromSchedulazioneBuilder ForConvoglio(string convoglio)
        {
            _convoglio = convoglio;
            return this;
        }






        public InterventoRotGeneratedFromSchedulazione Build(Guid id, long version)
        {
            var evt = new InterventoRotGeneratedFromSchedulazione(id, Guid.NewGuid(),
                                                 version,
                                                 _idPeriodoProgrammazione,
                                                 _idProgramm,
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
                                                 _trenoArrivo,
                                                 _trenoPartenza,
                                                 _turnoTreno,
                                                 _rigaTurnoTreno,
                                                 _convoglio);

            return evt;
        }

    }
}