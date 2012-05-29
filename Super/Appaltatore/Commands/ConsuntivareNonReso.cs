using System;
using CommonDomain.Core;

namespace Super.Appaltatore.Commands
{
    public abstract class ConsuntivareNonReso : CommandBase
    {
        
        public Guid Id { get; set; }
        public string IdInterventoAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }
        public Guid IdCausale { get; set; }
        public string Note { get; set; }
      
    }

    
    public class ConsuntivareRotNonReso : ConsuntivareNonReso
    {

        public override string ToDescription()
        {
            return string.Format("Si consuntiva non reso il intervento rotabile '{0}' ", Id);
        }
    }

    
    public class ConsuntivareRotManNonReso : ConsuntivareNonReso
    {
       
        public override string ToDescription()
        {
            return string.Format("Si consuntiva non reso il intervento rotabile in manutenzione '{0}' ", Id);
        }
    }

    
    public class ConsuntivareAmbNonReso : ConsuntivareNonReso
    {

        public override string ToDescription()
        {
            return string.Format("Si consuntiva non reso il intervento ambiente '{0}' ", Id);
        }
    }

}
