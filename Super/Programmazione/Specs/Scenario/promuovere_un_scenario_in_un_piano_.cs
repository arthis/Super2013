﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Scenario;
using Super.Programmazione.Events;
using Super.Programmazione.Handlers.Scenario;

namespace Super.Programmazione.Specs.Scenario
{
    public class promuovere_un_scenario_in_un_piano_ : CommandBaseClass<PromoteScenarioToPlan>
    {
        private Guid _id = Guid.NewGuid();
        
        private Guid _idUser = Guid.NewGuid();
        private string _descritpion = "description";

        private Guid _idUserPromoting = Guid.NewGuid();
        private DateTime _promotingDate = DateTime.Now;

        protected override CommandHandler<PromoteScenarioToPlan> OnHandle(IEventRepository eventRepository)
        {
            return new PromoteScenarioToPlanHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.ScenarioCreated
                .ByUser(_idUser)
                .ForDescription(_descritpion)
                .Build(_id, 1);
        }

        public override PromoteScenarioToPlan When()
        {
            return BuildCmd.PromoteScenarioToPlan
                        .ByUser(_idUserPromoting)
                        .When(_promotingDate)
                        .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.ScenarioPromotedToPlan
                .ByUser(_idUserPromoting)
                .When(_promotingDate)
                .Build(_id, 2);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
