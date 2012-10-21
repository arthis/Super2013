using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.PeriodoProgrammazione
{
    public class PeriodoProgrammazioneClosed : EventBase
    {
        public DateTime ClosingDate { get; set; }
        public Guid IdUser { get; set; }

        //for serialization
        public PeriodoProgrammazioneClosed()
        {

        }

        public PeriodoProgrammazioneClosed(Guid id, Guid commitId, long version, DateTime closingDate, Guid idUser)
            : base(id, commitId, version)
        {
            Contract.Requires(closingDate>DateTime.MinValue);
            Contract.Requires(idUser!= Guid.Empty);

            ClosingDate = closingDate;
            IdUser = idUser;
        }

        public override string ToDescription()
        {
            return string.Format("Il periodo programazione  é stato chiuso alle '{0}'.", ClosingDate);
        }

        public bool Equals(PeriodoProgrammazioneClosed other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.ClosingDate.Equals(ClosingDate) && other.IdUser.Equals(IdUser);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as PeriodoProgrammazioneClosed);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ ClosingDate.GetHashCode();
                result = (result*397) ^ IdUser.GetHashCode();
                return result;
            }
        }
    }
}