using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Appaltatore.Commands;
using CommonSpecs;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Appaltatore.Events.Programmazione;
using Super.Appaltatore.Handlers;

namespace Super.Appaltatore.Specs.Consuntivazione.Rotabile_in_Manutenzione
{
    public class Consuntivazione_reso_di_intervento_rotabile_in_manutenzione_programmato : CommandBaseClass<ConsuntivareRotManReso>
    {
        //programmato
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idAreaIntervento = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        List<OggettoRotMan> _oggetti = new List<OggettoRotMan>() { new OggettoRotMan("desc", 15, Guid.NewGuid()) };
        readonly WorkPeriod _period = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddMinutes(-18));
        string _note = "note";

        //Cons
        readonly string _idInterventoAppaltatore = "id intervento appaltatore";
        readonly DateTime _dataConsuntivazione = DateTime.Now;
        List<OggettoRotMan> _oggettiCons = new List<OggettoRotMan>() { new OggettoRotMan("desc cons", 22, Guid.NewGuid()) };
        readonly WorkPeriod _periodCons = new WorkPeriod(DateTime.Now.AddHours(-15), DateTime.Now.AddMinutes(-12));
        string _noteCons = "note";
        

        
        protected override CommandHandler<ConsuntivareRotManReso> OnHandle(IRepository repository)
        {
            return new ConsuntivareRotManResoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return new InterventoRotManProgrammato(
                _id,
                _idAreaIntervento,
                _idTipoIntervento,
                _idAppaltatore,
                _idCategoriaCommerciale,
                _idDirezioneRegionale,
                _period,
                _note,
                _oggetti.ToArray()
                );
        }

        public override ConsuntivareRotManReso When()
        {
            return new ConsuntivareRotManReso(
                _id,
                _idInterventoAppaltatore,
                _dataConsuntivazione,
                _periodCons,
                _noteCons,
                _oggettiCons.ToArray());
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return new InterventoConsuntivatoRotManReso(
                _id,
                _idInterventoAppaltatore,
                _dataConsuntivazione,
                _period,
                _note,
                _oggetti.ToArray());
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
