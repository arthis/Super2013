using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Appaltatore.Commands;
using CommonSpecs;
using Super.Appaltatore.Commands.Builders;
using Super.Appaltatore.Events.Builders;
using Super.Appaltatore.Events.Programmazione;
using Super.Appaltatore.Handlers;

namespace Super.Appaltatore.Specs.Programmazione.Ambiente
{
    public class Programmazione_di_intervento_ambiente_non_esistente : CommandBaseClass<ProgrammareInterventoAmb>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idAreaIntervento = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly WorkPeriod _period = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddMinutes(-18));
        string _note = "note";
        private readonly int _quantity = 12;
        private readonly string _description = "desc";

        protected override CommandHandler<ProgrammareInterventoAmb> OnHandle(IRepository repository)
        {
            return new ProgrammareInterventoAmbHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override ProgrammareInterventoAmb When()
        {
            var builder = new ProgrammareInterventoAmbBuilder();
            return builder.ForPeriod(_period)
                            .ForId(_id)
                            .ForArea(_idAreaIntervento)
                            .OfType(_idTipoIntervento)
                            .ForAppaltatore(_idAppaltatore)
                            .OfCategoriaCommerciale(_idCategoriaCommerciale)
                            .OfDirezioneRegionale(_idDirezioneRegionale)
                            .WithNote(_note)
                            .WithQuantity(_quantity)
                            .WithDescription(_description)
                            .Build();
        }

        public override IEnumerable<IMessage> Expect()
        {
            //builders
            var builder = new InterventoAmbProgrammatoBuilder();

            yield return builder
                            .ForPeriod(_period)
                            .ForId(_id)
                            .ForArea(_idAreaIntervento)
                            .OfType(_idTipoIntervento)
                            .ForAppaltatore(_idAppaltatore)
                            .OfCategoriaCommerciale(_idCategoriaCommerciale)
                            .OfDirezioneRegionale(_idDirezioneRegionale)
                            .WithNote(_note)
                            .WithQuantity(_quantity)
                            .WithDescription(_description)
                            .Build();
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
