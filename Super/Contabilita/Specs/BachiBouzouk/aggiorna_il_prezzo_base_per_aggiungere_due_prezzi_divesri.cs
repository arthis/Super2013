using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Appaltatore;
using Super.Contabilita.Commands.bachibouzouk;
using Super.Contabilita.Events;
using Super.Contabilita.Handlers.Appaltatore;
using Super.Contabilita.Handlers.bachiBouzouk;

namespace Super.Contabilita.Specs.BachiBouzouk
{
    public class aggiorna_il_prezzo_base_per_aggiungere_due_prezzi_divesri : CommandBaseClass<UpdateBasePrice>
    {
        private readonly Guid _id = Guid.NewGuid();

        private readonly Guid _idGruppoOggettoIntervento1 = Guid.NewGuid();
        private readonly IntervalOpened _interval1 = new IntervalOpened(DateTime.Parse("01/08/2012"), DateTime.Parse("01/09/2012"));
        private readonly Guid _idTipoIntervento1= Guid.NewGuid();
        private const decimal _value1 = 25;

        private readonly Guid _idGruppoOggettoIntervento2 = Guid.NewGuid();
        private readonly IntervalOpened _interval2 = new IntervalOpened(DateTime.Parse("01/10/2012"), DateTime.Parse("01/09/2013"));
        private readonly Guid _idTipoIntervento2 = Guid.NewGuid();
        private const decimal _value2 = 35.25M;


        protected override CommandHandler<UpdateBasePrice> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateBasePriceHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return  Build.bachibouzoukCreated
                                   .Build(_id,1);
            yield return Build.BasePriceUpdated
                .ForGruppoOggetto(_idGruppoOggettoIntervento1)
                .ForInterval(_interval1)
                .ForType(_idTipoIntervento1)
                .ForValue(_value1)
                .Build(_id, 2);
        }

        public override UpdateBasePrice When()
        {
            return Commands.Build.UpdateBasePrice
                            .ForGruppoOggetto(_idGruppoOggettoIntervento2)
                            .ForInterval(_interval2)
                            .ForType(_idTipoIntervento2)
                            .ForValue(_value2)
                            .Build(_id,2);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return Build.BasePriceUpdated
                .ForGruppoOggetto(_idGruppoOggettoIntervento2)
                .ForInterval(_interval2)
                .ForType(_idTipoIntervento2)
                .ForValue(_value2)
                .Build(_id,3);
                            
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }

       


    }
}
