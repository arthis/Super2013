using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CommonDomain
{
    
    public interface ICommand : IMessage
    {
        string ToDescription();
        string ToDetails();
    }
}
