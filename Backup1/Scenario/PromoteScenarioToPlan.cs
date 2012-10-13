using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Scenario
{
    public class PromoteScenarioToPlan : CommandBase
    {
        public DateTime PromotionDate { get; set; }

        public PromoteScenarioToPlan(Guid id, Guid commitId, long version,  DateTime promotionDate)
            : base(id, commitId, version)
        {
            Contract.Requires(promotionDate>DateTime.MinValue);

            PromotionDate = promotionDate;
        }

        public override string ToDescription()
        {
            return "Promuovere il scenario come piano";
        }

        public bool Equals(PromoteScenarioToPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.PromotionDate.Equals(PromotionDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as PromoteScenarioToPlan);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ PromotionDate.GetHashCode();
            }
        }
    }
}
