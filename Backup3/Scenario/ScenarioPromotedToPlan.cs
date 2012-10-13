using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Programmazione.Events.Scenario
{
    public class ScenarioPromotedToPlan : Message , IEvent
    {
        public Guid IdUser { get; set; }
        public DateTime PromotionDate { get; set; }

        public ScenarioPromotedToPlan(Guid id, Guid commitId, long version, Guid idUser, DateTime promotionDate)
            : base(id, commitId, version)
        {
            Contract.Requires(idUser!= Guid.Empty);
            Contract.Requires(promotionDate>DateTime.MinValue);

            IdUser = idUser;
            PromotionDate = promotionDate;
        }

        public override string ToDescription()
        {
            return "Scenario é stato promosso come piano";
        }

        public bool Equals(ScenarioPromotedToPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdUser.Equals(IdUser) && other.PromotionDate.Equals(PromotionDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ScenarioPromotedToPlan);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ IdUser.GetHashCode();
                result = (result*397) ^ PromotionDate.GetHashCode();
                return result;
            }
        }
    }
}
