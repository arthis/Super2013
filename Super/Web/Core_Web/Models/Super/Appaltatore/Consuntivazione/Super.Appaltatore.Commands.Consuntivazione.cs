


using System;
using System.Linq;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Core_Web.Models.Super.Appaltatore.Consuntivazione
{


	public partial class ConsuntivareAutomaticamenteNonResoInterventoRotModel 
	{
		public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
	 
		public DateTime DataConsuntivazione { get; set;}	}

	public partial class ConsuntivareAutomaticamenteNonResoInterventoRotManModel 
	{
		public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
	 
		public DateTime DataConsuntivazione { get; set;}	}

	public partial class ConsuntivareAutomaticamenteNonResoInterventoAmbModel 
	{
		public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
	 
		public DateTime DataConsuntivazione { get; set;}	}

	public partial class ConsuntivareNonResoInterventoRotModel 
	{
		public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
	 
		public string Note { get; set;} 
		public Guid IdCausaleAppaltatore { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;}	}

	public partial class ConsuntivareNonResoInterventoRotManModel 
	{
		public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
	 
		public string Note { get; set;} 
		public Guid IdCausaleAppaltatore { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;}	}

	public partial class ConsuntivareNonResoInterventoAmbModel 
	{
		public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
	 
		public string Note { get; set;} 
		public Guid IdCausaleAppaltatore { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;}	}

	public partial class ConsuntivareNonResoTrenitaliaInterventoRotModel 
	{
		public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
	 
		public string Note { get; set;} 
		public Guid IdCausaleTrenitalia { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;}	}

	public partial class ConsuntivareNonResoTrenitaliaInterventoRotManModel 
	{
		public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
	 
		public string Note { get; set;} 
		public Guid IdCausaleTrenitalia { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;}	}

	public partial class ConsuntivareNonResoTrenitaliaInterventoAmbModel 
	{
		public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
	 
		public string Note { get; set;} 
		public Guid IdCausaleTrenitalia { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;}	}

	public partial class ConsuntivareResoInterventoRotModel 
	{
		public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
	 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;} 
		public OggettoRot[] Oggetti { get; set;}	}

	public partial class ConsuntivareResoInterventoRotManModel 
	{
		public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
	 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;} 
		public OggettoRotMan[] Oggetti { get; set;}	}

	public partial class ConsuntivareResoInterventoAmbModel 
	{
		public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
	 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;} 
		public string Description { get; set;} 
		public int Quantity { get; set;}	}
}
