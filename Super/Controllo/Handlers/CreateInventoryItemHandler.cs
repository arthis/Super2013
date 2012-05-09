using System;
using CommonCommands;
using Super.Controllo.Commands;
using Super.Controllo.Domain;
using CommonDomain.Persistence;
using System.Diagnostics.Contracts;

namespace Super.Controllo.Handlers
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
