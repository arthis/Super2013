using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Domain;

namespace Super.Appaltatore.Handlers
{
    public class ConsuntivareAmbNonResoTrenitaliaHandler : CommandHandler<ConsuntivareAmbNonResoTrenitalia>
    {
        public ConsuntivareAmbNonResoTrenitaliaHandler(IRepository repository)
            : base(repository)
        {
        }

        public override CommandValidation Execute(ConsuntivareAmbNonResoTrenitalia cmd, ICommandHandler<ConsuntivareAmbNonResoTrenitalia> next)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            

            var existingIntervento = Repository.GetById<InterventoAmb>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new HandlerForDomainEventNotFoundException();

            existingIntervento.ConsuntivareNonResoTrenitalia(cmd.Id
                                , cmd.DataConsuntivazione
                                , cmd.IdCausaleTrenitalia
                                , cmd.IdInterventoAppaltatore
                                , cmd.Note);

            Repository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages;
        }
    }
}