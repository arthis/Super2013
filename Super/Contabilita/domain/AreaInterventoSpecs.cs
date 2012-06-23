using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Domain
{

    public class Is_Already_Deleted : ISpecification<AreaIntervento>
    {
        public bool IsSatisfiedBy(AreaIntervento ai)
        {
            if (ai.Deleted)
            {
                ai.CommandValidationMessages.Add(new ValidationMessage("Fatale : area intervento gia cancellata"));
                return false;
            }

            return true;
        }
    }

   
}
