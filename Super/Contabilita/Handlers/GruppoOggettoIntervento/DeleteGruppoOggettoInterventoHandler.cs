using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.GruppoOggettoIntervento;

namespace Super.Contabilita.Handlers.GruppoOggettoIntervento
{
    public class DeleteGruppoOggettoInterventoHandler : CommandHandler<DeleteGruppoOggettoIntervento>
    {
        public DeleteGruppoOggettoInterventoHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(DeleteGruppoOggettoIntervento cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var gruppoOggettoIntervento= EventRepository.GetById<Domain.GruppoOggettoIntervento>(cmd.Id);

            if (gruppoOggettoIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            gruppoOggettoIntervento.Delete();

            EventRepository.Save(gruppoOggettoIntervento, cmd.CommitId);

            return gruppoOggettoIntervento.CommandValidationMessages;
        }
    }
}
