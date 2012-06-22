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
        readonly WorkPeriod _period = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddMinutes(-18));
        readonly int _quantita = 12;
        private readonly string _descrizione = "bla bla bla description oggetto";
        string _note = "note";
        
        //consuntivato
        readonly string _idInterventoAppaltatore = "id intervento appaltatore";
        readonly DateTime _dataConsuntivazione = DateTime.Now;
        readonly WorkPeriod _periodCons = new WorkPeriod(DateTime.Now.AddHours(-17), DateTime.Now.AddMinutes(-13));
        string _noteCons = "note";
        readonly int _quantitaCons = 12;
        private readonly string _descrizioneCons = "bla bla bla description oggetto";
        

        protected override CommandHandler<ConsuntivareAmbReso> OnHandle(IRepository repository)
        {
            return new ConsuntivareAmbResoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return new InterventoAmbProgrammato(
                                    _id,
                                    _idAreaIntervento,
                                    _idTipoIntervento,
                                    _idAppaltatore,
                                    _idCategoriaCommerciale,
                                    _idDirezioneRegionale,
                                    _period,
                                    _note,
                                    _quantita,
                                    _descrizione);
        }

        public override ConsuntivareAmbReso When()
        {
            return new ConsuntivareAmbReso(
                                            Id = _id,
                                            _idInterventoAppaltatore,
                                            _dataConsuntivazione,
                                            _periodCons,
                                            _noteCons,
                                            _quantitaCons,
                                            _descrizioneCons);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return new InterventoConsuntivatoAmbReso(
                                    _id,
                                    _idInterventoAppaltatore,
                                    _dataConsuntivazione,
                                    _periodCons,
                                    _noteCons,
                                    _quantitaCons,
                                    _descrizioneCons);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
