using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Handlers.TipoOggettoIntervento.Rotabile
{
    public class DeleteTipoOggettoInterventoRotHandler : CommandHandler<DeleteTipoOggettoInterventoRot>
    {
        public DeleteTipoOggettoInterventoRotHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(DeleteTipoOggettoInterventoRot cmd)
        {
            Contract.Requires(cmd != null);

            var tipoOggettoIntervento= EventRepository.GetById<Domain.TipoOggettoIntervento.TipoOgettoInterventoRot>(cmd.Id);

            if (tipoOggettoIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            tipoOggettoIntervento.Delete();

            EventRepository.Save(tipoOggettoIntervento, cmd.CommitId);

            return tipoOggettoIntervento.CommandValidationMessages;
        }
    }
}
