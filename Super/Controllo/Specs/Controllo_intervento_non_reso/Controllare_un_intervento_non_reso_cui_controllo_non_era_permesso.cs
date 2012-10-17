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
using Super.Controllo.Commands.Consuntivazione;
using Super.Controllo.Events;
using Super.Controllo.Handlers;

namespace Super.Controllo.Specs.Controllo_intervento_non_reso
{
    public class Controllare_un_intervento_non_reso_cui_controllo_non_era_permesso : CommandBaseClass<ControlNonResoIntervento>
    {
        private Guid _Id = Guid.NewGuid();
        private DateTime _controlDate = DateTime.Now;
        private Guid _idUser = Guid.NewGuid();
        private Guid _idCausale = Guid.NewGuid();
        private string _note = "note";


        protected override CommandHandler<ControlNonResoIntervento> OnHandle(IEventRepository eventRepository)
        {
            return new ControlResoInterventoNonHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override ControlNonResoIntervento When()
        {
            return BuildCmd.ControlNonResoIntervento
                .By(_idUser)
                .Because(_idCausale)
                .When(_controlDate)
                .WithNote(_note)
                .Build(_Id,0);
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
