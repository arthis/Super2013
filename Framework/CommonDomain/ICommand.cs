using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain
{
    public interface ICommand :IMessage
    {
        string ToDescription();
    }
}
