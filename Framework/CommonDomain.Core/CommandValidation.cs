using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain.Core
{
    public class CommandValidation : ICommandValidation
    {
        private readonly List<IValidationMessage> _errors;

        public CommandValidation()
        {
            this._errors = new List<IValidationMessage>();
        }


        public CommandValidation(IValidationMessage error)
        {
            this._errors = new List<IValidationMessage>() { error };
        }

        public IEnumerable<IValidationMessage> GetErrors()
        {
            return _errors;
        }

        public void Add(IValidationMessage error)
        {
            _errors.Add(error);
        }

        
    }
}
