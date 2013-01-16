using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDomain
{
    public interface IAction
    {
        bool CanBeExecuted();
    }
}
