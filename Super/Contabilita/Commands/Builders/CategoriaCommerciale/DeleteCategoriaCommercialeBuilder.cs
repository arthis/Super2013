using System;
using CommonDomain;
using Super.Contabilita.Commands.CategoriaCommerciale;

namespace Super.Contabilita.Commands.Builders.CategoriaCommerciale
{
    public class DeleteCategoriaCommercialeBuilder : ICommandBuilder<DeleteCategoriaCommerciale>
    {

        public DeleteCategoriaCommerciale Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public DeleteCategoriaCommerciale Build(Guid id, Guid commitId, long version)
        {
            var cmd = new DeleteCategoriaCommerciale(id,commitId,version);

            return cmd;
        }


    }
}