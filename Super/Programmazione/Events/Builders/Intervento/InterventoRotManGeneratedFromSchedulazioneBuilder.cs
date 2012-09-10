using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Intervento;

namespace Super.Programmazione.Events.Builders.Intervento
{
    public class InterventoRotManGeneratedFromSchedulazioneBuilder : IEventBuilder<InterventoRotManGeneratedFromSchedulazione>
    {
        protected Guid _idPeriodoProgrammazione;
        protected Guid _idProgram;
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
        private OggettoRotMan[] _oggetti;
        private Guid _idInterventoGeneration;


        public InterventoRotManGeneratedFromSchedulazioneBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public InterventoRotManGeneratedFromSchedulazioneBuilder ForProgram(Guid idProgram)
        {
            _idProgram = idProgram;
            return this;
        }

        public InterventoRotManGeneratedFromSchedulazioneBuilder ForSchedulazione(Guid idSchedulazione)
        {
            _idSchedulazione = idSchedulazione;
            return this;
        }

        public InterventoRotManGeneratedFromSchedulazioneBuilder ForInterventoGeneration(Guid idInterventoGeneration)
        {
            _idInterventoGeneration = idInterventoGeneration;
            return this;
        }

        public InterventoRotManGeneratedFromSchedulazioneBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public InterventoRotManGeneratedFromSchedulazioneBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public InterventoRotManGeneratedFromSchedulazioneBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public InterventoRotManGeneratedFromSchedulazioneBuilder OfType(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public InterventoRotManGeneratedFromSchedulazioneBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public InterventoRotManGeneratedFromSchedulazioneBuilder OfCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public InterventoRotManGeneratedFromSchedulazioneBuilder OfDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public InterventoRotManGeneratedFromSchedulazioneBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public InterventoRotManGeneratedFromSchedulazioneBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public InterventoRotManGeneratedFromSchedulazioneBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }


        public InterventoRotManGeneratedFromSchedulazione Build(Guid id, long version)
        {
            var evt = new InterventoRotManGeneratedFromSchedulazione(id, Guid.NewGuid(),
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
                                                    _oggetti);

            return evt;
        }

    }
}