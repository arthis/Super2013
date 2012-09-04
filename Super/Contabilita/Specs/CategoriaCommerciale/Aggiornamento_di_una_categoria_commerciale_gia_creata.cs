using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.CategoriaCommerciale;
using Super.Contabilita.Events;
using Super.Contabilita.Handlers.CategoriaCommerciale;

namespace Super.Contabilita.Specs.CategoriaCommerciale
{
    public class Aggiornamento_di_una_categoria_commerciale_gia_creata : CommandBaseClass<UpdateCategoriaCommerciale>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        
        private string _descriptionUpdated = "test 2";

        
        protected override CommandHandler<UpdateCategoriaCommerciale> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateCategoriaCommercialeHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return  BuildEvt.CategoriaCommercialeCreated
                                   .ForDescription(_description)
                                   .Build(_id,1);
        }

        public override UpdateCategoriaCommerciale When()
        {
            return BuildCmd.UpdateCategoriaCommerciale
                            .ForDescription(_descriptionUpdated)
                            .Build(_id,1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.CategoriaCommercialeUpdated
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
