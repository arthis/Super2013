using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Impianto;
using Super.Contabilita.Events.Impianto;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Handlers;

namespace Super.Contabilita.Specs.Impianto
{
    public class Cancellazione_di_una_impianto_gia_cancellata : CommandBaseClass<DeleteImpianto>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private DateTime _creationDate = DateTime.Now;
        private long _version;
        private Intervall _intervall = new Intervall(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));

        protected override CommandHandler<DeleteImpianto> OnHandle(IRepository repository)
        {
            return new DeleteImpiantoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return Build.ImpiantoCreated
                .ForIntervall(_intervall)
                .ForDescription(_description)
                .ForCreationDate(_creationDate)
                .Build(_id);
            yield return new ImpiantoDeleted()
            {
                Id = _id
            };
        }

        public override DeleteImpianto When()
        {
            return new DeleteImpianto()
                       {
                           Id = _id
                       };
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
