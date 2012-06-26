using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
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
    public class Creazione_di_una_nuova_impianto_gia_creata : CommandBaseClass<CreateImpianto>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private DateTime _creationDate = DateTime.Now;
        private long _version;
        private Intervall _intervall = new Intervall(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));
        private Guid _idLotto = Guid.NewGuid();

        public override string ToDescription()
        {
            return "Creare un'impianto gia creata con il stesso Guid non é possibile";
        }
       

        protected override CommandHandler<CreateImpianto> OnHandle(IRepository repository)
        {
            return new CreateImpiantoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.ImpiantoCreated
                                .ForIntervall(_intervall)
                                .ForDescription(_description)
                                .ForCreationDate(_creationDate)
                                .ForLotto(_idLotto)
                                .Build(_id);
        }

        public override CreateImpianto When()
        {
            return BuildCmd.CreateImpianto
                .ForIntervall(_intervall)
                .ForDescription(_description)
                .ForCreationDate(_creationDate)
                .Build(_id);
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
