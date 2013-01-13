


using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Scenario;
using Super.Programmazione.Events.Scenario.Builders;

namespace Super.Programmazione.Events.Scenario.Builders
{


	public class ScenarioPromotedToPlanBuilder : IEventBuilder<ScenarioPromotedToPlan>
	{
	 
		private Guid  _idUser ; 
		private DateTime  _promotionDate ; 
		private Guid  _idPlan ;
		public ScenarioPromotedToPlanBuilder ByUser(Guid idUser) 
		{
			_idUser = idUser;
			return this;
		}
	
		public ScenarioPromotedToPlanBuilder WhenPromotionDate(DateTime promotionDate) 
		{
			_promotionDate = promotionDate;
			return this;
		}
	
		public ScenarioPromotedToPlanBuilder ForPlan(Guid idPlan) 
		{
			_idPlan = idPlan;
			return this;
		}
	
		public ScenarioPromotedToPlan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ScenarioPromotedToPlan Build(Guid id, Guid commitId, long version)
        {
            return new ScenarioPromotedToPlan(id, commitId, version, _idUser, _promotionDate, _idPlan);
		 }

       
	
	}
}

namespace Super.Programmazione.Events
{
	public static partial class BuildEvt 
	{
		  public static ScenarioPromotedToPlanBuilder ScenarioPromotedToPlan {get { return new ScenarioPromotedToPlanBuilder(); } }
	  	}
}
