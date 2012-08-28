using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Commands.TipoOggettoIntervento.RotabileInManutenzione;
using Super.Contabilita.Handlers.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Specs.TipoOggettoIntervento.RotabileInManuenzione
{
    public class Aggiornamento_di_una_carrozza_rotabile_in_mantenzione_non_esistente : CommandBaseClass<UpdateCarriageRotMan>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private const bool _isInternational = true;
        private const string _sign = "sign";

        protected override CommandHandler<UpdateCarriageRotMan> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateCarriageRotManHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override UpdateCarriageRotMan When()
        {

            return Build.UpdateCarriageRotMan
                         .ForDescription(_description)
                         .ForSign(_sign)
                         .IsInternational(_isInternational)
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
            Assert.AreEqual(typeof(AggregateRootInstanceNotFoundException), Caught.GetType());
        }


    }
}
