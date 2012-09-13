using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Programmazione.Events.Scenario
{
    public class ScenarioCancelled : Message , IEvent
    {
        public Guid IdUser { get; set; }

        public ScenarioCancelled()
        {
            
        }

        public ScenarioCancelled(Guid id, Guid commitId, long version, Guid idUser)
            : base(id, commitId, version)
        {
            IdUser = idUser;
        }

        public override string ToDescription()
        {
            return string.Format("Scenario {0} è stato cancellato", Id);
        }

        public bool Equals(ScenarioCancelled other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdUser.Equals(IdUser);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ScenarioCancelled);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ IdUser.GetHashCode();
            }
        }
    }
}
