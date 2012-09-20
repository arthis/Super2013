using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Handlers.TipoIntervento
{
    public class UpdateTipoInterventoRotManHandler : CommandHandler<UpdateTipoInterventoRotMan>
    {
        public UpdateTipoInterventoRotManHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(UpdateTipoInterventoRotMan cmd)
        {
            Contract.Requires(cmd != null);

            var tipoIntervento = EventRepository.GetById<Domain.TipoInterventoRotMan>(cmd.Id);

            if (tipoIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            tipoIntervento.Update( cmd.Description,cmd.Mnemo, cmd.IdMeasuringUnit);

            EventRepository.Save(tipoIntervento, cmd.CommitId);

            return tipoIntervento.CommandValidationMessages;
        }
      
    }
}
