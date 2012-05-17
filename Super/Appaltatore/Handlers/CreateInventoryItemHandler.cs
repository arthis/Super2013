﻿using System;
using CommonDomain;
using CommonDomain.Core;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Domain;
using CommonDomain.Persistence;
using System.Diagnostics.Contracts;

namespace Super.Appaltatore.Handlers
{
    public class CreateInventoryItemHandler : CommandHandler<CreateInventoryItem>
    {
        public CreateInventoryItemHandler(IRepository repository)
            : base(repository)
        {
        }

        public override CommandValidation Execute(CreateInventoryItem cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var commitId = Guid.NewGuid();

            var entity = new InventoryItem(cmd.Id, cmd.Name);

            Repository.Save(entity, commitId);

            return entity.CommandValidationMessages;
        }
    }
}