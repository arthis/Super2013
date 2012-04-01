using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace Commands
{
    [Serializable]
    public class CommandMessage : ICommand
    {
        //public Cqrs.Commanding.ICommand Payload { get; set; }
        public int MyProperty { get; set; }
    }
}
