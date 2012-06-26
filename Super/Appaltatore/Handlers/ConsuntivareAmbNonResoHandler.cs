using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Domain;

namespace Super.Appaltatore.Handlers
{
    public class ConsuntivareAmbNonResoHandler : CommandHandler<ConsuntivareAmbNonReso>
    {
        public ConsuntivareAmbNonResoHandler(IRepository repository)
            : base(repository)
        {
        }

        public override CommandValidation Execute(ConsuntivareAmbNonReso cmd, ICommandHandler<ConsuntivareAmbNonReso> next)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            

            var existingIntervento = Repository.GetById<InterventoAmb>(cmd.Id);

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