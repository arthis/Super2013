using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Handlers.Commands.TipoOggettoIntervento.Rotabile
{
    public class UpdateLocomotiveRotHandler : CommandHandler<UpdateLocomotiveRot>
    {
        public UpdateLocomotiveRotHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(UpdateLocomotiveRot cmd)
        {
            Contract.Requires(cmd != null);


            var locomotive = EventRepository.GetById<Domain.TipoOggettoIntervento.LocomotiveRot>(cmd.Id);

            if (locomotive.IsNull())
                throw new AggregateRootInstanceNotFoundException();


            locomotive.Update(cmd.Description,cmd.Sign, cmd.IdGruppoOggettoIntervento);

            EventRepository.Save(locomotive, cmd.CommitId);


            return locomotive.CommandValidationMessages;
        }

    }
}