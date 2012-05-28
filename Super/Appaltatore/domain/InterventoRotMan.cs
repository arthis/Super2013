using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain.Core.Super;
using Super.Appaltatore.Events.Programmazione;

namespace Super.Appaltatore.Domain
{
    
    public class InterventoRotMan : Intervento
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
                                        , OggettoRotMan[] oggetti
                    )
        {
            var evt = new InterventoRotManProgrammato()
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
            };
            RaiseEvent(evt);
        }

        public void Apply(InterventoRotManProgrammato e)
        {
            //do something here if needed
        }


        
    }
}
