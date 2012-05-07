using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonCommands;
using CommonDomain;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Domain;
using CommonDomain.Persistence;
using System.Diagnostics.Contracts;

namespace example1.handlers
{
    public class CreateInventoryItemHandler : CommandHandler<CreateInventoryItem>
    {
        public CreateInventoryItemHandler(IRepository repository)
            : base(repository)
        {
        }

        public override void Execute(CreateInventoryItem cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var commitId = Guid.NewGuid();

            var entity = new InventoryItem(cmd.Id, cmd.Name);

            Repository.Save(entity, commitId);
        }
    }
}
