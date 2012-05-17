﻿using System;
using CommonDomain;
using CommonDomain.Core;
using Super.Schedulazione.Commands;
using Super.Schedulazione.Domain;
using CommonDomain.Persistence;
using System.Diagnostics.Contracts;

namespace Super.Schedulazione.Handlers
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
