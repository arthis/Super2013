using System;
using System.Diagnostics.Contracts;

namespace CommonDomain.Core.Super.Messaging.ValueObjects
{
    public class Treno
    {
        public string NumeroTreno { get; set; }
        public DateTime Data { get; set; }

        public Treno(string numeroTreno, DateTime data)
        {
            Contract.Requires(!string.IsNullOrEmpty(numeroTreno));
            Contract.Requires(data> DateTime.MinValue);

            NumeroTreno = numeroTreno;
            Data = data;
        }

        public bool Equals(Treno other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.NumeroTreno, NumeroTreno) && other.Data.Equals(Data);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Treno)) return false;
            return Equals((Treno) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((NumeroTreno != null ? NumeroTreno.GetHashCode() : 0)*397) ^ Data.GetHashCode();
            }
        }
    }
}
