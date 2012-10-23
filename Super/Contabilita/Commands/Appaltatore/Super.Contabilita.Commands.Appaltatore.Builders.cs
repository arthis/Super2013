


using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Appaltatore;
using Super.Contabilita.Commands.Appaltatore.Builders;

namespace Super.Contabilita.Commands.Appaltatore.Builders
{


	public class CreateAppaltatoreBuilder : ICommandBuilder<CreateAppaltatore>
	{
	 
		private string  _description ;
		public CreateAppaltatoreBuilder WithDescription(string description) 
		{
			_description = description;
			return this;
		}
	
		
		public CreateAppaltatore Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public CreateAppaltatore Build(Guid id, Guid commitId)
        {
            return new CreateAppaltatore(id, commitId, _description);
		 }


		
		public CreateAppaltatore Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public CreateAppaltatore Build(Guid id, Guid commitId, long version)
        {
            return new CreateAppaltatore(id, commitId, version, _description);
		 }

		public CreateAppaltatore Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public CreateAppaltatore Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new CreateAppaltatore(id, commitId, wakeupTime, _description);
		 }

		public CreateAppaltatore Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public CreateAppaltatore Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new CreateAppaltatore(id, commitId, version, wakeupTime, _description);
		 }
        
	
	}

	public class DeleteAppaltatoreBuilder : ICommandBuilder<DeleteAppaltatore>
	{
	
		
		public DeleteAppaltatore Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public DeleteAppaltatore Build(Guid id, Guid commitId)
        {
            return new DeleteAppaltatore(id, commitId);
		 }


		
		public DeleteAppaltatore Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public DeleteAppaltatore Build(Guid id, Guid commitId, long version)
        {
            return new DeleteAppaltatore(id, commitId, version);
		 }

		public DeleteAppaltatore Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public DeleteAppaltatore Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new DeleteAppaltatore(id, commitId, wakeupTime);
		 }

		public DeleteAppaltatore Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public DeleteAppaltatore Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new DeleteAppaltatore(id, commitId, version, wakeupTime);
		 }
        
	
	}

	public class UpdateAppaltatoreBuilder : ICommandBuilder<UpdateAppaltatore>
	{
	 
		private string  _description ;
		public UpdateAppaltatoreBuilder WithDescription(string description) 
		{
			_description = description;
			return this;
		}
	
		
		public UpdateAppaltatore Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public UpdateAppaltatore Build(Guid id, Guid commitId)
        {
            return new UpdateAppaltatore(id, commitId, _description);
		 }


		
		public UpdateAppaltatore Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public UpdateAppaltatore Build(Guid id, Guid commitId, long version)
        {
            return new UpdateAppaltatore(id, commitId, version, _description);
		 }

		public UpdateAppaltatore Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public UpdateAppaltatore Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new UpdateAppaltatore(id, commitId, wakeupTime, _description);
		 }

		public UpdateAppaltatore Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public UpdateAppaltatore Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new UpdateAppaltatore(id, commitId, version, wakeupTime, _description);
		 }
        
	
	}
}

namespace Super.Contabilita.Commands
{
	public static partial class BuildCmd 
	{
		  public static CreateAppaltatoreBuilder CreateAppaltatore {get { return new CreateAppaltatoreBuilder(); } }
	  		  public static DeleteAppaltatoreBuilder DeleteAppaltatore {get { return new DeleteAppaltatoreBuilder(); } }
	  		  public static UpdateAppaltatoreBuilder UpdateAppaltatore {get { return new UpdateAppaltatoreBuilder(); } }
	  	}
}
