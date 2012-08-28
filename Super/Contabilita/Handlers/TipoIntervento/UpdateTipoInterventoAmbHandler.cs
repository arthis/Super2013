﻿using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoIntervento.Ambiente;

namespace Super.Contabilita.Handlers.TipoIntervento
{
    public class UpdateTipoInterventoAmbHandler : CommandHandler<UpdateTipoInterventoAmb>
    {
        public UpdateTipoInterventoAmbHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(UpdateTipoInterventoAmb cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var tipoIntervento = EventRepository.GetById<Domain.TipoInterventoAmb>(cmd.Id);

            if (tipoIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            tipoIntervento.Update( cmd.Description,cmd.Mnemo, cmd.IdMeasuringUnit);

            EventRepository.Save(tipoIntervento, cmd.CommitId);

            return tipoIntervento.CommandValidationMessages;
        }
      
    }
}
