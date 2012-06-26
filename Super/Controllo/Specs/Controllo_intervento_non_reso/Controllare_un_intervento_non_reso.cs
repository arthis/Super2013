using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Controllo.Commands;
using CommonSpecs;
using Super.Controllo.Commands.Builders;
using Super.Controllo.Events;
using Super.Controllo.Events.Builders;
using Super.Controllo.Handlers;
using BuildCmd = Super.Controllo.Commands.Builders.Build;
using BuildEvt = Super.Controllo.Events.Builders.Build;

namespace Super.Controllo.Specs.Controllo_intervento_non_reso
{
    public class Controllare_un_intervento_non_reso : CommandBaseClass<ControlInterventoNonReso>
    {
        private Guid _Id = Guid.NewGuid();
        private DateTime _controlDate = DateTime.Now;
        private Guid _idUtente = Guid.NewGuid();
        private Guid _idCausale = Guid.NewGuid();
        private string _note = "note";


        protected override CommandHandler<ControlInterventoNonReso> OnHandle(IRepository repository)
        {
            return new ControlInterventoNonResoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return new InterventoControlAllowed()
            {
                Id = _Id
            };
        }

        public override ControlInterventoNonReso When()
        {

            return BuildCmd.ControlInterventoNonReso
                .By(_idUtente)
                .Because(_idCausale)
                .When(_controlDate)
                .WithNote(_note)
                .Build(_Id);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.InterventoControlledNonReso
                .By(_idUtente)
                .Because(_idCausale)
                .When(_controlDate)
                .WithNote(_note)
                .Build(_Id);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
