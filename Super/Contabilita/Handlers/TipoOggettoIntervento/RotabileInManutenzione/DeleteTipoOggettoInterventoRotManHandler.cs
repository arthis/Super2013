using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Handlers.TipoOggettoIntervento.RotabileInManutenzione
{
    public class DeleteTipoOggettoInterventoRotManHandler : CommandHandler<DeleteTipoOggettoInterventoRotMan>
    {
        public DeleteTipoOggettoInterventoRotManHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(DeleteTipoOggettoInterventoRotMan cmd)
        {
            Contract.Requires(cmd != null);

            var tipoOggettoIntervento= EventRepository.GetById<Domain.TipoOggettoIntervento.TipoOgettoInterventoRotMan>(cmd.Id);

            if (tipoOggettoIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            tipoOggettoIntervento.Delete();

            EventRepository.Save(tipoOggettoIntervento, cmd.CommitId);

            return tipoOggettoIntervento.CommandValidationMessages;
        }
    }
}
