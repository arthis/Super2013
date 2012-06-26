using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Impianto;
using Super.Contabilita.Events.Impianto;
using Super.Contabilita.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using BuildCmd = Super.Contabilita.Commands.Builders.Build;
using BuildEvt = Super.Contabilita.Events.Builders.Build;

namespace Super.Contabilita.Specs.Impianto
{
    public class Aggiornamento_di_una_impianto_gia_creata : CommandBaseClass<UpdateImpianto>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private DateTime _creationDate = DateTime.Now;
        private long _version;
        private Intervall _intervall = new Intervall(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));

        private string _descriptionUpdated = "test 2";
        private Intervall _intervallUpdated = new Intervall(DateTime.Now.AddHours(14), DateTime.Now.AddHours(15));
        

        
        protected override CommandHandler<UpdateImpianto> OnHandle(IRepository repository)
        {
            return new UpdateImpiantoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return  BuildEvt.ImpiantoCreated
                                   .ForCreationDate(_creationDate)
                                   .ForDescription(_descriptionUpdated)
                                   .ForIntervall(_intervall)
                                   .Build(_id);
        }

        public override UpdateImpianto When()
        {
            return BuildCmd.UpdateImpianto
                            .ForIntervall(_intervallUpdated)
                            .ForDescription(_description)
                            .Build(_id);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.ImpiantoUpdated
                .ForDescription(_description)
                .ForIntervall(_intervall)
                .Build(_id);
                            
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
