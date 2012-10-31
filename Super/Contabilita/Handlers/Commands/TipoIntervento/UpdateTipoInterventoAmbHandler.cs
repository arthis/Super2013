using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoIntervento.Ambiente;

namespace Super.Contabilita.Handlers.Commands.TipoIntervento
{
    public class UpdateTipoInterventoAmbHandler : CommandHandler<UpdateTipoInterventoAmb>
    {
        public UpdateTipoInterventoAmbHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(UpdateTipoInterventoAmb cmd)
        {
            Contract.Requires(cmd != null);

            var tipoIntervento = EventRepository.GetById<Domain.TipoInterventoAmb>(cmd.Id);

            if (tipoIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            tipoIntervento.Update( cmd.Description,cmd.Mnemo, cmd.IdMeasuringUnit);

            EventRepository.Save(tipoIntervento, cmd.CommitId);

            return tipoIntervento.CommandValidationMessages;
        }
      
    }
}
