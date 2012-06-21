using System;

namespace CommonDomain.Core.Super.Messaging.ValueObjects
{
    public class Treno
    {
        private readonly string _numeroTreno;
        private readonly DateTime _data;

        public Treno(string numeroTreno, DateTime data)
        {
            _numeroTreno = numeroTreno;
            _data = data;
        }

        public string NumeroTreno
        {
            get { return _numeroTreno; }
        }

        public DateTime Data
        {
            get { return _data; }
        }
    }
}
