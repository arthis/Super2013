using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoOggettoIntervento.Ambiente;

namespace Super.Contabilita.Handlers.TipoOggettoIntervento.Ambiente
{
    public class UpdateTipoOggettoInterventoAmbHandler : CommandHandler<UpdateTipoOggettoInterventoAmb>
    {
        public UpdateTipoOggettoInterventoAmbHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(UpdateTipoOggettoInterventoAmb cmd)
        {
            Contract.Requires(cmd != null);

            var tipoOggettoIntervento = EventRepository.GetById<Domain.TipoOggettoIntervento.TipoOggettoInterventoAmb>(cmd.Id);

            if (tipoOggettoIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            tipoOggettoIntervento.Update(cmd.Description, cmd.Sign, cmd.IdGruppoOggettoIntervento);

            EventRepository.Save(tipoOggettoIntervento, cmd.CommitId);

            return tipoOggettoIntervento.CommandValidationMessages;
        }
      
    }
}
