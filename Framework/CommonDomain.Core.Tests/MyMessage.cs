using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace CommonDomain.Core.Tests
{
    public class MyMessage :CommandBase 
    {
        public IDictionary Properties { get; private set; }
        public override string ToDescription()
        {
            throw new NotImplementedException();
        }
    }
}
