using System;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Appaltatore.Commands.Builders
{

    public class ProgrammareInterventoAmbBuilder
    {
        private Guid _id;
        private Guid _idAreaIntervento;
        private Guid _idTipoIntervento;
        private Guid _idAppaltatore;
        private Guid _idCategoriaCommerciale;
        private Guid _idDirezioneRegionale;
        private WorkPeriod _period;
        private string _note;
        private int _quantity;
        private string _description;


        public ProgrammareInterventoAmbBuilder WithQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public ProgrammareInterventoAmbBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public ProgrammareInterventoAmbBuilder ForPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }

        public ProgrammareInterventoAmbBuilder ForId(Guid id)
        {
            _id = id;
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

        public ProgrammareInterventoAmbBuilder ForArea(Guid idAreaIntervento)
        {
            _idAreaIntervento = idAreaIntervento;
            return this;
        }

        

      

        public ProgrammareInterventoAmb Build()
        {
            var cmd = new ProgrammareInterventoAmb(_id,
                                      _idAreaIntervento,
                                      _idTipoIntervento,
                                      _idAppaltatore,
                                      _idCategoriaCommerciale,
                                      _idDirezioneRegionale,
                                      _period,
                                      _note,
                                      _quantity,
                                      _description);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}
