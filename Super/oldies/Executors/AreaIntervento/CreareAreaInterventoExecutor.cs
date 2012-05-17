﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cqrs.Commanding.CommandExecution;
using Commands;
using Cqrs.Domain;
using Commands.AreaIntervento;
using Domain;


namespace Executors
{
    public class CreareAreaInterventoExecutor : CommandExecutorBase<CreareNuovoAreaIntervento>
    {
        public CreareAreaInterventoExecutor(IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
        }

        protected override void ExecuteInContext(IUnitOfWorkContext context, CreareNuovoAreaIntervento command)
        {
            // Perform The creation
            AreaIntervento ai = new AreaIntervento(command.Id, command.IdAreaInterventoSuper, command.Inizio, command.Fine, command.CreationDate, command.Descrizione);

            // Accept all the work we just did.
            context.Accept();
        }
    }
}