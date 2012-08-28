using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Handlers.TipoOggettoIntervento.Rotabile
{
    public class UpdateCarriageRotHandler : CommandHandler<UpdateCarriageRot>
    {
        public UpdateCarriageRotHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(UpdateCarriageRot cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);


            var carriage = EventRepository.GetById<Domain.TipoOggettoIntervento.CarriageRot>(cmd.Id);

            if (carriage.IsNull())
                throw new AggregateRootInstanceNotFoundException();


            carriage.Update();

            EventRepository.Save(carriage, cmd.CommitId);


            return carriage.CommandValidationMessages;
        }

    }
}