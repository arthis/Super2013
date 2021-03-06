﻿using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoIntervento.Rotabile;

namespace Super.Contabilita.Handlers.Commands.TipoIntervento
{

    public class CreateTipoInterventoRotHandler : CommandHandler<CreateTipoInterventoRot>
    {
        public CreateTipoInterventoRotHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateTipoInterventoRot cmd)
        {
            Contract.Requires(cmd != null);
            

            var existingTipoInterventoRot = EventRepository.GetById<Domain.TipoInterventoRot>(cmd.Id);

            if (!existingTipoInterventoRot.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            var tipoIntervento = new Domain.TipoInterventoRot(cmd.Id,
                                          cmd.Description,
                                          cmd.Mnemo,
                                          cmd.IdMeasuringUnit,
                                          cmd.Classe,
                                          cmd.AiTreni,
                                          cmd.CalcoloDetrazioni);

            EventRepository.Save(tipoIntervento, cmd.CommitId);


            return tipoIntervento.CommandValidationMessages;
        }

    }

 
}
