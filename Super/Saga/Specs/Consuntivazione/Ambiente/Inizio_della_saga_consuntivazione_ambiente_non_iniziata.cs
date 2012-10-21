using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Saga.Handlers.Consuntivazione;
using BuildAppaltatoreCmd = Super.Appaltatore.Commands.BuildCmd;
using BuildControlloCmd = Super.Controllo.Commands.BuildCmd;
using Super.Programmazione.Events.Intervento;
using Super.Programmazione.Events;
using Super.Saga.Handlers.Intervento;

namespace Super.Saga.Specs.Consuntivazione.Ambiente
{
    public class Inizio_della_saga_consuntivazione_ambiente_non_iniziata : SagaBaseClass<InterventoAmbCreated>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idImpianto = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly Guid _idPeriodoProgrammazione = Guid.NewGuid();
        readonly Guid _idProgramma = Guid.NewGuid();
        readonly Guid _idLotto = Guid.NewGuid();
        readonly Guid _idCommittente = Guid.NewGuid();
        private readonly DateTime _dataConsuntivazioneAutomatica = DateTime.Now.AddHours(-17).AddMinutes(20);
        readonly WorkPeriod _workPeriod = new WorkPeriod(DateTime.Now.AddHours(-19), DateTime.Now.AddHours(-17));
        string _note = "note";
        private int _quantity = 12;
        private string _description = "desc";


        public override string ToDescription()
        {
            return "un inizo di saga normale";
        }

        protected override SagaHandler<InterventoAmbCreated> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new InterventoAmbCreatedHandler(repository, bus);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override InterventoAmbCreated When()
        {
            return BuildEvt.InterventoAmbCreated
                .ForWorkPeriod(_workPeriod)
                .ForImpianto(_idImpianto)
                .OfTipoIntervento(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .ForQuantity(_quantity)
                .ForDescription(_description)
                .WithNote(_note)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .ForCommittente(_idCommittente)
                .ForProgramma(_idProgramma)
                .ForLotto(_idLotto)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {

            yield return BuildAppaltatoreCmd.ProgramInterventoAmb
                .ForWorkPeriod(_workPeriod)
                .ForImpianto(_idImpianto)
                .OfTipoIntervento(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .ForQuantity(_quantity)
                .ForDescription(_description)
                .WithNote(_note)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .ForCommittente(_idCommittente)
                .ForProgramma(_idProgramma)
                .ForLotto(_idLotto)
                .Build(_id);
            
            yield return BuildControlloCmd.ProgramInterventoAmb
                .ForWorkPeriod(_workPeriod)
                .ForImpianto(_idImpianto)
                .OfTipoIntervento(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .ForQuantity(_quantity)
                .ForDescription(_description)
                .WithNote(_note)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .ForCommittente(_idCommittente)
                .ForProgramma(_idProgramma)
                .ForLotto(_idLotto)
                .Build(_id);

            yield return BuildAppaltatoreCmd.ConsuntivareAutomaticamenteNonResoInterventoAmb
                .ForDataConsuntivazione(_dataConsuntivazioneAutomatica)
                .Build(_id,  _dataConsuntivazioneAutomatica);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
