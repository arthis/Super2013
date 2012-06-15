using System;
using CommonDomain;
using CommonDomain.Core;
using Super.Controllo.Commands;
using Super.Controllo.Domain;
using CommonDomain.Persistence;
using System.Diagnostics.Contracts;

namespace Super.Controllo.Handlers
{
    public class ReopenInterventoHandler : CommandHandler<ReopenIntervento>
    {
        public ReopenInterventoHandler(IRepository repository)
            : base(repository)
        {
        }

        public override CommandValidation Execute(ReopenIntervento cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);



            var existingIntervento = Repository.GetById<Intervento>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            existingIntervento.Reopen(cmd.IdUtente, cmd.ReopeningDate);

            Repository.Save(existingIntervento, cmd.GetCommitId());

            return existingIntervento.CommandValidationMessages; 
        }
    }
}
