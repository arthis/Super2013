using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Handlers.Commands.TipoOggettoIntervento.Rotabile
{
    public class CreateCarriageRotHandler : CommandHandler<CreateCarriageRot>
    {
        public CreateCarriageRotHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateCarriageRot cmd)
        {
            Contract.Requires(cmd != null);


            var existingCarriage = EventRepository.GetById<Domain.TipoOggettoIntervento.CarriageRot>(cmd.Id);

            if (!existingCarriage.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            var carriage = new Domain.TipoOggettoIntervento.CarriageRot(cmd.Id, cmd.Description, cmd.Sign, cmd.IsInternational, cmd.IdGruppoOggettoIntervento);

            EventRepository.Save(carriage, cmd.CommitId);


            return carriage.CommandValidationMessages;
        }

    }
}