using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;

namespace CommonDomain.Core
{
    [Serializable]
    public class CommandValidation 
    {

        public List<ValidationMessage> Messages { get; private set; }

        public CommandValidation()
        {
            this.Messages = new List<ValidationMessage>();
        }

        
        public CommandValidation(ValidationMessage error)
        {
            this.Messages = new List<ValidationMessage>() { error };
        }


        public void Add(ValidationMessage error)
        {
            Contract.Requires(this.Messages != null);
            Messages.Add(error);
        }

        
    }
}
