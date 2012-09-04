using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.CategoriaCommerciale;
using Super.Contabilita.Events;
using Super.Contabilita.Handlers.CategoriaCommerciale;

namespace Super.Contabilita.Specs.CategoriaCommerciale
{
    public class Creazione_di_una_nuova_categoria_commerciale_gia_creata : CommandBaseClass<CreateCategoriaCommerciale>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";

        public override string ToDescription()
        {
            return "Creare un'categoria_commerciale gia creata con il stesso Guid non é possibile";
        }
       

        protected override CommandHandler<CreateCategoriaCommerciale> OnHandle(IEventRepository eventRepository)
        {
            return new CreateCategoriaCommercialeHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.CategoriaCommercialeCreated
                .ForDescription(_description)
                .Build(_id, 1);
        }

        public override CreateCategoriaCommerciale When()
        {
            return BuildCmd.CreateCategoriaCommerciale
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
            Assert.AreEqual(typeof(AlreadyCreatedAggregateRootException), Caught.GetType());
        }


    }
}
