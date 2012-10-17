using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Appaltatore.Commands;
using CommonSpecs;
using Super.Appaltatore.Commands.Consuntivazione;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Appaltatore.Events.Programmazione;
using Super.Appaltatore.Handlers;
using BuildCmd = Super.Appaltatore.Commands.BuildCmd;
using Super.Appaltatore.Events;

namespace Super.Appaltatore.Specs.Consuntivazione.Ambiente
{
    public class Consuntivazione_reso_di_intervento_ambiente_programmato : CommandBaseClass<ConsuntivareResoAmb>
    {
        //programmato
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
        
        //consuntivato
        private readonly Guid _commitId = Guid.NewGuid();
        readonly string _idInterventoAppaltatore = "id intervento appaltatore";
        readonly DateTime _dataConsuntivazione = DateTime.Now;
        readonly WorkPeriod _workPeriodCons = new WorkPeriod(DateTime.Now.AddHours(-17), DateTime.Now.AddMinutes(-13));
        string _noteCons = "note";
        readonly int _quantityCons = 12;
        private readonly string _descriptionCons = "bla bla bla description oggetto";
        
        protected override CommandHandler<ConsuntivareResoAmb> OnHandle(IEventRepository eventRepository)
        {
            return new ConsuntivareResoAmbHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return  BuildEvt.InterventoAmbProgrammato
                .ForImpianto(_idImpianto)
                .OfTipoIntervento(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .ForWorkPeriod(_period)
                .WithNote(_note)
                .ForQuantity(_quantity)
                .ForDescription(_description)
                .Build(_id, 1);
        }

        public override ConsuntivareResoAmb When()
        {
            return BuildCmd.ConsuntivareResoAmb
                .ForInterventoAppaltatore(_idInterventoAppaltatore)
                .ForDataConsuntivazione(_dataConsuntivazione)
                .ForWorkPeriod(_workPeriodCons)
                .WithNote(_noteCons)
                .ForQuantity(_quantityCons)
                .ForDescription(_descriptionCons)
                .Build(_id, _commitId, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.InterventoAmbConsuntivatoReso
                .ForInterventoAppaltatore(_idInterventoAppaltatore)
                .When(_dataConsuntivazione)
                .ForWorkPeriod(_workPeriodCons)
                .WithNote(_noteCons)
                .ForQuantity(_quantityCons)
                .ForDescription(_descriptionCons)
                .Build(_id, 2);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
