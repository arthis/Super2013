using System;
using CommonDomain;
using CommonDomain.Core;
using Super.Controllo.Commands;
using Super.Controllo.Domain;
using CommonDomain.Persistence;
using System.Diagnostics.Contracts;

namespace Super.Controllo.Handlers
{
    public class AllowControlInterventoHandler : CommandHandler<AllowControlIntervento>
    {
        public AllowControlInterventoHandler(IRepository repository)
            : base(repository)
        {
        }

        public override CommandValidation Execute(AllowControlIntervento cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);



            var existingIntervento = Repository.GetById<Intervento>(cmd.Id);

            if (!existingIntervento.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            existingIntervento.AllowControl();

            Repository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages; 
        }
    }
}
