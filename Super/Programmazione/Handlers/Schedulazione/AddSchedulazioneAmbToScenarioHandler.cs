﻿using System;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Handlers.Schedulazione
{
    public class AddSchedulazioneAmbToScenarioHandler: CommandHandler<AddSchedulazioneAmbToScenario>
    {
        public AddSchedulazioneAmbToScenarioHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(AddSchedulazioneAmbToScenario cmd)
        {
            throw new NotImplementedException();

            //Contract.Requires<ArgumentNullException>(cmd != null);

        


            //var existingIntervento = EventRepository.GetById<Scenario>(cmd.Id);

            //if (!existingIntervento.IsNull())
            //    throw new AlreadyCreatedAggregateRootException();

            //existingIntervento.AllowControl(cmd.Id);

            //EventRepository.Save(existingIntervento, cmd.CommitId);

            //return existingIntervento.CommandValidationMessages; 
        }
    }
}
