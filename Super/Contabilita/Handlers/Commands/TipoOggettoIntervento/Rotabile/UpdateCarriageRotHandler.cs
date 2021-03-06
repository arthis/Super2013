using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Handlers.Commands.TipoOggettoIntervento.Rotabile
{
    public class UpdateCarriageRotHandler : CommandHandler<UpdateCarriageRot>
    {
        public UpdateCarriageRotHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(UpdateCarriageRot cmd)
        {
            Contract.Requires(cmd != null);


            var carriage = EventRepository.GetById<Domain.TipoOggettoIntervento.CarriageRot>(cmd.Id);

            if (carriage.IsNull())
                throw new AggregateRootInstanceNotFoundException();


            carriage.Update(cmd.Description,cmd.Sign,cmd.IsInternational, cmd.IdGruppoOggettoIntervento);

            EventRepository.Save(carriage, cmd.CommitId);


            return carriage.CommandValidationMessages;
        }

    }
}