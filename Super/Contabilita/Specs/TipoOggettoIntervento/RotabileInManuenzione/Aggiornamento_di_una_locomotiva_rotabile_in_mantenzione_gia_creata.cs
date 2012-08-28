using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.TipoOggettoIntervento.RotabileInManutenzione;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Handlers.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Specs.TipoOggettoIntervento.RotabileInManuenzione
{
    public class Aggiornamento_di_una_locomotiva_rotabile_in_mantenzione_gia_creata : CommandBaseClass<UpdateLocomotiveRotMan>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private const string _sign = "sign";
        
        private string _descriptionUpdated = "test 2";
        private const string _signUpdated = "sign 2";

        protected override CommandHandler<UpdateLocomotiveRotMan> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateLocomotiveRotManHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return Build.LocomotiveRotManCreated
                .ForDescription(_description)
                .ForSign(_sign)
                .Build(_id, 1);
        }

        public override UpdateLocomotiveRotMan When()
        {
            return Commands.Builders.Build.UpdateLocomotiveRotMan
                .ForDescription(_descriptionUpdated)
                .ForSign(_signUpdated)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return Build.LocomotiveRotManUpdated
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
