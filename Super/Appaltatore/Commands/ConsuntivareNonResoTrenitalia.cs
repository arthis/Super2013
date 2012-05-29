using System;
using System.Collections.Generic;
using CommonDomain.Core;
using CommonDomain.Core.Super;

namespace Super.Appaltatore.Commands
{

    public abstract class ConsuntivareNonResoTrenitalia : CommandBase
    {
        
        public Guid Id { get; set; }
        public string IdInterventoAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public Guid IdCausale { get; set; }
        public string Note { get; set; }

    }

    
    public class ConsuntivareRotNonResoTrenitalia : ConsuntivareNonResoTrenitalia
    {

        public override string ToDescription()
        {
            return string.Format("Si consuntiva non reso trenitalia il intervento rotabile '{0}' ", Id);
        }
    }

    
    public class ConsuntivareRotManNonResoTrenitalia : ConsuntivareNonResoTrenitalia
    {

        public override string ToDescription()
        {
            return string.Format("Si consuntiva non reso trenitalia il intervento rotabile in manutenzione '{0}' ", Id);
        }
    }

    
    public class ConsuntivareAmbNonResoTrenitalia : ConsuntivareNonResoTrenitalia
    {
       
        public override string ToDescription()
        {
            return string.Format("Si consuntiva non reso trenitalia il intervento ambiente '{0}' ", Id);
        }
    }
}
