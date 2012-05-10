namespace CommonDomain.Core
{
    public  class ValidationMessage : IValidationMessage
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