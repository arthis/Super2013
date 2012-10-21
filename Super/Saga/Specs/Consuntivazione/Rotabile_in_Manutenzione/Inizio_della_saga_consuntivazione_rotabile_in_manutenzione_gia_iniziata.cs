using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Events.Intervento;
using Super.Saga.Domain.Exceptions;
using Super.Programmazione.Events;
using Super.Saga.Handlers.Consuntivazione;
using Super.Saga.Handlers.Intervento;

namespace Super.Saga.Specs.Consuntivazione.Rotabile_in_Manutenzione
{
    public class Inizio_della_saga_consuntivazione_rotabile_in_manutenzione_gia_iniziata : SagaBaseClass<InterventoRotManCreated>
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
        List<OggettoRotMan> _oggetti = new List<OggettoRotMan>() { new OggettoRotMan("desc", 15, Guid.NewGuid(), Guid.NewGuid()) };
        


        public override string ToDescription()
        {
            return "Une saga gia inziata non può essere iniziata di nuovo. vero?.";
        }

        protected override SagaHandler<InterventoRotManCreated> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new InterventoRotManCreatedHandler(repository, bus);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.InterventoRotManCreated
                .ForWorkPeriod(_workPeriod)
                .ForImpianto(_idImpianto)
                .OfTipoIntervento(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .WithNote(_note)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .ForCommittente(_idCommittente)
                .ForProgramma(_idProgramma)
                .ForLotto(_idLotto)
                .WithOggetti(_oggetti.ToArray())
                .Build(_id, 1);
        }

        public override InterventoRotManCreated When()
        {
            return BuildEvt.InterventoRotManCreated
                .ForWorkPeriod(_workPeriod)
                .ForImpianto(_idImpianto)
                .OfTipoIntervento(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .WithNote(_note)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .ForCommittente(_idCommittente)
                .ForProgramma(_idProgramma)
                .ForLotto(_idLotto)
                .WithOggetti(_oggetti.ToArray())
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(SagaStateException), Caught.GetType());
        }


    }
}
