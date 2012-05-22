using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;

namespace Super.Appaltatore.Commands
{
    

    public abstract class ProgrammareIntervento : CommandBase
    {
        public Guid Id { get; set; }
        public Guid IdAreaIntervento { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }

    public class ProgrammareInterventoRot : ProgrammareIntervento
    {
        
        public override string ToDescription()
        {
            return string.Format("programmare il intervento rotabile {0}.", Id);
        }

    }

    public class ProgrammareInterventoRotMan : ProgrammareIntervento
    {
        public override string ToDescription()
        {
            return string.Format("programmare il intervento rotabile in manutenzione {0}.", Id);
        }
    }

    public class ProgrammareInterventoAmb : ProgrammareIntervento
    {
        public override string ToDescription()
        {
            return string.Format("programmare il intervento ambiente {0} is Schedulato.", Id);
        }
    }
}
