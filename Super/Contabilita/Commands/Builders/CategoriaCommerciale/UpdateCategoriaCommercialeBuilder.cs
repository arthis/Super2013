using System;
using CommonDomain;
using Super.Contabilita.Commands.CategoriaCommerciale;

namespace Super.Contabilita.Commands.Builders.CategoriaCommerciale
{
    public class UpdateCategoriaCommercialeBuilder : ICommandBuilder<UpdateCategoriaCommerciale>
    {
        private string _description;

        public UpdateCategoriaCommerciale Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateCategoriaCommerciale Build(Guid id, Guid commitId, long version)
        {
            var cmd = new UpdateCategoriaCommerciale(id, commitId, version,  _description);
            
            return cmd;
        }



        public UpdateCategoriaCommercialeBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        
    }
}