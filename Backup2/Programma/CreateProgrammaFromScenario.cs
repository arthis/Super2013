using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Programma
{
    public class CreateProgrammaFromScenario : CommandBase
    {

        public CreateProgrammaFromScenario()
        {
            
        }

        public CreateProgrammaFromScenario(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
        }

        public override string ToDescription()
        {
            return string.Format("Creare un programma {0}", Id);
        }

        protected bool Equals(CreateProgrammaFromScenario other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CreateProgrammaFromScenario) obj);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
