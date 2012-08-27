using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Impianto;
using Super.Contabilita.Commands.Intervento;
using Super.Contabilita.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using BuildCmd = Super.Contabilita.Commands.Builders.Build;
using BuildEvt = Super.Contabilita.Events.Builders.Build;

namespace Super.Contabilita.Specs.Impianto
{
    public class Calcolo_di_intervento_rotabile : CommandBaseClass<CalculateInterventoRotPriceOfPlan>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private DateTime _creationDate = DateTime.Now;
        private long _version;
        private Guid _idLotto = Guid.NewGuid();
        private Interval _interval = new Interval(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));

        private string _descriptionUpdated = "test 2";
        private Interval _intervalUpdated = new Interval(DateTime.Now.AddHours(14), DateTime.Now.AddHours(15));



        protected override CommandHandler<CalculateInterventoRotPriceOfPlan> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateImpiantoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return  BuildEvt.ImpiantoCreated
                                   .ForCreationDate(_creationDate)
                                   .ForDescription(_descriptionUpdated)
                                   .ForInterval(_interval)
                                   .ForLotto(_idLotto)
                                   .Build(_id,1);
        }

        public override CalculateInterventoRotPriceOfPlan When()
        {
            return BuildCmd.CalculateInterventoRotPriceOfPlan
                            .ForInterval(_intervalUpdated)
                            .ForDescription(_descriptionUpdated)
                            .Build(_id,1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.ImpiantoUpdated
                .ForDescription(_descriptionUpdated)
                .ForInterval(_intervalUpdated)
                .Build(_id,2);
                            
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
