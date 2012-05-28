using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain.Core.Super;
using Super.Appaltatore.Events.Programmazione;

namespace Super.Appaltatore.Domain
{
    
    public class InterventoRot : Intervento
    {

        public void Programmare(Guid id
                                , Guid idAreaIntervento
                                , Guid idTipoIntervento
                                , Guid idAppaltatore
                                , Guid idCategoriaCommerciale
                                , Guid idDirezioneRegionale
                                , DateTime start
                                , DateTime end
                                , string note
                                , OggettoRot[] oggetti
                                , string numeroTrenoArrivo
                                , DateTime dataTrenoArrivo
                                , string numeroTrenoPartenza
                                , DateTime dataTrenoPartenza
                                , string turnoTreno
                                , string rigaTurnoTreno
                                , string convoglio
            )
       {
           var evt = new InterventoRotProgrammato()
                {
                    End = end,
                    Start = start,
                    Id = id,
                    IdAreaIntervento = idAreaIntervento,
                    IdTipoIntervento = idTipoIntervento,
                    IdAppaltatore = idAppaltatore,
                    IdCategoriaCommerciale = idCategoriaCommerciale,
                    IdDirezioneRegionale = idDirezioneRegionale,
                    Note = note,
                    Oggetti = oggetti.ToArray(),
                    NumeroTrenoArrivo = numeroTrenoArrivo,
                    DataTrenoArrivo = dataTrenoArrivo,
                    NumeroTrenoPartenza = numeroTrenoPartenza,
                    DataTrenoPartenza = dataTrenoPartenza,
                    TurnoTreno = turnoTreno,
                    RigaTurnoTreno = rigaTurnoTreno,
                    Convoglio = convoglio
                };
           RaiseEvent(evt);
       }

        public void Apply(InterventoRotProgrammato e)
        {
              //do something here if needed
        }


    }
}
