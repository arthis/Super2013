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
using Super.Appaltatore.Events.Builders;
using Super.Appaltatore.Events.Programmazione;
using Super.Appaltatore.Handlers;
using BuildCmd = Super.Appaltatore.Commands.BuildCmd;
using Super.Appaltatore.Events;

namespace Super.Appaltatore.Specs.Programmazione.Ambiente
{
    public class Programmazione_di_intervento_ambiente_non_esistente : CommandBaseClass<ProgramInterventoAmb>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _commitId = Guid.NewGuid();
        readonly Guid _idImpianto = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly WorkPeriod _workPeriod = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddMinutes(-18));
        string _note = "note";
        private readonly int _quantity = 12;
        private readonly string _description = "desc";

        protected override CommandHandler<ProgramInterventoAmb> OnHandle(IEventRepository eventRepository)
        {
            return new ProgramInterventoAmbHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override ProgramInterventoAmb When()
        {
            return BuildCmd.ProgramInterventoAmb
                            .ForWorkPeriod(_workPeriod)
                            .ForImpianto(_idImpianto)
                            .OfTipoIntervento(_idTipoIntervento)
                            .ForAppaltatore(_idAppaltatore)
                            .ForCategoriaCommerciale(_idCategoriaCommerciale)
                            .ForDirezioneRegionale(_idDirezioneRegionale)
                            .WithNote(_note)
                            .ForQuantity(_quantity)
                            .ForDescription(_description)
                            .Build(_id, _commitId,0);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.InterventoAmbProgrammato
                            .ForWorkPeriod(_workPeriod)
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

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
