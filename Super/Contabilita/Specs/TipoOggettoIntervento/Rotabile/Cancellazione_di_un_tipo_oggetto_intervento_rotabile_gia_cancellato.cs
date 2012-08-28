using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Handlers.TipoOggettoIntervento.Rotabile;


namespace Super.Contabilita.Specs.TipoOggettoIntervento.Rotabile
{
    public class Cancellazione_di_un_tipo_oggetto_intervento_rotabile_gia_cancellato : CommandBaseClass<DeleteTipoOggettoInterventoRot>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private const string _sign = "sign";
        

        protected override CommandHandler<DeleteTipoOggettoInterventoRot> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteTipoOggettoInterventoRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return Build.LocomotiveRotCreated
                .ForDescription(_description)
                .ForSign(_sign)
                .Build(_id,1);
            yield return Build.TipoOggettoInterventoRotDeleted
                .Build(_id, 2);
        }

        public override DeleteTipoOggettoInterventoRot When()
        {
            return Commands.Builders.Build.DeleteTipoOggettoInterventoRot
                .Build(_id, 2);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
