using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Controllo.Commands;
using Super.Controllo.Domain;
using CommonDomain.Persistence;
using System.Diagnostics.Contracts;

namespace Super.Controllo.Handlers
{
    public class ControlInterventoRotResoHandler : CommandHandler<ControlInterventoRotReso>
    {
        public ControlInterventoRotResoHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(ControlInterventoRotReso cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var existingIntervento = EventRepository.GetById<InterventoRot>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();


            existingIntervento.ControlReso(cmd.IdUser,
                                            cmd.ControlDate,
                                            WorkPeriod.FromMessage(cmd.Period),
                                            Treno.FromMessage(cmd.TrenoPartenza),
                                            Treno.FromMessage(cmd.TrenoArrivo),
                                            cmd.Convoglio,
                                            cmd.Note,
                                            cmd.Oggetti.ToDomainObjects(),
                                            cmd.RigaTurnoTreno, 
                                            cmd.TurnoTreno);

            EventRepository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages; 
        }
    }
}
