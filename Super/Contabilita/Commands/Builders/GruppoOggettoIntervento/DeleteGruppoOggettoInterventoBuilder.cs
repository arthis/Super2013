using System;
using CommonDomain;
using Super.Contabilita.Commands.GruppoOggettoIntervento;

namespace Super.Contabilita.Commands.Builders.GruppoOggettoIntervento
{
    public class DeleteGruppoOggettoInterventoBuilder : ICommandBuilder<DeleteGruppoOggettoIntervento>
    {

        public DeleteGruppoOggettoIntervento Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public DeleteGruppoOggettoIntervento Build(Guid id, Guid commitId, long version)
        {
            var cmd = new DeleteGruppoOggettoIntervento(id,commitId,version);

            return cmd;
        }


    }
}