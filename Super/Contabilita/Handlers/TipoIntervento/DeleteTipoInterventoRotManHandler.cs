using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Handlers.TipoIntervento
{
    public class DeleteTipoInterventoRotManHandler : CommandHandler<DeleteTipoInterventoRotMan>
    {
        public DeleteTipoInterventoRotManHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(DeleteTipoInterventoRotMan cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var tipoIntervento= EventRepository.GetById<Domain.TipoInterventoRotMan>(cmd.Id);

            if (tipoIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            tipoIntervento.Delete();

            EventRepository.Save(tipoIntervento, cmd.CommitId);

            return tipoIntervento.CommandValidationMessages;
        }
    }
}
