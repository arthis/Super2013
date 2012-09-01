using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.Builders;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Appaltatore.Commands;
using CommonSpecs;
using Super.Appaltatore.Commands.Builders;
using Super.Appaltatore.Events.Builders;
using Super.Appaltatore.Events.Programmazione;
using Super.Appaltatore.Handlers;
using BuildCmd = Super.Appaltatore.Commands.Builders.Build;
using Super.Appaltatore.Events;

namespace Super.Appaltatore.Specs.Programmazione.Ambiente
{
    public class Programmazione_di_intervento_ambiente_gia_esistente : CommandBaseClass<ProgrammareInterventoAmb>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _commitId = Guid.NewGuid();
        readonly Guid _idImpianto = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly WorkPeriod _period = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddMinutes(-18));
        string _note = "note";
        private readonly int _quantity = 12;
        private readonly string _description = "desc";

        protected override CommandHandler<ProgrammareInterventoAmb> OnHandle(IEventRepository eventRepository)
        {
            return new ProgrammareInterventoAmbHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            //builders
            yield return  BuildEvt.InterventoAmbProgrammato
                            .ForPeriod(_period)
                            .ForImpianto(_idImpianto)
                            .OfType(_idTipoIntervento)
                            .ForAppaltatore(_idAppaltatore)
                            .OfCategoriaCommerciale(_idCategoriaCommerciale)
                            .OfDirezioneRegionale(_idDirezioneRegionale)
                            .WithNote(_note)
                            .ForQuantity(_quantity)
                            .ForDescription(_description)
                            .Build(_id,1);
        }

        public override ProgrammareInterventoAmb When()
        {
            return BuildCmd.ProgrammareInterventoAmb
                            .ForPeriod(_period)
                            .ForImpianto(_idImpianto)
                            .OfType(_idTipoIntervento)
                            .ForAppaltatore(_idAppaltatore)
                            .OfCategoriaCommerciale(_idCategoriaCommerciale)
                            .OfDirezioneRegionale(_idDirezioneRegionale)
                            .OfType(_idTipoIntervento)
                            .WithNote(_note)
                            .ForQuantity(_quantity)
                            .ForDescription(_description)
                            .Build(_id, _commitId,1);
          
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(AlreadyCreatedAggregateRootException), Caught.GetType());
        }


    }
}
