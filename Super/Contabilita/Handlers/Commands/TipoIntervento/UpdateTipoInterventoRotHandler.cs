using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoIntervento.Rotabile;

namespace Super.Contabilita.Handlers.Commands.TipoIntervento
{
    public class UpdateTipoInterventoRotHandler : CommandHandler<UpdateTipoInterventoRot>
    {
        public UpdateTipoInterventoRotHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(UpdateTipoInterventoRot cmd)
        {
            Contract.Requires(cmd != null);

            var tipoIntervento = EventRepository.GetById<Domain.TipoInterventoRot>(cmd.Id);

            if (tipoIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            tipoIntervento.Update( cmd.Description,
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
