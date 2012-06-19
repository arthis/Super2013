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
    public class ControlInterventoRotResoHandler : CommandHandler<ControlInterventoRotReso>
    {
        public ControlInterventoRotResoHandler(IRepository repository)
            : base(repository)
        {
        }

        public override CommandValidation Execute(ControlInterventoRotReso cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            Treno trenoPartenza=null, trenoArrivo=null;


            var existingIntervento = Repository.GetById<InterventoRot>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            if (Treno.IsValid(cmd.NumeroTrenoPartenza, cmd.DataTrenoPartenza))
                 trenoPartenza = new Treno(cmd.NumeroTrenoPartenza, cmd.DataTrenoPartenza);
            if (Treno.IsValid(cmd.NumeroTrenoArrivo, cmd.DataTrenoArrivo))
                 trenoArrivo = new Treno(cmd.NumeroTrenoArrivo, cmd.DataTrenoArrivo);

            existingIntervento.ControlReso(cmd.IdUtente, cmd.ControlDate, new RolloutPeriod(cmd.Start, cmd.End), trenoPartenza, trenoArrivo, cmd.Convoglio, cmd.Note, cmd.Oggetti, cmd.RigaTurnoTreno, cmd.TurnoTreno);

            Repository.Save(existingIntervento, cmd.GetCommitId());

            return existingIntervento.CommandValidationMessages; 
        }
    }
}
