using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.Builders;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.GruppoOggettoIntervento;

namespace Super.Contabilita.Handlers.GruppoOggettoIntervento
{
    public class UpdateGruppoOggettoInterventoHandler : CommandHandler<UpdateGruppoOggettoIntervento>
    {
        public UpdateGruppoOggettoInterventoHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(UpdateGruppoOggettoIntervento cmd)
        {
            Contract.Requires(cmd != null);

            var gruppoOggettoIntervento = EventRepository.GetById<Domain.GruppoOggettoIntervento>(cmd.Id);

            if (gruppoOggettoIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            gruppoOggettoIntervento.Update( cmd.Description);

            EventRepository.Save(gruppoOggettoIntervento, cmd.CommitId);

            return gruppoOggettoIntervento.CommandValidationMessages;
        }
      
    }
}
