using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Domain;

namespace Super.Appaltatore.Handlers
{
    public class ConsuntivareRotManResoHandler : CommandHandler<ConsuntivareRotManReso>
    {
        public ConsuntivareRotManResoHandler(IRepository repository)
            : base(repository)
        {
        }

        public override CommandValidation Execute(ConsuntivareRotManReso cmd, ICommandHandler<ConsuntivareRotManReso> next)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var existingIntervento = Repository.GetById<InterventoRotMan>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new HandlerForDomainEventNotFoundException();

            existingIntervento.ConsuntivareReso(cmd.Id
                                , cmd.DataConsuntivazione
                                , WorkPeriod.FromMessage(cmd.Period)
                                , cmd.IdInterventoAppaltatore
                                , cmd.Note
                                ,cmd.Oggetti.ToValueObject());

            Repository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages;
        }
    }
}