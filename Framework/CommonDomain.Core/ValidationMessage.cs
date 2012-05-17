using System;
using System.Runtime.Serialization;

namespace CommonDomain.Core
{
    [Serializable]
    public class ValidationMessage : IValidationMessage
    {
        private string _message;
         
        
        public ValidationMessage(string message)
        {
            _message = message;
        }

        public override string ToString()
        {
            return _message;
        }


    }
    
}