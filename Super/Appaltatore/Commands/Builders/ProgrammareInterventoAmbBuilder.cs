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

        public ProgrammareInterventoAmbBuilder ForArea(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public ProgrammareInterventoAmb Build(Guid id)
        {
            var cmd = new ProgrammareInterventoAmb(id,
                                      _idImpianto,
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
