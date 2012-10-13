using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Handlers.Commands.TipoOggettoIntervento.RotabileInManutenzione
{
    public class UpdateLocomotiveRotManHandler : CommandHandler<UpdateLocomotiveRotMan>
    {
        public UpdateLocomotiveRotManHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(UpdateLocomotiveRotMan cmd)
        {
            Contract.Requires(cmd != null);


            var locomotive = EventRepository.GetById<Domain.TipoOggettoIntervento.LocomotiveRotMan>(cmd.Id);

            if (locomotive.IsNull())
                throw new AggregateRootInstanceNotFoundException();


            locomotive.Update(cmd.Description,cmd.Sign, cmd.IdGruppoOggettoIntervento);

            EventRepository.Save(locomotive, cmd.CommitId);


            return locomotive.CommandValidationMessages;
        }

    }
}