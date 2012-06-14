using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Appaltatore.Commands;
using CommonSpecs;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Appaltatore.Events.Programmazione;
using Super.Appaltatore.Handlers;

namespace Super.Appaltatore.Specs.Consuntivazione.Ambiente
{
    public class Consuntivazione_reso_di_intervento_ambiente_programmato : CommandBaseClass<ConsuntivareAmbReso>
    {
        //programmato
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idAreaIntervento = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly DateTime _start = DateTime.Now.AddHours(12);
        readonly DateTime _end = DateTime.Now.AddHours(13);
        string _note = "note";
        
        //consuntivato
        readonly string _idInterventoAppaltatore = "id intervento appaltatore";
        readonly DateTime _dataConsuntivazione = DateTime.Now;
        readonly DateTime _startCons = DateTime.Now.AddHours(-1);
        readonly DateTime _endCons = DateTime.Now.AddMinutes(-13);
        string _noteCons = "note";
        readonly int _quantita = 12;
        private readonly string _descrizione = "bla bla bla descrizione oggetto";

        protected override CommandHandler<ConsuntivareAmbReso> OnHandle(IRepository repository)
        {
            return new ConsuntivareAmbResoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return new InterventoAmbProgrammato()
            {
                End = _end,
                Start = _start,
                Id = _id,
                IdAreaIntervento = _idAreaIntervento,
                IdTipoIntervento = _idTipoIntervento,
                IdAppaltatore = _idAppaltatore,
                IdCategoriaCommerciale = _idCategoriaCommerciale,
                IdDirezioneRegionale = _idDirezioneRegionale,
                Note = _note,
                Headers = Headers
            };
        }

        public override ConsuntivareAmbReso When()
        {
            return new ConsuntivareAmbReso()
            {
                End = _end,
                Start = _start,
                Id = _id,
                IdInterventoAppaltatore = _idInterventoAppaltatore,
                DataConsuntivazione = _dataConsuntivazione,
                Note = _note,
                Quantita = _quantita,
                Descrizione = _descrizione,
                Headers = Headers
            };
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return new InterventoConsuntivatoAmbReso()
            {
                End = _endCons,
                Start = _startCons,
                Id = _id,
                IdInterventoAppaltatore = _idInterventoAppaltatore,
                DataConsuntivazione = _dataConsuntivazione,
                Note = _noteCons,
                Quantita = _quantita,
                Descrizione = _descrizione,
                Headers = Headers
            };
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
