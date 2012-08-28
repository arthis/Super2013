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
    public class Aggiornamento_di_una_carrozza_rotabile_gia_creata : CommandBaseClass<UpdateCarriageRot>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private const string _sign = "sign";
        private const bool _isInternational = true;

        private string _descriptionUpdated = "test 2";
        private const string _signUpdated = "sign 2";
        private const bool _isInternationalUpdated = false;

        protected override CommandHandler<UpdateCarriageRot> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateCarriageRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return Build.CarriageRotCreated
                .ForDescription(_description)
                .ForSign(_sign)
                .IsInternational(_isInternational)
                .Build(_id, 1);
        }

        public override UpdateCarriageRot When()
        {
            return Commands.Builders.Build.UpdateCarriageRot
                .ForDescription(_descriptionUpdated)
                .ForSign(_signUpdated)
                .IsInternational(_isInternationalUpdated)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return Build.CarriageRotUpdated
                .ForDescription(_descriptionUpdated)
                .ForSign(_signUpdated)
                .IsInternational(_isInternationalUpdated)
                .Build(_id,2);
                            
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
