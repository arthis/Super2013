using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoIntervento.Rotabile;

namespace Super.Contabilita.Handlers.Commands.TipoIntervento
{
    public class DeleteTipoInterventoRotHandler : CommandHandler<DeleteTipoInterventoRot>
    {
        public DeleteTipoInterventoRotHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(DeleteTipoInterventoRot cmd)
        {
            Contract.Requires(cmd != null);

            var tipoIntervento= EventRepository.GetById<Domain.TipoInterventoRot>(cmd.Id);

            if (tipoIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            tipoIntervento.Delete();

            EventRepository.Save(tipoIntervento, cmd.CommitId);

            return tipoIntervento.CommandValidationMessages;
        }
    }
}
