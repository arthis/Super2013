

using System;
using System.Linq;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain;
using CommonDomain.Core;


namespace Super.Contabilita.Commands.Appaltatore
{


	public class CreateAppaltatore :  CommandBase  
	{
	 
		public string Description { get; set;}

		public CreateAppaltatore ()
		{
			//for serialisation
		}


		public CreateAppaltatore(Guid id, Guid commitId,string description)
		   : base(id,commitId)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}
	     

		public CreateAppaltatore(Guid id, Guid commitId, long version,string description)
		   : base(id,commitId,version)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}

		
		public CreateAppaltatore(Guid id, Guid commitId, DateTime wakeupTime,string description)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}


		public CreateAppaltatore(Guid id, Guid commitId, long version, DateTime wakeupTime,string description)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}
			public override string ToDescription()
		{
			return string.Format("Creiamo il appaltatore '{0}'.", Id);
		}
		
		public bool Equals(CreateAppaltatore other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Description, Description) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreateAppaltatore);
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

	public class DeleteAppaltatore :  CommandBase  
	{
	

		public DeleteAppaltatore ()
		{
			//for serialisation
		}


		public DeleteAppaltatore(Guid id, Guid commitId)
		   : base(id,commitId)
		{
				}
	     

		public DeleteAppaltatore(Guid id, Guid commitId, long version)
		   : base(id,commitId,version)
		{
				}

		
		public DeleteAppaltatore(Guid id, Guid commitId, DateTime wakeupTime)
		   : base(id,commitId,wakeupTime)
		{
				}


		public DeleteAppaltatore(Guid id, Guid commitId, long version, DateTime wakeupTime)
		   : base(id,commitId,version,wakeupTime)
		{
				}
			public override string ToDescription()
		{
			return string.Format("Cancelliamo il appaltatore '{0}'.", Id);
		}
		
		public bool Equals(DeleteAppaltatore other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DeleteAppaltatore);
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

	public class UpdateAppaltatore :  CommandBase  
	{
	 
		public string Description { get; set;}

		public UpdateAppaltatore ()
		{
			//for serialisation
		}


		public UpdateAppaltatore(Guid id, Guid commitId,string description)
		   : base(id,commitId)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}
	     

		public UpdateAppaltatore(Guid id, Guid commitId, long version,string description)
		   : base(id,commitId,version)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}

		
		public UpdateAppaltatore(Guid id, Guid commitId, DateTime wakeupTime,string description)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}


		public UpdateAppaltatore(Guid id, Guid commitId, long version, DateTime wakeupTime,string description)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}
			public override string ToDescription()
		{
			return string.Format("Aggiorniamo il appaltatore '{0}'.", Id);
		}
		
		public bool Equals(UpdateAppaltatore other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Description, Description) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as UpdateAppaltatore);
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
