using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoOggettoIntervento.Ambiente;

namespace Super.Contabilita.Handlers.TipoOggettoIntervento.Ambiente
{

    public class CreateTipoOggettoInterventoAmbHandler : CommandHandler<CreateTipoOggettoInterventoAmb>
    {
        public CreateTipoOggettoInterventoAmbHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateTipoOggettoInterventoAmb cmd)
        {
            Contract.Requires(cmd != null);
            

            var existingTipoOggettoInterventoAmb = EventRepository.GetById<Domain.TipoOggettoIntervento.TipoOggettoInterventoAmb>(cmd.Id);

            if (!existingTipoOggettoInterventoAmb.IsNull())
                throw new AlreadyCreatedAggregateRootException();


            var tipoOggettoIntervento = new Domain.TipoOggettoIntervento.TipoOggettoInterventoAmb(cmd.Id, cmd.Description,cmd.Sign, cmd.IdGruppoOggettoIntervento);

            EventRepository.Save(tipoOggettoIntervento, cmd.CommitId);


            return tipoOggettoIntervento.CommandValidationMessages;
        }

    }

 
}
