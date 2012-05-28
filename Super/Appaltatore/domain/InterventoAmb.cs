using System;
using System.Collections.Generic;
using Super.Appaltatore.Events.Programmazione;

namespace Super.Appaltatore.Domain
{
    
    public class InterventoAmb : Intervento
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
            )
        {
            var evt = new InterventoAmbProgrammato()
            {
                End = end,
                Start = start,
                Id = id,
                IdAreaIntervento = idAreaIntervento,
                IdTipoIntervento = idTipoIntervento,
                IdAppaltatore = idAppaltatore,
                IdCategoriaCommerciale = idCategoriaCommerciale,
                IdDirezioneRegionale = idDirezioneRegionale,
                Note = note
              
            };
            RaiseEvent(evt);
        }

        public void Apply(InterventoAmbProgrammato e)
        {
            //do something here if needed
        }


    }
}
