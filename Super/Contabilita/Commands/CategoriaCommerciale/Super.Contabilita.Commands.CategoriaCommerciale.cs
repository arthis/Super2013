

using System;
using System.Linq;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain;
using CommonDomain.Core;


namespace Super.Contabilita.Commands.CategoriaCommerciale
{


	public class CreateCategoriaCommerciale :  CommandBase  
	{
	 
		public string Description { get; set;}

		public CreateCategoriaCommerciale ()
		{
			//for serialisation
		}


		public CreateCategoriaCommerciale(Guid id, Guid commitId,string description)
		   : base(id,commitId)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}
	     

		public CreateCategoriaCommerciale(Guid id, Guid commitId, long version,string description)
		   : base(id,commitId,version)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}

		
		public CreateCategoriaCommerciale(Guid id, Guid commitId, DateTime wakeupTime,string description)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}

		public CreateCategoriaCommerciale(Guid id, Guid commitId, Guid userId,string description)
		   : base(id,commitId,userId)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}


		public CreateCategoriaCommerciale(Guid id, Guid commitId, long version, DateTime wakeupTime,string description)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}

		
		public CreateCategoriaCommerciale(Guid id, Guid commitId, long version, Guid userId,string description)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}
			public override string ToDescription()
		{
			return string.Format("Creiamo la categoria commerciale '{0}'.", Id);
		}
		
		public bool Equals(CreateCategoriaCommerciale other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Description, Description) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreateCategoriaCommerciale);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class DeleteCategoriaCommerciale :  CommandBase  
	{
	

		public DeleteCategoriaCommerciale ()
		{
			//for serialisation
		}


		public DeleteCategoriaCommerciale(Guid id, Guid commitId)
		   : base(id,commitId)
		{
				}
	     

		public DeleteCategoriaCommerciale(Guid id, Guid commitId, long version)
		   : base(id,commitId,version)
		{
				}

		
		public DeleteCategoriaCommerciale(Guid id, Guid commitId, DateTime wakeupTime)
		   : base(id,commitId,wakeupTime)
		{
				}

		public DeleteCategoriaCommerciale(Guid id, Guid commitId, Guid userId)
		   : base(id,commitId,userId)
		{
				}


		public DeleteCategoriaCommerciale(Guid id, Guid commitId, long version, DateTime wakeupTime)
		   : base(id,commitId,version,wakeupTime)
		{
				}

		
		public DeleteCategoriaCommerciale(Guid id, Guid commitId, long version, Guid userId)
		   : base(id,commitId,version,userId)
		{
				}
			public override string ToDescription()
		{
			return string.Format("Cancelliamo la categoria commerciale '{0}'.", Id);
		}
		
		public bool Equals(DeleteCategoriaCommerciale other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DeleteCategoriaCommerciale);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				return result;
            }
        }
	}

	public class UpdateCategoriaCommerciale :  CommandBase  
	{
	 
		public string Description { get; set;}

		public UpdateCategoriaCommerciale ()
		{
			//for serialisation
		}


		public UpdateCategoriaCommerciale(Guid id, Guid commitId,string description)
		   : base(id,commitId)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}
	     

		public UpdateCategoriaCommerciale(Guid id, Guid commitId, long version,string description)
		   : base(id,commitId,version)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}

		
		public UpdateCategoriaCommerciale(Guid id, Guid commitId, DateTime wakeupTime,string description)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}

		public UpdateCategoriaCommerciale(Guid id, Guid commitId, Guid userId,string description)
		   : base(id,commitId,userId)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}


		public UpdateCategoriaCommerciale(Guid id, Guid commitId, long version, DateTime wakeupTime,string description)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}

		
		public UpdateCategoriaCommerciale(Guid id, Guid commitId, long version, Guid userId,string description)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}
			public override string ToDescription()
		{
			return string.Format("Aggiorniamo la categoria commerciale '{0}'.", Id);
		}
		
		public bool Equals(UpdateCategoriaCommerciale other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Description, Description) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as UpdateCategoriaCommerciale);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
				return result;
            }
        }
	}
}
