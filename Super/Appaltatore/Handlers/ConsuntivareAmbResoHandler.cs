using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.ValueObjects;
using CommonDomain.Persistence;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Domain;

namespace Super.Appaltatore.Handlers
{
    public class ConsuntivareAmbResoHandler : CommandHandler<ConsuntivareAmbReso>
    {
        public ConsuntivareAmbResoHandler(IRepository repository)
            : base(repository)
        {
        }

        public override CommandValidation Execute(ConsuntivareAmbReso cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var existingIntervento = Repository.GetById<InterventoAmb>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new HandlerForDomainEventNotFoundException();

            existingIntervento.ConsuntivareReso(cmd.Id
                                , cmd.DataConsuntivazione
                                , new RangeDate(cmd.Start, cmd.End)
                                , cmd.IdInterventoAppaltatore
                                , cmd.Note
                                , cmd.Descrizione
                                , cmd.Quantita);

            Repository.Save(existingIntervento, cmd.GetCommitId());

            return existingIntervento.CommandValidationMessages;
        }
    }
}