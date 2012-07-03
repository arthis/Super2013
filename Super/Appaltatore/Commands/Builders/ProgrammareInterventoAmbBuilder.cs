using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Appaltatore.Commands.Builders
{

    public class ProgrammareInterventoAmbBuilder : ICommandBuilder<ProgrammareInterventoAmb>
    {
        private Guid _idImpianto;
        private Guid _idTipoIntervento;
        private Guid _idAppaltatore;
        private Guid _idCategoriaCommerciale;
        private Guid _idDirezioneRegionale;
        private WorkPeriod _period;
        private string _note;
        private int _quantity;
        private string _description;


        public ProgrammareInterventoAmbBuilder ForQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public ProgrammareInterventoAmbBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public ProgrammareInterventoAmbBuilder ForPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }

        public ProgrammareInterventoAmbBuilder OfType(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public ProgrammareInterventoAmbBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public ProgrammareInterventoAmbBuilder OfCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public ProgrammareInterventoAmbBuilder OfDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public ProgrammareInterventoAmbBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public ProgrammareInterventoAmbBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }


        public ProgrammareInterventoAmb Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public ProgrammareInterventoAmb Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new ProgrammareInterventoAmb(id,idCommitId,version,
                                      _idImpianto,
                                      _idTipoIntervento,
                                      _idAppaltatore,
                                      _idCategoriaCommerciale,
                                      _idDirezioneRegionale,
                                      _period,
                                      _note,
                                      _quantity,
                                      _description);


            return cmd;
        }

    }
}
