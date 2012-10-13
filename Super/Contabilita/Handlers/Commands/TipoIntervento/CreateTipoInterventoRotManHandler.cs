using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Handlers.Commands.TipoIntervento
{

    public class CreateTipoInterventoRotManHandler : CommandHandler<CreateTipoInterventoRotMan>
    {
        public CreateTipoInterventoRotManHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateTipoInterventoRotMan cmd)
        {
            Contract.Requires(cmd != null);
            

            var existingTipoInterventoRotMan = EventRepository.GetById<Domain.TipoInterventoRotMan>(cmd.Id);

            if (!existingTipoInterventoRotMan.IsNull())
                throw new AlreadyCreatedAggregateRootException();



            var tipoIntervento = new Domain.TipoInterventoRotMan(cmd.Id,
                                          cmd.Description, cmd.Mnemo, cmd.IdMeasuringUnit);

            EventRepository.Save(tipoIntervento, cmd.CommitId);


            return tipoIntervento.CommandValidationMessages;
        }

    }

 
}
