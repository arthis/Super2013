using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Controllo.Commands;
using Super.Controllo.Domain;
using CommonDomain.Persistence;
using System.Diagnostics.Contracts;

namespace Super.Controllo.Handlers
{
    public class ControlInterventoRotManResoHandler : CommandHandler<ControlInterventoRotManReso>
    {
        public ControlInterventoRotManResoHandler(IRepository repository)
            : base(repository)
        {
        }

        public override CommandValidation Execute(ControlInterventoRotManReso cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            Treno trenoPartenza=null, trenoArrivo=null;

            var existingIntervento = Repository.GetById<InterventoRotMan>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            existingIntervento.ControlReso(cmd.IdUtente, cmd.ControlDate, new WorkPeriod(cmd.Start, cmd.End),  cmd.Note, cmd.Oggetti);

            Repository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages; 
        }
    }
}
