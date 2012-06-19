using System;
using CommonDomain;
using CommonDomain.Core;
using Super.Controllo.Commands;
using Super.Controllo.Domain;
using CommonDomain.Persistence;
using System.Diagnostics.Contracts;

namespace Super.Controllo.Handlers
{
    public class ControlInterventoNonResoHandler : CommandHandler<ControlInterventoNonReso>
    {
        public ControlInterventoNonResoHandler(IRepository repository)
            : base(repository)
        {
        }

        public override CommandValidation Execute(ControlInterventoNonReso cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var existingIntervento = Repository.GetById<Intervento>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            existingIntervento.ControlNonReso( cmd.IdUtente, cmd.ControlDate, cmd.IdCausale, cmd.Note);

            Repository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages; 
        }
    }
}
