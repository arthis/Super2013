using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CommonDomain.Core
{
    [Serializable]
    public class CommandValidation 
    {

        private List<ValidationMessage> Messages { get; set; }

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
            Messages.Add(error);
        }

        
    }
}
