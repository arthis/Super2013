using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Appaltatore.Commands;
using CommonSpecs;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Appaltatore.Events.Programmazione;
using Super.Appaltatore.Handlers;
using BuildCmd = Super.Appaltatore.Commands.Builders.Build;
using BuildEvt = Super.Appaltatore.Events.Builders.Build;

namespace Super.Appaltatore.Specs.Consuntivazione.Ambiente
{
    public class Consuntivazione_reso_di_intervento_ambiente_gia_consuntivato_reso : CommandBaseClass<ConsuntivareAmbReso>
    {
        //Programmazione
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idImpianto = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly WorkPeriod _period = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddMinutes(-18));
        readonly int _quantity = 12;
        private readonly string _description = "bla bla bla description oggetto";
        string _note = "note";
        
        //Consuntivato 1
        readonly string _idInterventoAppaltatore = "id intervento appaltatore";
        readonly DateTime _dataConsuntivazione = DateTime.Now;
        readonly WorkPeriod _periodCons = new WorkPeriod(DateTime.Now.AddHours(-17), DateTime.Now.AddMinutes(-13));
        string _noteCons = "note";
        readonly int _quantityCons = 12;
        private readonly string _descriptionCons = "bla bla bla description oggetto";

        //Consuntivato 2
        private readonly Guid _commitId = Guid.NewGuid();
        readonly string _idInterventoAppaltatoreCons2 = "id intervento appaltatore Cons2";
        readonly DateTime _dataConsuntivazioneCons2 = DateTime.Now.AddSeconds(-20);
        readonly WorkPeriod _periodCons2 = new WorkPeriod(DateTime.Now.AddMinutes(-50), DateTime.Now.AddMinutes(-10));
        string _noteCons2 = "note Cons2";
        readonly int _quantityCons2 = 24;
        private readonly string _descriptionCons2 = "bla bla bla description oggetto Cons2";

        protected override CommandHandler<ConsuntivareAmbReso> OnHandle(IEventRepository eventRepository)
        {
            return new ConsuntivareAmbResoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.InterventoAmbProgrammato
                .ForImpianto(_idImpianto)
                .OfType(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .OfCategoriaCommerciale(_idCategoriaCommerciale)
                .OfDirezioneRegionale(_idDirezioneRegionale)
                .ForPeriod(_period)
                .WithNote(_note)
                .ForQuantity(_quantity)
                .ForDescription(_description)
                .Build(_id, 1);
            yield return BuildEvt.InterventoConsuntivatoAmbReso
                .ForInterventoAppaltatore(_idInterventoAppaltatore)
                .When(_dataConsuntivazione)
                .ForPeriod(_periodCons)
                .WithNote(_noteCons)
                .ForQuantity(_quantityCons)
                .ForDescription(_descriptionCons)
                .Build(_id, 2);
        }

        public override ConsuntivareAmbReso When()
        {
            return BuildCmd.ConsuntivareAmbReso
                .ForInterventoAppaltatore(_idInterventoAppaltatoreCons2)
                .When(_dataConsuntivazioneCons2)
                .ForPeriod(_periodCons2)
                .ForQuantity(_quantityCons2)
                .ForDescription(_descriptionCons2)
                .WithNote(_noteCons2)
                .Build(_id, _commitId, 2);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.InterventoConsuntivatoAmbReso
                .ForInterventoAppaltatore(_idInterventoAppaltatoreCons2)
                .When(_dataConsuntivazioneCons2)
                .ForPeriod(_periodCons2)
                .WithNote(_noteCons2)
                .ForQuantity(_quantityCons2)
                .ForDescription(_descriptionCons2)
                .Build(_id, 3);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
