using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.bachibouzouk;
using Super.Contabilita.Domain.bachibouzouk;

namespace Super.Contabilita.Handlers.bachiBouzouk
{

    public class CreatebachibouzoukHandler : CommandHandler<Createbachibouzouk>
    {
        public CreatebachibouzoukHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(Createbachibouzouk cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);
            

            var existingbachibouzouk = EventRepository.GetById<bachibouzouk>(cmd.Id);

            if (!existingbachibouzouk.IsNull())
                throw new AlreadyCreatedAggregateRootException();



            var bachibouzouk = new bachibouzouk(cmd.Id);

            EventRepository.Save(bachibouzouk, cmd.CommitId);


            return bachibouzouk.CommandValidationMessages;
        }

    }

 
}

