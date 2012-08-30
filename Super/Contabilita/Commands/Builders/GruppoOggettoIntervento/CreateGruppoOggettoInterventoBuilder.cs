using System;
using CommonDomain;
using Super.Contabilita.Commands.GruppoOggettoIntervento;

namespace Super.Contabilita.Commands.Builders.GruppoOggettoIntervento
{
    public class CreateGruppoOggettoInterventoBuilder : ICommandBuilder<CreateGruppoOggettoIntervento>
    {
        private string _description;

        public CreateGruppoOggettoIntervento Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateGruppoOggettoIntervento Build(Guid id, Guid commitId, long version)
        {
            var cmd =  new CreateGruppoOggettoIntervento(id, commitId, version,   _description);

            return cmd;
        }

 
        public CreateGruppoOggettoInterventoBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }


    }
}
