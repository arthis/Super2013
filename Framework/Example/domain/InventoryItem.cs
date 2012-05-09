using System;
using CommonDomain.Core;
using Super.Appaltatore.Events;

namespace Super.Appaltatore.Domain
{
    public class InventoryItem : AggregateBase
    {
        private string _name;

        public InventoryItem(Guid id, string name)
        {
            var evt = new InventoryItemCreatedAdded()
            {
                Id = id,
                Name = name
            };

            RaiseEvent(evt);
        }

        public void Apply(InventoryItemCreatedAdded e)
        {
            Id = e.Id;
        }

        public string ToDescription()
        {
            return string.Format("Inventory Item {0}, {1}", Id, _name);
        }
    }
}
