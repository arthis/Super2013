using System;
using CommonDomain;
using Super.Contabilita.Commands.GruppoOggettoIntervento;

namespace Super.Contabilita.Commands.Builders.GruppoOggettoIntervento
{
    public class UpdateGruppoOggettoInterventoBuilder : ICommandBuilder<UpdateGruppoOggettoIntervento>
    {
        private string _description;

        public UpdateGruppoOggettoIntervento Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateGruppoOggettoIntervento Build(Guid id, Guid commitId, long version)
        {
            var cmd = new UpdateGruppoOggettoIntervento(id, commitId, version,  _description);
            
            return cmd;
        }



        public UpdateGruppoOggettoInterventoBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        
    }
}