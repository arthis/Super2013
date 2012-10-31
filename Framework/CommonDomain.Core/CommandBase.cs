using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization;

namespace CommonDomain.Core
{
    [Serializable]
    [KnownType("GetKnownTypes")]
    public abstract class CommandBase : Message, ICommand
    {
        public bool IsExecuted { get; set; }
        public Guid SecurityToken { get; set; }
        public Guid UserId { get; set; }
        public DateTime? WakeTime { get; set; }
        public long? Version { get;  set; }
        

        public CommandBase()
        {
            
        }

        public CommandBase(Guid id, Guid commitId)
            : base(id, commitId)
        {
            
        }

        public CommandBase(Guid id, Guid commitId, long version)
            :base(id,commitId)
        {
            Contract.Requires(version >= (long)(0));

            Version = version;
        }

        public CommandBase(Guid id, Guid commitId,DateTime wakeupTime)
            : base(id, commitId)
        {
            Contract.Requires(wakeupTime != DateTime.MinValue && wakeupTime != DateTime.MaxValue);

            WakeTime = wakeupTime;
        }

        public CommandBase(Guid id, Guid commitId, Guid userId)
            : base(id, commitId)
        {
            Contract.Requires(userId != Guid.Empty);

            UserId = userId;
        }

        public CommandBase(Guid id, Guid commitId, long version, Guid userId)
            : base(id, commitId)
        {
            Contract.Requires(version >= (long)(0));
            Contract.Requires(userId != Guid.Empty);

            Version = version;
            UserId = userId;
        }

        public CommandBase(Guid id, Guid commitId, long version,DateTime wakeupTime)
            : base(id, commitId)
        {
            Contract.Requires(version >= (long)(0));
            Contract.Requires(wakeupTime != DateTime.MinValue && wakeupTime!= DateTime.MaxValue);

            Version = version;
            WakeTime = wakeupTime;
        }

        protected bool Equals(CommandBase other)
        {
            return base.Equals(other) && IsExecuted.Equals(other.IsExecuted) && SecurityToken.Equals(other.SecurityToken) && WakeTime.Equals(other.WakeTime) && Version == other.Version;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CommandBase) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ IsExecuted.GetHashCode();
                hashCode = (hashCode*397) ^ SecurityToken.GetHashCode();
                hashCode = (hashCode*397) ^ WakeTime.GetHashCode();
                hashCode = (hashCode*397) ^ Version.GetHashCode();
                return hashCode;
            }
        }

        public static Type[] GetKnownTypes()
        {
            var types = from asm in AppDomain.CurrentDomain.GetAssemblies()
                        from type in asm.GetTypes()
                        where
                            typeof(CommandBase).IsAssignableFrom(type) && !type.IsAbstract
                        select type;

            return types.ToArray();
        }
    }
}
