

using System;
using System.Linq;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Core_Web.Models.Super.Programmazione.Scenario
{


	public partial class AddSchedulazioneRotToScenarioModel 
	{
		public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
	 
		public Guid IdPeriodoProgrammazione { get; set;} 
		public Guid IdSchedulazione { get; set;} 
		public Guid IdCommittente { get; set;} 
		public Guid IdLotto { get; set;} 
		public Guid IdImpianto { get; set;} 
		public Guid IdTipoIntervento { get; set;} 
		public Guid IdAppaltatore { get; set;} 
		public Guid IdCategoriaCommerciale { get; set;} 
		public Guid IdDirezioneRegionale { get; set;} 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public Period Period { get; set;} 
		public string Convoglio { get; set;} 
		public string RigaTurnoTreno { get; set;} 
		public string TurnoTreno { get; set;} 
		public Treno TrenoArrivo { get; set;} 
		public Treno TrenoPartenza { get; set;} 
		public OggettoRot[] Oggetti { get; set;}	}

	public partial class AddSchedulazioneRotManToScenarioModel 
	{
		public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
	 
		public Guid IdPeriodoProgrammazione { get; set;} 
		public Guid IdSchedulazione { get; set;} 
		public Guid IdCommittente { get; set;} 
		public Guid IdLotto { get; set;} 
		public Guid IdImpianto { get; set;} 
		public Guid IdTipoIntervento { get; set;} 
		public Guid IdAppaltatore { get; set;} 
		public Guid IdCategoriaCommerciale { get; set;} 
		public Guid IdDirezioneRegionale { get; set;} 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public Period Period { get; set;} 
		public OggettoRotMan[] Oggetti { get; set;}	}

	public partial class AddSchedulazioneAmbToScenarioModel 
	{
		public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
	 
		public Guid IdPeriodoProgrammazione { get; set;} 
		public Guid IdSchedulazione { get; set;} 
		public Guid IdCommittente { get; set;} 
		public Guid IdLotto { get; set;} 
		public Guid IdImpianto { get; set;} 
		public Guid IdTipoIntervento { get; set;} 
		public Guid IdAppaltatore { get; set;} 
		public Guid IdCategoriaCommerciale { get; set;} 
		public Guid IdDirezioneRegionale { get; set;} 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public Period Period { get; set;} 
		public int Quantity { get; set;} 
		public string Description { get; set;}	}

	public partial class CreateScenarioModel 
	{
		public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
	 
		public string Description { get; set;} 
		public Guid IdProgramma { get; set;}	}

	public partial class CancelScenarioModel 
	{
		public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
		}

	public partial class ChangeDescriptionScenarioModel 
	{
		public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
	 
		public string Description { get; set;}	}

	public partial class PromoteScenarioToPlanModel 
	{
		public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
	 
		public DateTime PromotionDate { get; set;} 
		public Guid IdPlan { get; set;}	}
}
