using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Handlers.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Specs.TipoOggettoIntervento.Rotabile
{
    public class Aggiornamento_di_una_locomotiva_rotabile_gia_creata : CommandBaseClass<UpdateLocomotiveRot>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private const string _sign = "sign";
        
        private string _descriptionUpdated = "test 2";
        private const string _signUpdated = "sign 2";

        protected override CommandHandler<UpdateLocomotiveRot> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateLocomotiveRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return Build.LocomotiveRotCreated
                .ForDescription(_description)
                .ForSign(_sign)
                .Build(_id, 1);
        }

        public override UpdateLocomotiveRot When()
        {
            return Commands.Builders.Build.UpdateLocomotiveRot
                .ForDescription(_descriptionUpdated)
                .ForSign(_signUpdated)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return Build.LocomotiveRotUpdated
                .ForDescription(_descriptionUpdated)
                .ForSign(_signUpdated)
                .Build(_id,2);
                            
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
