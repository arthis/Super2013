using System;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.Schedulazione
{
    public class CancelSchedulazionePriceOfScenario : CommandBase
    {

        public CancelSchedulazionePriceOfScenario()
        {
            
        }

        public CancelSchedulazionePriceOfScenario(Guid id,
                                          Guid commitId,
                                          long version)
            : base(id,commitId,  version)
        {
            
        }


        public bool Equals(CancelSchedulazionePriceOfScenario other)
        {
            return base.Equals(other);
        }

        public override string ToDescription()
        {
            return "Cancellare il prezzo della schedulazione nel scenario";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CancelSchedulazionePriceOfScenario);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}