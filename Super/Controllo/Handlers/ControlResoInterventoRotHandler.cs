﻿using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Controllo.Commands;
using Super.Controllo.Commands.Consuntivazione;
using Super.Controllo.Domain;
using CommonDomain.Persistence;
using System.Diagnostics.Contracts;

namespace Super.Controllo.Handlers
{
    public class ControlResoInterventoRotHandler : CommandHandler<ControlResoInterventoRot>
    {
        public ControlResoInterventoRotHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(ControlResoInterventoRot cmd)
        {
            Contract.Requires(cmd != null);

            var existingIntervento = EventRepository.GetById<InterventoRot>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();


            existingIntervento.ControlReso(cmd.IdUser,
                                            cmd.ControlDate,
                                            cmd.WorkPeriod.ToDomain(),
                                            cmd.TrenoPartenza.ToDomain(),
                                            cmd.TrenoArrivo.ToDomain(),
                                            cmd.Convoglio,
                                            cmd.Note,
                                            cmd.Oggetti.ToDomain(),
                                            cmd.RigaTurnoTreno, 
                                            cmd.TurnoTreno);

            EventRepository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages; 
        }
    }
}
