using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Controllo.Commands;
using CommonSpecs;
using Super.Controllo.Commands.Builders;
using Super.Controllo.Events;
using Super.Controllo.Events.Builders;
using Super.Controllo.Handlers;
using BuildCmd = Super.Controllo.Commands.Builders.Build;

namespace Super.Controllo.Specs.Controllo_intervento_non_reso
{
    public class Controllare_un_intervento_non_reso : CommandBaseClass<ControlInterventoNonReso>
    {
        private Guid _Id = Guid.NewGuid();
        private DateTime _controlDate = DateTime.Now;
        private Guid _idUser = Guid.NewGuid();
        private Guid _idCausale = Guid.NewGuid();
        private string _note = "note";


        protected override CommandHandler<ControlInterventoNonReso> OnHandle(IEventRepository eventRepository)
        {
            return new ControlInterventoNonResoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.InterventoControlAllowed
                .Build(_Id, 1);
        }

        public override ControlInterventoNonReso When()
        {

            return BuildCmd.ControlInterventoNonReso
                .By(_idUser)
                .Because(_idCausale)
                .When(_controlDate)
                .WithNote(_note)
                .Build(_Id,1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.InterventoControlledNonReso
                .By(_idUser)
                .Because(_idCausale)
                .When(_controlDate)
                .WithNote(_note)
                .Build(_Id,2);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
