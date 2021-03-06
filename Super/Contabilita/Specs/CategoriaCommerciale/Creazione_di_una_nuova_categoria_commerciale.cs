﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.CategoriaCommerciale;
using Super.Contabilita.Events;
using Super.Contabilita.Handlers.Commands.CategoriaCommerciale;

namespace Super.Contabilita.Specs.CategoriaCommerciale
{
    public class Creazione_di_una_nuova_categoria_commerciale : CommandBaseClass<CreateCategoriaCommerciale>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        

        protected override CommandHandler<CreateCategoriaCommerciale> OnHandle(IEventRepository eventRepository)
        {
            return new CreateCategoriaCommercialeHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override CreateCategoriaCommerciale When()
        {
            return BuildCmd.CreateCategoriaCommerciale
                .WithDescription(_description)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.CategoriaCommercialeCreated
                                 .ForDescription(_description)
                                 .Build(_id,1);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
