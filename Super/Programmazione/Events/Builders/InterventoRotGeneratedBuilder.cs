using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Programmazione.Events.Builders
{

    public class InterventoRotGeneratedBuilder : IEventBuilder<InterventoRotGenerated>
    {
        private Guid _idImpianto;
        private Guid _idTipoIntervento;
        private Guid _idAppaltatore;
        private Guid _idCategoriaCommerciale;
        private Guid _idDirezioneRegionale;
        private WorkPeriod _period;
        private string _note;
        private OggettoRot[] _oggetti;
        private Treno _trenoPartenza;
        private Treno _trenoArrivo;
        private string _turnoTreno;
        private string _rigaTurnoTreno;
        private string _convoglio;

        public InterventoRotGeneratedBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public InterventoRotGeneratedBuilder ForPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }

        public InterventoRotGeneratedBuilder OfType(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public InterventoRotGeneratedBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public InterventoRotGeneratedBuilder OfCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public InterventoRotGeneratedBuilder OfDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public InterventoRotGeneratedBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public InterventoRotGeneratedBuilder WithTrenoArrivo(Treno trenoArrivo)
        {
            _trenoArrivo = trenoArrivo;
            return this;
        }

        public InterventoRotGeneratedBuilder WithTrenoPartenza(Treno trenoPartenza)
        {
            _trenoPartenza = trenoPartenza;
            return this;
        }

        public InterventoRotGeneratedBuilder WithTurnoTreno(string turnoTreno)
        {
            _turnoTreno = turnoTreno;
            return this;
        }

        public InterventoRotGeneratedBuilder WithRigaTurnoTreno(string rigaTurnoTreno)
        {
            _rigaTurnoTreno = rigaTurnoTreno;
            return this;
        }

        public InterventoRotGeneratedBuilder ForConvoglio(string convoglio)
        {
            _convoglio = convoglio;
            return this;
        }


        public InterventoRotGeneratedBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        

        public InterventoRotGenerated Build(Guid id, long version)
        {
            var evt = new InterventoRotGenerated(id, Guid.NewGuid(),
                                       version,
                                      _idImpianto,
                                      _idTipoIntervento,
                                      _idAppaltatore,
                                      _idCategoriaCommerciale,
                                      _idDirezioneRegionale,
                                      _period,
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
