using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Appaltatore.Commands;
using CommonSpecs;
using Super.Appaltatore.Events;
using Super.Appaltatore.Handlers;

namespace Super.Appaltatore.Specs
{
    public class Creation_of_a_new_inventory_item : CommandBaseClass<CreateInventoryItem>
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
