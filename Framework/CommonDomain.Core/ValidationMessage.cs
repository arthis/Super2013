using System;


namespace CommonDomain.Core
{
    [Serializable]
    public class ValidationMessage
    {
        private string _title;
        private string _message;

        public string Message
        {
            get { return _message; }
        }
        public string Title
        {
            get { return _title; }
        }


        public ValidationMessage(string title, string message)
        {
            _title = title;
            _message = message;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", _title, _message);
        }


    }
    
}