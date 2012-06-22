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

            var existingIntervento = Repository.GetById<InterventoRot>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();


            existingIntervento.ControlReso(cmd.IdUtente,
                                            cmd.ControlDate,
                                            WorkPeriod.FromMessage(cmd.Period),
                                            Treno.FromMessage(cmd.TrenoPartenza),
                                            Treno.FromMessage(cmd.TrenoArrivo),
                                            cmd.Convoglio,
                                            cmd.Note,
                                            cmd.Oggetti.ToValueObject(),
                                            cmd.RigaTurnoTreno, 
                                            cmd.TurnoTreno);

            Repository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages; 
        }
    }
}
