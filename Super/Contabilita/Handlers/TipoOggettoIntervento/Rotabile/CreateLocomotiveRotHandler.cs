using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Handlers.TipoOggettoIntervento.Rotabile
{

    public class CreateLocomotiveRotHandler : CommandHandler<CreateLocomotiveRot>
    {
        public CreateLocomotiveRotHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateLocomotiveRot cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);


            var existinglocomotive = EventRepository.GetById<Domain.TipoOggettoIntervento.LocomotiveRot>(cmd.Id);

            if (!existinglocomotive.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            var locomotive = new Domain.TipoOggettoIntervento.LocomotiveRot(cmd.Id,cmd.Description, cmd.Sign, cmd.IdGruppoOggettoIntervento);

            EventRepository.Save(locomotive, cmd.CommitId);


            return locomotive.CommandValidationMessages;
        }

    }
}
