using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Handlers.TipoOggettoIntervento.RotabileInManutenzione
{
    public class CreateCarriageRotManHandler : CommandHandler<CreateCarriageRotMan>
    {
        public CreateCarriageRotManHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateCarriageRotMan cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);


            var existingCarriage = EventRepository.GetById<Domain.TipoOggettoIntervento.CarriageRotMan>(cmd.Id);

            if (!existingCarriage.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            var carriage = new Domain.TipoOggettoIntervento.CarriageRotMan();

            EventRepository.Save(carriage, cmd.CommitId);


            return carriage.CommandValidationMessages;
        }

    }
}