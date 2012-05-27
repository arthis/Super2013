using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Domain;

namespace Super.Appaltatore.Handlers
{
    public class ProgrammareInterventoAmbHandler : CommandHandler<ProgrammareInterventoAmb>
    {
        public ProgrammareInterventoAmbHandler(IRepository repository)
            : base(repository)
        {
        }

        public override CommandValidation Execute(ProgrammareInterventoAmb cmd)
        {

            throw new NotImplementedException();

            //Contract.Requires<ArgumentNullException>(cmd != null);

            //var commitId = Guid.NewGuid();

            //var entity = new InventoryItem(cmd.Id, cmd.Name);

            //Repository.Save(entity, commitId);

            //return entity.CommandValidationMessages;
        }
    }
}