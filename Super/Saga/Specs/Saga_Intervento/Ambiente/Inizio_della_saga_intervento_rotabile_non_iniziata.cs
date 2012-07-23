using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Commands.Builders;
using Super.Programmazione.Events.Schedulazione;
using Super.Saga.Handlers;
using Super.Programmazione.Events;
using BuildEvt = Super.Programmazione.Events.Builders.Build;
using BuildCmd = Super.Appaltatore.Commands.Builders.Build;


namespace Super.Saga.Specs.Saga_Intervento.Ambiente
{
    public class Inizio_della_saga_intervento_ambiente_non_iniziata : SagaBaseClass<InterventoAmbGenerated>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idImpianto = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly WorkPeriod _period = new WorkPeriod(DateTime.Now.AddHours(-19), DateTime.Now.AddMinutes(-17));
        string _note = "note";
        private int _quantity = 12;
        private string _description = "desc";
        

        public override string ToDescription()
        {
            return "un inizo di saga normale";
        }

        protected override SagaHandler<InterventoAmbGenerated> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new InterventoAmbGeneratedHandler(repository,bus);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override InterventoAmbGenerated When()
        {
            return BuildEvt.InterventoAmbGenerated
               .ForPeriod(_period)
               .ForImpianto(_idImpianto)
               .OfType(_idTipoIntervento)
               .ForAppaltatore(_idAppaltatore)
               .OfCategoriaCommerciale(_idCategoriaCommerciale)
               .OfDirezioneRegionale(_idDirezioneRegionale)
               .ForQuantity(_quantity)
               .ForDescription(_description)
               .WithNote(_note)
               .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            
            yield return BuildCmd.ProgrammareInterventoAmb
                            .ForPeriod(_period)
                            .ForImpianto(_idImpianto)
                            .OfType(_idTipoIntervento)
                            .OfType(_idTipoIntervento)
                            .ForAppaltatore(_idAppaltatore)
                            .OfCategoriaCommerciale(_idCategoriaCommerciale)
                            .OfDirezioneRegionale(_idDirezioneRegionale)
                            .WithNote(_note)
                            .ForQuantity(_quantity)
                            .ForDescription(_description)
                            .Build(_id, 0);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
