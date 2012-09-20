using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Commands.Impianto
{
    
    public class CreateImpianto : CommandBase
    {

        public string Description { get; set; }
        public Interval Interval { get; set; }
        [DisplayName("Lotto")]
        public Guid IdLotto { get; set; }
        
        public CreateImpianto()
        {
            
        }
        
        public CreateImpianto(Guid id, Guid commitId, long version,  Interval period, string description, Guid idLotto)
            : base(id, commitId, version)
        {
            Contract.Requires(period != null);
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(description) );
            Contract.Requires(idLotto != Guid.Empty);

            Interval = period;
            Description = description;
            IdLotto = idLotto;
        }



        public override string ToDescription()
        {
            return string.Format("Creiamo il impianto '{0}'.", Description);
        }

        public bool Equals(CreateImpianto other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description)  && Equals(other.Interval, Interval) && other.IdLotto.Equals(IdLotto);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreateImpianto);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ (Interval != null ? Interval.GetHashCode() : 0);
                result = (result*397) ^ IdLotto.GetHashCode();
                return result;
            }
        }
    }
}
