using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CommonDomain
{
    [Serializable]

    public abstract class ICommandValidation
    {
        public abstract IEnumerable<IValidationMessage> GetErrors();
        public abstract void Add(IValidationMessage error);

    }

    [Serializable]
    public abstract class IValidationMessage
    {
        
    }
}
