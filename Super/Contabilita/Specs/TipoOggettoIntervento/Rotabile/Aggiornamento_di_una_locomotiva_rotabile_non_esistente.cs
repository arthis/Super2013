using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile;
using Super.Contabilita.Handlers.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Specs.TipoOggettoIntervento.Rotabile
{
    public class Aggiornamento_di_una_locomotiva_rotabile_non_esistente : CommandBaseClass<UpdateLocomotiveRot>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private const string _sign = "sign";
        private readonly Guid _idGruppoOggettoIntervento = Guid.NewGuid();

        protected override CommandHandler<UpdateLocomotiveRot> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateLocomotiveRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override UpdateLocomotiveRot When()
        {

            return BuildCmd.UpdateLocomotiveRot
                         .ForDescription(_description)
                         .ForSign(_sign)
                         .ForGruppoOggetto(_idGruppoOggettoIntervento)
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
            Assert.AreEqual(typeof(AggregateRootInstanceNotFoundException), Caught.GetType());
        }


    }
}
