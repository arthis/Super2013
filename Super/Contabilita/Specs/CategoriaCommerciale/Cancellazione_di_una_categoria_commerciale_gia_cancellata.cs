﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.CategoriaCommerciale;
using BuildEvt = Super.Contabilita.Events.Builders.Build;
using BuildCmd = Super.Contabilita.Commands.Builders.Build;
using Super.Contabilita.Handlers.CategoriaCommerciale;

namespace Super.Contabilita.Specs.CategoriaCommerciale
{
    public class Cancellazione_di_una_categoria_commerciale_gia_cancellata : CommandBaseClass<DeleteCategoriaCommerciale>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        

        protected override CommandHandler<DeleteCategoriaCommerciale> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteCategoriaCommercialeHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.CategoriaCommercialeCreated
                .ForDescription(_description)
                .Build(_id,1);
            yield return BuildEvt.CategoriaCommercialeDeleted
                .Build(_id, 2);
        }

        public override DeleteCategoriaCommerciale When()
        {
            return BuildCmd.DeleteCategoriaCommerciale
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