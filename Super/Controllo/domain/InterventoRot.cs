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
    public class InterventoRot : Intervento
    {

        public void Programmare(Guid id
                                , Guid idImpianto
                                , Guid idTipoIntervento
                                , Guid idAppaltatore
                                , Guid idCategoriaCommerciale
                                , Guid idDirezioneRegionale
                                , WorkPeriod workPeriod
                                , string note
                                , IEnumerable<OggettoRot> oggetti
                                , Treno trenoArrivo
                                , Treno trenoPartenza
                                , string turnoTreno
                                , string rigaTurnoTreno
                                , string convoglio
            )
        {


            var evt = BuildEvt.InterventoRotProgrammato
                            .WithOggetti(oggetti.ToMessage().ToArray())
                            .ForWorkPeriod(workPeriod.ToMessage())
                            .ForImpianto(idImpianto)
                            .OfTipoIntervento(idTipoIntervento)
                            .ForAppaltatore(idAppaltatore)
                            .ForCategoriaCommerciale(idCategoriaCommerciale)
                            .ForDirezioneRegionale(idDirezioneRegionale)
                            .WithNote(note)
                            .WithTrenoPartenza(trenoPartenza.ToMessage())
                            .WithTrenoArrivo(trenoArrivo.ToMessage())
                            .WithTurnoTreno(turnoTreno)
                            .WithRigaTurnoTreno(rigaTurnoTreno)
                            .ForConvoglio(convoglio);

            RaiseEvent(id, evt);
        }

        public void Apply(InterventoRotProgrammato e)
        {
            Id = e.Id;
            //do something here if needed
        }

        public void ControlReso(Guid idUser, DateTime  controlDate, WorkPeriod workPeriod, Treno trenoPartenza, Treno trenoArrivo, string convoglio, string note,IEnumerable<OggettoRot> oggetti, string rigaTurnoTreno, string turnoTreno)
        {

            var evt = BuildEvt.InterventoRotControlledReso
                .ForWorkPeriod(workPeriod.ToMessage())
                .By(idUser)
                .When(controlDate)
                .WithNote(note)
                .WithTrenoPartenza(trenoPartenza.ToMessage())
                .WithTrenoArrivo(trenoArrivo.ToMessage())
                .ForConvoglio(convoglio)
                .WithOggetti(oggetti.ToMessage().ToArray())
                .WithRigaTurnoTreno(rigaTurnoTreno)
                .WithTurnoTreno(turnoTreno);

            RaiseEvent(evt);
        }

        public void Apply(InterventoRotControlledReso e)
        {
            //do nothing
        }


        
    }
}
