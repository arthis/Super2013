using System;
using CommonDomain;
using Super.Contabilita.Commands.Appaltatore;

namespace Super.Contabilita.Commands.Builders.Appaltatore
{
    public class CreateAppaltatoreBuilder : ICommandBuilder<CreateAppaltatore>
    {
        private string _description;

        public CreateAppaltatore Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateAppaltatore Build(Guid id, Guid commitId, long version)
        {
            var cmd =  new CreateAppaltatore(id, commitId, version,   _description);

            return cmd;
        }

 
        public CreateAppaltatoreBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }


    }
}
