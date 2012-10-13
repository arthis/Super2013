using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Intervento;

namespace Super.Programmazione.Commands.Builders.Intervento
{
    public class GenerateInterventoAmbForSchedulazioneBuilder : ICommandBuilder<GenerateInterventoAmbForSchedulazione>
    {
        protected Guid _idPeriodoProgrammazione;
        protected Guid _idProgram;
        private Guid _idSchedulazione;
        private Guid _idInterventoGeneration;
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


        public GenerateInterventoAmbForSchedulazioneBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public GenerateInterventoAmbForSchedulazioneBuilder ForProgram(Guid idProgram)
        {
            _idProgram = idProgram;
            return this;
        }

        public GenerateInterventoAmbForSchedulazioneBuilder ForSchedulazione(Guid idSchedulazione)
        {
            _idSchedulazione = idSchedulazione;
            return this;
        }

        public GenerateInterventoAmbForSchedulazioneBuilder ForInterventoGeneration(Guid idInterventoGeneration)
        {
            _idInterventoGeneration = idInterventoGeneration;
            return this;
        }

        public GenerateInterventoAmbForSchedulazioneBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public GenerateInterventoAmbForSchedulazioneBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public GenerateInterventoAmbForSchedulazioneBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public GenerateInterventoAmbForSchedulazioneBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public GenerateInterventoAmbForSchedulazioneBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public GenerateInterventoAmbForSchedulazioneBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public GenerateInterventoAmbForSchedulazioneBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public GenerateInterventoAmbForSchedulazioneBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public GenerateInterventoAmbForSchedulazioneBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }
        public GenerateInterventoAmbForSchedulazioneBuilder ForQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public GenerateInterventoAmbForSchedulazioneBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

      

        public GenerateInterventoAmbForSchedulazione Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public GenerateInterventoAmbForSchedulazione Build(Guid id, Guid commitId, long version)
        {
            return new GenerateInterventoAmbForSchedulazione(id,
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
                                                 _quantity,
                                                 _description
                                                 );
        }
    }
}