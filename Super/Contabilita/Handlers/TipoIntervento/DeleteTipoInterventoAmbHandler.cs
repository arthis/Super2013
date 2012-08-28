using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoIntervento.Ambiente;

namespace Super.Contabilita.Handlers.TipoIntervento
{
    public class DeleteTipoInterventoAmbHandler : CommandHandler<DeleteTipoInterventoAmb>
    {
        public DeleteTipoInterventoAmbHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(DeleteTipoInterventoAmb cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var tipoIntervento= EventRepository.GetById<Domain.TipoInterventoAmb>(cmd.Id);

            if (tipoIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            tipoIntervento.Delete();

            EventRepository.Save(tipoIntervento, cmd.CommitId);

            return tipoIntervento.CommandValidationMessages;
        }
    }
}
