using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Domain;

namespace Super.Appaltatore.Handlers
{
    public class ConsuntivareRotNonResoHandler : CommandHandler<ConsuntivareRotNonReso>
    {
        public ConsuntivareRotNonResoHandler(IRepository repository)
            : base(repository)
        {
        }

        public override CommandValidation Execute(ConsuntivareRotNonReso cmd, ICommandHandler<ConsuntivareRotNonReso> next)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var existingIntervento = Repository.GetById<InterventoRot>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new HandlerForDomainEventNotFoundException();

            existingIntervento.ConsuntivareNonReso(cmd.Id
                                 , cmd.IdInterventoAppaltatore
                                 , cmd.DataConsuntivazione
                                 , cmd.IdCausaleAppaltatore
                                 , cmd.Note);

            Repository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages;
        }
    }
}