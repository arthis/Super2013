using System;
using CommonDomain.Core.Super.Messaging.Builders;

namespace CommonDomain.Core.Super.Domain.ValueObjects
{
    public class Treno
    {
        private readonly string _numeroTreno;
        private readonly DateTime _data;

        public Treno(string numeroTreno, DateTime data)
        {
            if (!IsValid(numeroTreno,data))
                throw new Exception(string.Format("Treno ({0},{1}) not valid", numeroTreno,data));
            _numeroTreno = numeroTreno;
            _data = data;
        }

        public static bool IsValid(string numeroTreno, DateTime data)
        {
            return !string.IsNullOrEmpty(numeroTreno) && data > DateTime.MinValue;
        }

        public string NumeroTreno
        {
            get { return _numeroTreno; }
        }

        public DateTime Data
        {
            get { return _data; }
        }

        public void BuildValue(TrenoBuilder builder)
        {
            builder.WithNumeroTreno(_numeroTreno).When(_data);
        }

        public static Treno FromMessage(Messaging.ValueObjects.Treno treno)
        {
            return new Treno(treno.NumeroTreno,treno.Data);
        }
    }
}
