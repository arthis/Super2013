using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Core.Super.Messaging.Builders;
using Super.Controllo.Events;

using Super.Controllo.Events.Consuntivazione;
using Super.Controllo.Events.Programmazione;

namespace Super.Controllo.Domain
{
    public class InterventoRotMan : Intervento
    {

        public void Programmare(Guid id
                                        , Guid idImpianto
                                        , Guid idTipoIntervento
                                        , Guid idAppaltatore
                                        , Guid idCategoriaCommerciale
                                        , Guid idDirezioneRegionale
                                        , WorkPeriod workPeriod
                                        , string note
                                        , IEnumerable<OggettoRotMan> oggetti
                    )
        {

            var evt = BuildEvt.InterventoRotManProgrammato
                            .WithOggetti(oggetti.ToMessage().ToArray())
                            .ForWorkPeriod(workPeriod.ToMessage())
                            .ForImpianto(idImpianto)
                            .OfTipoIntervento(idTipoIntervento)
                            .ForAppaltatore(idAppaltatore)
                            .ForCategoriaCommerciale(idCategoriaCommerciale)
                            .ForDirezioneRegionale(idDirezioneRegionale)
                            .WithNote(note);

            RaiseEvent(id, evt);
        }

        public void Apply(InterventoRotManProgrammato e)
        {
            Id = e.Id;
            //do something here if needed
        }
        public void ControlReso(Guid idUser, DateTime controlDate, WorkPeriod workPeriod, string note, IEnumerable<OggettoRotMan> oggetti)
        {
            
            var evt = BuildEvt.InterventoRotManControlledReso
                .ForWorkPeriod(workPeriod.ToMessage())
                .By(idUser)
                .When(controlDate)
                .WithNote(note)
                .WithOggetti(oggetti.ToMessage().ToArray());

            RaiseEvent(evt);
        }

        public void Apply(InterventoRotManControlledReso e)
        {
            //do nothing
        }


       
    }
}
