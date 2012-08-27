using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Committente;
using Super.Contabilita.Handlers.Committente;
using BuildCmd = Super.Contabilita.Commands.Builders.Build;
using BuildEvt = Super.Contabilita.Events.Builders.Build;

namespace Super.Contabilita.Specs.Committente
{
    public class Aggiornamento_di_un_committente_gia_creato : CommandBaseClass<UpdateCommittente>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private string _sign = "sign";
        
        private string _descriptionUpdated = "test 2";
        private string _signupdated = "sign 2";

        
        protected override CommandHandler<UpdateCommittente> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateCommittenteHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return  BuildEvt.CommittenteCreated
                                   .ForDescription(_description)
                                   .ForSign(_sign)
                                   .Build(_id,1);
        }

        public override UpdateCommittente When()
        {
            return BuildCmd.UpdateCommittente
                            .ForDescription(_descriptionUpdated)
                            .ForSign(_signupdated)
                            .Build(_id,1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.CommittenteUpdated
                .ForDescription(_descriptionUpdated)
                .ForSign(_signupdated)
                .Build(_id,2);
                            
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
