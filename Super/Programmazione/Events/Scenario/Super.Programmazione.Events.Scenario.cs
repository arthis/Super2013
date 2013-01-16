


using System;
using System.Linq;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain;
using CommonDomain.Core;


namespace Super.Programmazione.Events.Scenario
{


	public class ScenarioPromotedToPlan : EventBase  
	{
	 
		public Guid IdUser { get; set;} 
		public DateTime PromotionDate { get; set;} 
		public Guid IdPlan { get; set;}

		public ScenarioPromotedToPlan ()
		{
			//for serialisation
		}	     

		public ScenarioPromotedToPlan(Guid id, Guid commitId, long version,Guid idUser,DateTime promotionDate,Guid idPlan)
		   : base(id,commitId,version)
		{
			Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(promotionDate > DateTime.MinValue);

	Contract.Requires(idPlan != Guid.Empty);

			IdUser = idUser ;
			PromotionDate = promotionDate ;
			IdPlan = idPlan ;
		}

		
			public override string ToDescription()
		{
			return string.Format("Scenario é stato promosso come piano", Id);
		}
		
		public bool Equals(ScenarioPromotedToPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdUser, IdUser)  	 && Equals(other.PromotionDate, PromotionDate)  	 && Equals(other.IdPlan, IdPlan) ; 
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
				result = (result*397) ^ IdPlan.GetHashCode();
				return result;
            }
        }
	}
}
