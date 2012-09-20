using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.GruppoOggettoIntervento;
using Super.Contabilita.Domain;

namespace Super.Contabilita.Handlers.GruppoOggettoIntervento
{

    public class CreateGruppoOggettoInterventoHandler : CommandHandler<CreateGruppoOggettoIntervento>
    {
        public CreateGruppoOggettoInterventoHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateGruppoOggettoIntervento cmd)
        {
            Contract.Requires(cmd != null);
            

            var existingGruppoOggettoIntervento = EventRepository.GetById<Domain.GruppoOggettoIntervento>(cmd.Id);

            if (!existingGruppoOggettoIntervento.IsNull())
                throw new AlreadyCreatedAggregateRootException();



            var gruppoOggettoIntervento = new Domain.GruppoOggettoIntervento(cmd.Id,
                                          cmd.Description);

            EventRepository.Save(gruppoOggettoIntervento, cmd.CommitId);


            return gruppoOggettoIntervento.CommandValidationMessages;
        }

    }

 
}
