using System;
using CommonDomain;
using CommonDomain.Core;
using Super.Controllo.Commands;
using Super.Controllo.Domain;
using CommonDomain.Persistence;
using System.Diagnostics.Contracts;

namespace Super.Controllo.Handlers
{
    public class CloseInterventoHandler : CommandHandler<CloseIntervento>
    {
        public CloseInterventoHandler(IRepository repository)
            : base(repository)
        {
        }

        public override CommandValidation Execute(CloseIntervento cmd, ICommandHandler<CloseIntervento> next)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var existingIntervento = Repository.GetById<Intervento>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            existingIntervento.Close(cmd.IdUtente, cmd.ClosingDate);

            Repository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages; 
        }
    }
}
