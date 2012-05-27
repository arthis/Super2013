﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Administration.Commands.AreaIntervento;
using Super.Administration.Events.AreaIntervento;
using Super.Administration.Handlers;

namespace Super.Administration.Specs.AreaIntervento
{
    public class Aggiornamento_di_una_area_intervento_gia_creata : CommandBaseClass<UpdateAreaIntervento>
    {
        private Guid _Id = Guid.NewGuid();
        private string _Description = "test";
        private DateTime _Start = DateTime.Now.AddHours(12);
        private DateTime _End = DateTime.Now.AddHours(13);
        private DateTime _CreationDate = DateTime.Now;

        private string _DescriptionUpdated = "test 2";
        private DateTime _StartUpdated = DateTime.Now.AddHours(14);
        private DateTime _EndUpdated = DateTime.Now.AddHours(15);

        
        protected override CommandHandler<UpdateAreaIntervento> OnHandle(IRepository repository)
        {
            return new UpdateAreaInterventoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return new AreaInterventoCreated()
            {
                Id = _Id,
                Description = _Description,
                CreationDate = _CreationDate,
                End = _End,
                Start = _Start
            };
        }

        public override UpdateAreaIntervento When()
        {
            return new UpdateAreaIntervento()
                       {
                           Id = _Id,
                           Start = _StartUpdated,
                           End = _EndUpdated,
                           Description = _DescriptionUpdated,
                           Headers = _Headers
                       };
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return new AreaInterventoUpdated()
            {
                Id = _Id,
                Start = _StartUpdated,
                End = _EndUpdated,
                Description = _DescriptionUpdated,
                Headers = _Headers
            };
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}