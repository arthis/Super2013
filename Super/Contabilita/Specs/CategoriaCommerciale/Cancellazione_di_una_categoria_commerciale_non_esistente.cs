using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.CategoriaCommerciale;
using BuildCmd = Super.Contabilita.Commands.Build;
using BuildEvt = Super.Contabilita.Events.Build;
using Super.Contabilita.Handlers.CategoriaCommerciale;

namespace Super.Contabilita.Specs.CategoriaCommerciale
{
    public class Cancellazione_di_una_categoria_commerciale_non_esistente : CommandBaseClass<DeleteCategoriaCommerciale>
    {
        private Guid _id = Guid.NewGuid();

        protected override CommandHandler<DeleteCategoriaCommerciale> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteCategoriaCommercialeHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override DeleteCategoriaCommerciale When()
        {
            return BuildCmd.DeleteCategoriaCommerciale
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
