﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Scenario;
using Super.Programmazione.Events;
using Super.Programmazione.Handlers.Commands.Scenario;

namespace Super.Programmazione.Specs.Scenario
{
    public class Creare_un_scenario_gia_creato : CommandBaseClass<CreateScenario>
    {
        private Guid _Id = Guid.NewGuid();
        private Guid _idUser = Guid.NewGuid();
        private string _descritpion = "description";

        protected override CommandHandler<CreateScenario> OnHandle(IEventRepository eventRepository)
        {
            var sessionFactory = new FakeSessionFactory(_idUser);
            return new CreateScenarioHandler(eventRepository, sessionFactory);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.UserAddedToSystem
               .ForPassword("p")
               .ForUserName("u")
               .WithFirstName("f")
               .WithLastName("l")
               .Build(_idUser, 1);

            yield return BuildEvt.ScenarioCreated
                .ByUser(_idUser)
                .ForDescription(_descritpion)
                .Build(_Id,1);
        }

        public override CreateScenario When()
        {
            return BuildCmd.CreateScenario
                        .WithDescription(_descritpion)
                        .Build(_Id, 1);
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