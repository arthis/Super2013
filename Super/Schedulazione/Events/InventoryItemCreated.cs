using System;
using CommonDomain;

namespace Super.Schedulazione.Events
{
	public class InventoryItemCreatedAdded :IEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (InventoryItemCreatedAdded)) return false;
            return Equals((InventoryItemCreatedAdded) obj);
        }

	    public bool Equals(InventoryItemCreatedAdded other)
	    {
	        if (ReferenceEquals(null, other)) return false;
	        if (ReferenceEquals(this, other)) return true;
	        return other.Id.Equals(Id) && Equals(other.Name, Name);
	    }

	    public override int GetHashCode()
	    {
	        unchecked
	        {
	            return (Id.GetHashCode()*397) ^ (Name != null ? Name.GetHashCode() : 0);
	        }
	    }

        public string ToDescription()
        {
            return string.Format("The Inventory item '{0}' is created.",  Name);
        }
    }
	
}
