using System;
using CommandService;
using CommonDomain;

namespace Super.Schedulazione.Commands
{
    public class CreateInventoryItem : CommandBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public override string ToDescription()
        {
            return string.Format("We create an Inventory Item (Name:{0})", Name);
        }
    }
}
