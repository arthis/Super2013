using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Handlers.Commands.Schedulazione.Ambiente
{
    public partial class AddRuleToSchedulazioneAmbHandler: CommandHandler<AddRuleToSchedulazioneAmb>
    {
        public AddRuleToSchedulazioneAmbHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(AddRuleToSchedulazioneAmb cmd)
        {

            throw  new NotImplementedException();
            //Contract.Requires(cmd != null);

            //var schedulazione = EventRepository.GetById<Domain.SchedulazioneAmb>(cmd.Id);

            //if (schedulazione.IsNull())
            //    throw new AggregateRootInstanceNotFoundException();

            //schedulazione.

            //EventRepository.Save(existingIntervento, cmd.CommitId);

            //return existingIntervento.CommandValidationMessages; 
        }
    }
}
