using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoOggettoIntervento.Ambiente;
using Super.Contabilita.Commands.TipoOggettoIntervento.Ambiente;
using Super.Contabilita.Domain.TipoOggettoIntervento;

namespace Super.Contabilita.Handlers.TipoOggettoIntervento.Ambiente
{
    public class DeleteTipoOggettoInterventoAmbHandler : CommandHandler<DeleteTipoOggettoInterventoAmb>
    {
        public DeleteTipoOggettoInterventoAmbHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(DeleteTipoOggettoInterventoAmb cmd)
        {
            Contract.Requires(cmd != null);

            var tipoOggettoIntervento= EventRepository.GetById<TipoOggettoInterventoAmb>(cmd.Id);

            if (tipoOggettoIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            tipoOggettoIntervento.Delete();

            EventRepository.Save(tipoOggettoIntervento, cmd.CommitId);

            return tipoOggettoIntervento.CommandValidationMessages;
        }
    }
}
