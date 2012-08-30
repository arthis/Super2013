using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Appaltatore;
using Super.Contabilita.Handlers.Appaltatore;
using BuildCmd = Super.Contabilita.Commands.Build;
using BuildEvt = Super.Contabilita.Events.Build;

namespace Super.Contabilita.Specs.Appaltatore
{
    public class Aggiornamento_di_una_appaltatore_gia_creata : CommandBaseClass<UpdateAppaltatore>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        
        private string _descriptionUpdated = "test 2";

        
        protected override CommandHandler<UpdateAppaltatore> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateAppaltatoreHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return  BuildEvt.AppaltatoreCreated
                                   .ForDescription(_description)
                                   .Build(_id,1);
        }

        public override UpdateAppaltatore When()
        {
            return BuildCmd.UpdateAppaltatore
                            .ForDescription(_descriptionUpdated)
                            .Build(_id,1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.AppaltatoreUpdated
                .ForDescription(_descriptionUpdated)
                .Build(_id,2);
                            
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
