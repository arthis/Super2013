using System;
using System.Collections.Generic;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using EasyNetQ;
using NUnit.Framework;
using CommonSpecs;
using Super.Appaltatore.Events.Builders;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Controllo.Commands;
using Super.Saga.Handlers;
using Super.Programmazione.Events;

namespace Super.Saga.Specs.Saga_Intervento.Ambiente
{
    public class consuntivazione_intervento : SagaBaseClass<InterventoConsuntivatoAmbReso>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idImpianto = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly WorkPeriod _period = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddMinutes(-18));
        private int _quantita = 12;
        private string _description = "desc";
        string _note = "note";

        readonly string _idInterventoAppaltatore = "dsfsd";
        readonly WorkPeriod _periodCons = new WorkPeriod(DateTime.Now.AddHours(-19), DateTime.Now.AddMinutes(-17));
        private int _quantitaCons = 13;
        private DateTime DataCons = DateTime.Now;
        private string _descriptionCons = "desc cons";
        string _noteCons = "note cons";

        public override string ToDescription()
        {
            return "";
        }

        protected override SagaHandler<InterventoConsuntivatoAmbReso> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new InterventoConsuntivatoAmbResoHandler(repository, bus);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return new InterventoAmbPianificato()
            {
                Period = _period,
                Id = _id,
                IdImpianto = _idImpianto,
                IdTipoIntervento = _idTipoIntervento,
                IdAppaltatore = _idAppaltatore,
                IdCategoriaCommerciale = _idCategoriaCommerciale,
                IdDirezioneRegionale = _idDirezioneRegionale,
                Note = _note,
                
            };
        }

        public override InterventoConsuntivatoAmbReso When()
        {
            var builder = new InterventoConsuntivatoAmbResoBuilder();

            return builder.ForId(_id)
                            .ForDescription(_description)
                            .ForInterventoAppaltatore(_idInterventoAppaltatore)
                            .ForPeriod(_periodCons)
                            .ForQuantity(_quantitaCons)
                            .When(DataCons)
                            .WithNote(_noteCons)
                            .Build();
            
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return new AllowControlIntervento(_id);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
