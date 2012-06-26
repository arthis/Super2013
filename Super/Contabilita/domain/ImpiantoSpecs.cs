using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Domain
{

    public class Is_Impianto_Already_Deleted : ISpecification<Impianto>
    {
        public bool IsSatisfiedBy(Impianto ai)
        {
            if (ai.Deleted)
            {
                ai.CommandValidationMessages.Add(new ValidationMessage("Fatale : impianto gia cancellata"));
                return false;
            }

            return true;
        }
    }

   
}
