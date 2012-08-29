﻿using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Handlers.TipoOggettoIntervento.RotabileInManutenzione
{

    public class CreateLocomotiveRotManHandler : CommandHandler<CreateLocomotiveRotMan>
    {
        public CreateLocomotiveRotManHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateLocomotiveRotMan cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);


            var existinglocomotive = EventRepository.GetById<Domain.TipoOggettoIntervento.LocomotiveRotMan>(cmd.Id);

            if (!existinglocomotive.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            var locomotive = new Domain.TipoOggettoIntervento.LocomotiveRotMan(cmd.Id, cmd.Description, cmd.Sign);

            EventRepository.Save(locomotive, cmd.CommitId);


            return locomotive.CommandValidationMessages;
        }

    }
}
