using System;
using System.Collections.Generic;
using CommonCommands;
using CommonDomain;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Schedulazione.Commands;
using CommonSpecs;
using Super.Schedulazione.Events;
using Super.Schedulazione.Handlers;

namespace Super.Schedulazione.Specs
{
    public class Creation_of_a_new_inventory_item : BaseClass<CreateInventoryItem>
    {
        private Guid _Id = Guid.NewGuid();
        private string _Name = "test";

        protected override CommandHandler<CreateInventoryItem> OnHandle(IRepository repository)
        {
            return new CreateInventoryItemHandler(repository);
        }

        public override IEnumerable<IEvent> Given()
        {
            yield break;
        }

        public override CreateInventoryItem When()
        {
            return new CreateInventoryItem()
            {
                Id = _Id,
                Name = _Name
            };
        }

        public override IEnumerable<IEvent> Expect()
        {
            yield return new InventoryItemCreatedAdded()
            {
                Id = _Id,
                Name = _Name
            };
        }

        [Test]
        public void It_does_not_throw_an_Exception()
        {
            Assert.IsNull(Caught);
        }


    }
}
