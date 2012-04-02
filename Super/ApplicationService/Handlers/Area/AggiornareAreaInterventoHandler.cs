using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Commands.AreaIntervento;
using NServiceBus;
using System.Diagnostics.Contracts;
using Cqrs.Domain;
using Domain;

namespace ApplicationService.Handlers.Area
{

    public class AggiornareAreaInterventoHandler :  IHandleMessages<AggiornareAreaIntervento>
    {

         /// <summary>
        /// Holds the <see cref="IUnitOfWorkFactory"/>. This instance should never be null.
        /// </summary>
        protected readonly IUnitOfWorkFactory _factory;

        public AggiornareAreaInterventoHandler(IUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null) throw new ArgumentNullException("unitOfWorkFactory");
        }

        public void Handle(AggiornareAreaIntervento command)
        {
            Contract.Requires<ArgumentNullException>(command != null, "The command cannot be null.");

            using (var context = _factory.CreateUnitOfWork(command.CommandIdentifier))
            {
                // Get the object
                var area = context.GetById<AreaIntervento>(command.Id);

                // Perform The action
                area.Aggiornare(command.IdAreaInterventoSuper, command.Inizio, command.Fine, command.Descrizione);

                // Accept all the work we just did.
                context.Accept();
            }

        }
    }
}
