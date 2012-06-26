using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Domain
{

    public class Is_Lotto_Already_Deleted : ISpecification<Lotto>
    {
        public bool IsSatisfiedBy(Lotto l)
        {
            if (l.Deleted)
            {
                l.CommandValidationMessages.Add(new ValidationMessage("Fatale : lotto gia cancellato"));
                return false;
            }

            return true;
        }
    }

   
}
