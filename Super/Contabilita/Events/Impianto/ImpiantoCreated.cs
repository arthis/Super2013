using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Events.Impianto
{
    public class ImpiantoCreated : Message, IEvent
    {

        public Interval Interval { get;  set; }
        public string Description { get;  set; }
        public Guid IdLotto { get;  set; }
        

        //for serialization
        public ImpiantoCreated()
        {
            
        }

        public ImpiantoCreated(Guid id, Guid commitId, long version, Interval period, Guid idLotto,  string description)
            : base(id, commitId, version)
        {
            Contract.Requires(period != null);
            Contract.Requires(!string.IsNullOrEmpty(description));
            Contract.Requires(idLotto != Guid.Empty);

            IdLotto = idLotto;
            Interval = period;
            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("L'impianto é stata creata '{0}'.", Description);
        }

        public bool Equals(ImpiantoCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Interval, Interval) && Equals(other.Description, Description) && other.IdLotto.Equals(IdLotto);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ImpiantoCreated);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Interval != null ? Interval.GetHashCode() : 0);
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ IdLotto.GetHashCode();
                return result;
            }
        }
    }
}
