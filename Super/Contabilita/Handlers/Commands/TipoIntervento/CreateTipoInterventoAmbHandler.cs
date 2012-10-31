using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoIntervento.Ambiente;

namespace Super.Contabilita.Handlers.Commands.TipoIntervento
{

    public class CreateTipoInterventoAmbHandler : CommandHandler<CreateTipoInterventoAmb>
    {
        public CreateTipoInterventoAmbHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateTipoInterventoAmb cmd)
        {
            Contract.Requires(cmd != null);
            

            var existingTipoInterventoAmb = EventRepository.GetById<Domain.TipoInterventoAmb>(cmd.Id);

            if (!existingTipoInterventoAmb.IsNull())
                throw new AlreadyCreatedAggregateRootException();



            var tipoIntervento = new Domain.TipoInterventoAmb(cmd.Id,
                                          cmd.Description, cmd.Mnemo, cmd.IdMeasuringUnit);

            EventRepository.Save(tipoIntervento, cmd.CommitId);


            return tipoIntervento.CommandValidationMessages;
        }

    }

 
}
