using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Appaltatore;
using BuildCmd = Super.Contabilita.Commands.Build;
using BuildEvt = Super.Contabilita.Events.Build;
using Super.Contabilita.Handlers.Appaltatore;

namespace Super.Contabilita.Specs.Appaltatore
{
    public class Creazione_di_uno_nuovo_appaltatore_gia_creato : CommandBaseClass<CreateAppaltatore>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";

        public override string ToDescription()
        {
            return "Creare un'appaltatore gia creata con il stesso Guid non é possibile";
        }
       

        protected override CommandHandler<CreateAppaltatore> OnHandle(IEventRepository eventRepository)
        {
            return new CreateAppaltatoreHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.AppaltatoreCreated
                .ForDescription(_description)
                .Build(_id, 1);
        }

        public override CreateAppaltatore When()
        {
            return BuildCmd.CreateAppaltatore
                .ForDescription(_description)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(AlreadyCreatedAggregateRootException), Caught.GetType());
        }


    }
}
