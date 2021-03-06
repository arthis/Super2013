using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Handlers.Commands.TipoOggettoIntervento.RotabileInManutenzione
{
    public class UpdateCarriageRotManHandler : CommandHandler<UpdateCarriageRotMan>
    {
        public UpdateCarriageRotManHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(UpdateCarriageRotMan cmd)
        {
            Contract.Requires(cmd != null);


            var carriage = EventRepository.GetById<Domain.TipoOggettoIntervento.CarriageRotMan>(cmd.Id);

            if (carriage.IsNull())
                throw new AggregateRootInstanceNotFoundException();


            carriage.Update(cmd.Description, cmd.Sign, cmd.IsInternational, cmd.IdGruppoOggettoIntervento);

            EventRepository.Save(carriage, cmd.CommitId);


            return carriage.CommandValidationMessages;
        }

    }
}