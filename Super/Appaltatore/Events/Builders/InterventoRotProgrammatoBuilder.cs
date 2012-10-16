using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Appaltatore.Events.Programmazione;

namespace Super.Appaltatore.Events.Builders
{
    public class InterventoRotProgrammatoBuilder : IEventBuilder<InterventoRotProgrammato>
    {
        private string _convoglio;
        private Guid _idAppaltatore;
        private Guid _idCategoriaCommerciale;
        private Guid _idDirezioneRegionale;
        private Guid _idImpianto;
        private Guid _idTipoIntervento;
        private string _note;
        private OggettoRot[] _oggetti;
        private WorkPeriod _period;
        private string _rigaTurnoTreno;
        private Treno _trenoArrivo;
        private Treno _trenoPartenza;
        private string _turnoTreno;

        #region IEventBuilder<InterventoRotProgrammato> Members

        public InterventoRotProgrammato Build(Guid id, long version)
        {
            return new InterventoRotProgrammato(id, Guid.NewGuid(),
                                                version,
                                                _idImpianto,
                                                _idTipoIntervento,
                                                _idAppaltatore,
                                                _idCategoriaCommerciale,
                                                _idDirezioneRegionale,
                                                _period,
                                                _note,
                                                _oggetti,
                                                _trenoPartenza,
                                                _trenoArrivo,
                                                _turnoTreno,
                                                _rigaTurnoTreno,
                                                _convoglio);
        }

        #endregion

        public InterventoRotProgrammatoBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public InterventoRotProgrammatoBuilder ForWorkPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }


        public InterventoRotProgrammatoBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public InterventoRotProgrammatoBuilder OfType(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public InterventoRotProgrammatoBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public InterventoRotProgrammatoBuilder OfCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public InterventoRotProgrammatoBuilder OfDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public InterventoRotProgrammatoBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public InterventoRotProgrammatoBuilder WithTrenoArrivo(Treno trenoArrivo)
        {
            _trenoArrivo = trenoArrivo;
            return this;
        }

        public InterventoRotProgrammatoBuilder WithTrenoPartenza(Treno trenoPartenza)
        {
            _trenoPartenza = trenoPartenza;
            return this;
        }

        public InterventoRotProgrammatoBuilder WithTurnoTreno(string turnoTreno)
        {
            _turnoTreno = turnoTreno;
            return this;
        }

        public InterventoRotProgrammatoBuilder WithRigaTurnoTreno(string rigaTurnoTreno)
        {
            _rigaTurnoTreno = rigaTurnoTreno;
            return this;
        }

        public InterventoRotProgrammatoBuilder ForConvoglio(string convoglio)
        {
            _convoglio = convoglio;
            return this;
        }
    }
}