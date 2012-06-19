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
    public class Consuntivazione_reso_di_intervento_ambiente_gia_consuntivato_reso : CommandBaseClass<ConsuntivareAmbReso>
    {
        //Programmazione
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idAreaIntervento = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly DateTime _start = DateTime.Now.AddHours(12);
        readonly DateTime _end = DateTime.Now.AddHours(13);
        string _note = "note";
        
        //Consuntivato 1
        readonly string _idInterventoAppaltatore = "id intervento appaltatore";
        readonly DateTime _dataConsuntivazione = DateTime.Now;
        readonly DateTime _startCons = DateTime.Now.AddHours(-1);
        readonly DateTime _endCons = DateTime.Now.AddMinutes(-13);
        string _noteCons = "note";
        readonly int _quantita = 12;
        private readonly string _descrizione = "bla bla bla descrizione oggetto";

        //Consuntivato 2
        readonly string _idInterventoAppaltatoreCons2 = "id intervento appaltatore Cons2";
        readonly DateTime _dataConsuntivazioneCons2 = DateTime.Now.AddSeconds(-20);
        readonly DateTime _startCons2 = DateTime.Now.AddMinutes(-50);
        readonly DateTime _endCons2 = DateTime.Now.AddMinutes(-10);
        string _noteCons2 = "note Cons2";
        readonly int _quantitaCons2 = 24;
        private readonly string _descrizioneCons2 = "bla bla bla descrizione oggetto Cons2";

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
                
            };
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
                
            };
        }

        public override ConsuntivareAmbReso When()
        {
            return new ConsuntivareAmbReso()
            {
                End = _endCons2,
                Start = _startCons2,
                Id = _id,
                IdInterventoAppaltatore = _idInterventoAppaltatoreCons2,
                DataConsuntivazione = _dataConsuntivazioneCons2,
                Note = _noteCons2,
                Quantita = _quantitaCons2,
                Descrizione = _descrizioneCons2,
                
            };
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return new InterventoConsuntivatoAmbReso()
            {
                End = _endCons2,
                Start = _startCons2,
                Id = _id,
                IdInterventoAppaltatore = _idInterventoAppaltatoreCons2,
                DataConsuntivazione = _dataConsuntivazioneCons2,
                Note = _noteCons2,
                Quantita = _quantitaCons2,
                Descrizione = _descrizioneCons2,
                
            };
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
