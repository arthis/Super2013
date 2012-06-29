using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Domain;

namespace Super.Appaltatore.Handlers
{
    public class ConsuntivareRotResoHandler : CommandHandler<ConsuntivareRotReso>
    {
        public ConsuntivareRotResoHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(ConsuntivareRotReso cmd, ICommandHandler<ConsuntivareRotReso> next)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

           var existingIntervento = EventRepository.GetById<InterventoRot>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new HandlerForDomainEventNotFoundException();

            existingIntervento.ConsuntivareReso(cmd.Id
                                , cmd.DataConsuntivazione
                                , WorkPeriod.FromMessage(cmd.Period)
                                , cmd.IdInterventoAppaltatore
                                , cmd.Note
                                ,cmd.Oggetti.ToValueObject()
                                ,cmd.Convoglio
                                ,Treno.FromMessage(cmd.TrenoPartenza)
                                , Treno.FromMessage(cmd.TrenoArrivo)
                                , cmd.RigaTurnoTreno
                                , cmd.TurnoTreno);


            EventRepository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages;
        }
    }
}