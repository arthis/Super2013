using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.CategoriaCommerciale;


namespace Super.Contabilita.Commands.Builders
{
    public class CreateCategoriaCommercialeBuilder : ICommandBuilder<CreateCategoriaCommerciale>
    {
        private string _description;

        public CreateCategoriaCommerciale Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateCategoriaCommerciale Build(Guid id, Guid commitId, long version)
        {
            var cmd =  new CreateCategoriaCommerciale(id, commitId, version,   _description);

            return cmd;
        }

 
        public CreateCategoriaCommercialeBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }


    }
}
