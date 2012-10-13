using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.MeasuringUnit;
using Super.Contabilita.Events;
using Super.Contabilita.Handlers.Commands.MeasuringUnit;

namespace Super.Contabilita.Specs.MeasuringUnit
{
    public class Aggiornamento_di_una_unita_di_misura_gia_creata : CommandBaseClass<UpdateMeasuringUnit>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        
        private string _descriptionUpdated = "test 2";

        
        protected override CommandHandler<UpdateMeasuringUnit> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateMeasuringUnitHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return  BuildEvt.MeasuringUnitCreated
                                   .ForDescription(_description)
                                   .Build(_id,1);
        }

        public override UpdateMeasuringUnit When()
        {
            return BuildCmd.UpdateMeasuringUnit
                            .ForDescription(_descriptionUpdated)
                            .Build(_id,1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.MeasuringUnitUpdated
                .ForDescription(_descriptionUpdated)
                .Build(_id,2);
                            
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
