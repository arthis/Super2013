using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Intervento;

namespace Super.Programmazione.Commands.Builders.Intervento
{
    public class GenerateInterventoRotManForSchedulazioneBuilder : ICommandBuilder<GenerateInterventoRotManForSchedulazione>
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
        private OggettoRotMan[] _oggetti;
        private Guid _idInterventoGeneration;


        public GenerateInterventoRotManForSchedulazioneBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public GenerateInterventoRotManForSchedulazioneBuilder ForProgram(Guid idProgram)
        {
            _idProgram = idProgram;
            return this;
        }

        public GenerateInterventoRotManForSchedulazioneBuilder ForSchedulazione(Guid idSchedulazione)
        {
            _idSchedulazione = idSchedulazione;
            return this;
        }

        public GenerateInterventoRotManForSchedulazioneBuilder ForInterventoGeneration(Guid idInterventoGeneration)
        {
            _idInterventoGeneration = idInterventoGeneration;
            return this;
        }

        public GenerateInterventoRotManForSchedulazioneBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public GenerateInterventoRotManForSchedulazioneBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public GenerateInterventoRotManForSchedulazioneBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public GenerateInterventoRotManForSchedulazioneBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public GenerateInterventoRotManForSchedulazioneBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public GenerateInterventoRotManForSchedulazioneBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public GenerateInterventoRotManForSchedulazioneBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public GenerateInterventoRotManForSchedulazioneBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public GenerateInterventoRotManForSchedulazioneBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public GenerateInterventoRotManForSchedulazioneBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

      

        public GenerateInterventoRotManForSchedulazione Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public GenerateInterventoRotManForSchedulazione Build(Guid id, Guid commitId, long version)
        {
            return new GenerateInterventoRotManForSchedulazione(id,
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
                                                 _oggetti);
        }
    }
}