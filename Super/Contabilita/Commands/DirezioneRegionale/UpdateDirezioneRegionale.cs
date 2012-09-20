using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Lotto;

namespace Super.Contabilita.Commands.DirezioneRegionale
{

    public class UpdateDirezioneRegionale : CommandBase
    {

        public string Description { get; set; }


        public UpdateDirezioneRegionale()
        {}

        public UpdateDirezioneRegionale(Guid id, Guid commitId, long version, string description)
            :base (id,commitId,version)
        {
            
            Contract.Requires(!string.IsNullOrEmpty(description));
            
            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiorniamo la direzione regionale '{0}')", Description);
        }

        public bool Equals(UpdateDirezioneRegionale other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description) ;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as UpdateDirezioneRegionale);
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
