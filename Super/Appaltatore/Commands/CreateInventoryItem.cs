using System;
using CommonDomain;

namespace Super.Appaltatore.Commands
{
    public class CreateInventoryItem :ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string ToDescription()
        {
            return string.Format("We create an Inventory Item (Name:{0})", Name);
        }
    }
}
