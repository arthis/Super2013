using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.CategoriaCommerciale;
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Handlers;
using Super.Contabilita.Handlers.Commands.CategoriaCommerciale;

namespace Super.Contabilita.Specs.CategoriaCommerciale
{
    public class Aggiornamento_di_una_categoria_commerciale_non_esistente : CommandBaseClass<UpdateCategoriaCommerciale>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";

        protected override CommandHandler<UpdateCategoriaCommerciale> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateCategoriaCommercialeHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override UpdateCategoriaCommerciale When()
        {

            return  BuildCmd.UpdateCategoriaCommerciale
                         .ForDescription(_description)
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
