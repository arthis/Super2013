using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain
{
    public interface ICommandValidation
    {
        IEnumerable<IValidationMessage> GetErrors();
        void Add(IValidationMessage error);

    }
}
