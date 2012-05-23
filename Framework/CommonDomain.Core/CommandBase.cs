using System;
using System.Linq;
using System.Runtime.Serialization;

namespace CommonDomain.Core
{
    [Serializable]
    [KnownType("GetKnownTypes")]
    public abstract class CommandBase : Message, ICommand
    {
        public Guid Id { get; set; }
    

        public static Type[] GetKnownTypes()
        {
            var types = from asm in AppDomain.CurrentDomain.GetAssemblies()
                        from type in asm.GetTypes()
                        where typeof(CommandBase).IsAssignableFrom(type)
                        select type;

            return types.ToArray();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;

            var other = (CommandBase)obj;

            return base.Equals(obj)
                && other.Id.Equals(Id);
        }
            
        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ Id.GetHashCode();
            }
        }
    }



}
