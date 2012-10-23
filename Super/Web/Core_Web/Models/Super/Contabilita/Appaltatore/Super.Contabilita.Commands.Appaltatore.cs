

using System;
using System.Linq;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Core_Web.Models.Super.Contabilita.Appaltatore
{


	public partial class CreateAppaltatoreModel 
	{
		public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
	 
		public string Description { get; set;}	}

	public partial class DeleteAppaltatoreModel 
	{
		public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
		}

	public partial class UpdateAppaltatoreModel 
	{
		public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
	 
		public string Description { get; set;}	}
}
