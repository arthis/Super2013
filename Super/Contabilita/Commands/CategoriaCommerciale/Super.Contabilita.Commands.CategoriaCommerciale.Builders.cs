


using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.CategoriaCommerciale;
using Super.Contabilita.Commands.CategoriaCommerciale.Builders;

namespace Super.Contabilita.Commands.CategoriaCommerciale.Builders
{


	public class CreateCategoriaCommercialeBuilder : ICommandBuilder<CreateCategoriaCommerciale>
	{
	 
		private string  _description ;
		public CreateCategoriaCommercialeBuilder WithDescription(string description) 
		{
			_description = description;
			return this;
		}
	
		
		public CreateCategoriaCommerciale Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public CreateCategoriaCommerciale Build(Guid id, Guid commitId)
        {
            return new CreateCategoriaCommerciale(id, commitId, _description);
		 }


		
		public CreateCategoriaCommerciale Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public CreateCategoriaCommerciale Build(Guid id, Guid commitId, long version)
        {
            return new CreateCategoriaCommerciale(id, commitId, version, _description);
		}

		
		public CreateCategoriaCommerciale Build(Guid id, Guid commitId, Guid userId)
        {
            return new CreateCategoriaCommerciale(id, commitId, userId, _description);
		 }

		 public CreateCategoriaCommerciale Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public CreateCategoriaCommerciale Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new CreateCategoriaCommerciale(id, commitId, version, userId, _description);
		}

		public CreateCategoriaCommerciale Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public CreateCategoriaCommerciale Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new CreateCategoriaCommerciale(id, commitId, wakeupTime, _description);
		 }

		public CreateCategoriaCommerciale Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public CreateCategoriaCommerciale Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new CreateCategoriaCommerciale(id, commitId, version, wakeupTime, _description);
		 }
        
	
	}

	public class DeleteCategoriaCommercialeBuilder : ICommandBuilder<DeleteCategoriaCommerciale>
	{
	
		
		public DeleteCategoriaCommerciale Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public DeleteCategoriaCommerciale Build(Guid id, Guid commitId)
        {
            return new DeleteCategoriaCommerciale(id, commitId);
		 }


		
		public DeleteCategoriaCommerciale Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public DeleteCategoriaCommerciale Build(Guid id, Guid commitId, long version)
        {
            return new DeleteCategoriaCommerciale(id, commitId, version);
		}

		
		public DeleteCategoriaCommerciale Build(Guid id, Guid commitId, Guid userId)
        {
            return new DeleteCategoriaCommerciale(id, commitId, userId);
		 }

		 public DeleteCategoriaCommerciale Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public DeleteCategoriaCommerciale Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new DeleteCategoriaCommerciale(id, commitId, version, userId);
		}

		public DeleteCategoriaCommerciale Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public DeleteCategoriaCommerciale Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new DeleteCategoriaCommerciale(id, commitId, wakeupTime);
		 }

		public DeleteCategoriaCommerciale Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public DeleteCategoriaCommerciale Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new DeleteCategoriaCommerciale(id, commitId, version, wakeupTime);
		 }
        
	
	}

	public class UpdateCategoriaCommercialeBuilder : ICommandBuilder<UpdateCategoriaCommerciale>
	{
	 
		private string  _description ;
		public UpdateCategoriaCommercialeBuilder WithDescription(string description) 
		{
			_description = description;
			return this;
		}
	
		
		public UpdateCategoriaCommerciale Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public UpdateCategoriaCommerciale Build(Guid id, Guid commitId)
        {
            return new UpdateCategoriaCommerciale(id, commitId, _description);
		 }


		
		public UpdateCategoriaCommerciale Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public UpdateCategoriaCommerciale Build(Guid id, Guid commitId, long version)
        {
            return new UpdateCategoriaCommerciale(id, commitId, version, _description);
		}

		
		public UpdateCategoriaCommerciale Build(Guid id, Guid commitId, Guid userId)
        {
            return new UpdateCategoriaCommerciale(id, commitId, userId, _description);
		 }

		 public UpdateCategoriaCommerciale Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public UpdateCategoriaCommerciale Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new UpdateCategoriaCommerciale(id, commitId, version, userId, _description);
		}

		public UpdateCategoriaCommerciale Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public UpdateCategoriaCommerciale Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new UpdateCategoriaCommerciale(id, commitId, wakeupTime, _description);
		 }

		public UpdateCategoriaCommerciale Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public UpdateCategoriaCommerciale Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new UpdateCategoriaCommerciale(id, commitId, version, wakeupTime, _description);
		 }
        
	
	}
}

namespace Super.Contabilita.Commands
{
	public static partial class BuildCmd 
	{
		  public static CreateCategoriaCommercialeBuilder CreateCategoriaCommerciale {get { return new CreateCategoriaCommercialeBuilder(); } }
	  		  public static DeleteCategoriaCommercialeBuilder DeleteCategoriaCommerciale {get { return new DeleteCategoriaCommercialeBuilder(); } }
	  		  public static UpdateCategoriaCommercialeBuilder UpdateCategoriaCommerciale {get { return new UpdateCategoriaCommercialeBuilder(); } }
	  	}
}
