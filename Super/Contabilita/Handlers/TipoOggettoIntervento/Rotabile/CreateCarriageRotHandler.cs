using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Handlers.TipoOggettoIntervento.Rotabile
{
    public class CreateCarriageRotHandler : CommandHandler<CreateCarriageRot>
    {
        public CreateCarriageRotHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateCarriageRot cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);


            var existingCarriage = EventRepository.GetById<Domain.TipoOggettoIntervento.CarriageRot>(cmd.Id);

            if (!existingCarriage.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            var carriage = new Domain.TipoOggettoIntervento.CarriageRot();

            EventRepository.Save(carriage, cmd.CommitId);


            return carriage.CommandValidationMessages;
        }

    }
}