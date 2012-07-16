using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Impianto;
using Super.Contabilita.Events.Impianto;
using Super.Contabilita.Handlers;
using BuildCmd = Super.Contabilita.Commands.Builders.Build;
using BuildEvt = Super.Contabilita.Events.Builders.Build;

namespace Super.Contabilita.Specs.Impianto
{
    public class Creazione_di_uno_nuovo_impianto_gia_creato : CommandBaseClass<CreateImpianto>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private DateTime _creationDate = DateTime.Now;
        private long _version;
        private Intervall _intervall = new Intervall(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));
        private Guid _idLotto = Guid.NewGuid();
        private Intervall _intervallLotto = new Intervall(DateTime.Now, DateTime.Now.AddHours(4));

        public override string ToDescription()
        {
            return "Creare un'impianto gia creata con il stesso Guid non é possibile";
        }
       

        protected override CommandHandler<CreateImpianto> OnHandle(IEventRepository eventRepository)
        {
            return new CreateImpiantoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.LottoCreated
                .ForCreationDate(DateTime.Now)
                .ForDescription("lotto")
                .ForIntervall(_intervallLotto)
                .Build(_idLotto, 0);
            yield return BuildEvt.ImpiantoCreated
                .ForIntervall(_intervall)
                .ForDescription(_description)
                .ForCreationDate(_creationDate)
                .ForLotto(_idLotto)
                .Build(_id, 1);
        }

        public override CreateImpianto When()
        {
            return BuildCmd.CreateImpianto
                .ForIntervall(_intervall)
                .ForLotto(_idLotto)
                .ForDescription(_description)
                .ForCreationDate(_creationDate)
                .Build(_id,0);
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
