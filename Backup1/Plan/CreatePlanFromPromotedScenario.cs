using System;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Plan
{
    public class CreatePlanFromPromotedScenario : CommandBase
    {
        public Guid IdScenario { get; set; }

        public CreatePlanFromPromotedScenario()
        {
            
        }

        public CreatePlanFromPromotedScenario(Guid id, Guid commitId, long version, Guid idScenario)
            : base(id, commitId, version)
        {
            IdScenario = idScenario;
        }

        public override string ToDescription()
        {
            return string.Format("Creare un piano {0}", Id);
        }

        protected bool Equals(CreatePlanFromPromotedScenario other)
        {
            return base.Equals(other) && IdScenario.Equals(other.IdScenario);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CreatePlanFromPromotedScenario) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ IdScenario.GetHashCode();
            }
        }
    }
}
