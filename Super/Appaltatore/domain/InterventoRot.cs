using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.ValueObjects;
using CommonDomain.Core.Super.ValueObjects;
using Super.Appaltatore.Events.Consuntivazione;
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
                                , RangeDate rangeDate
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
                    End = rangeDate.GetEnd(),
                    Start = rangeDate.GetStart(),
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
            Id = e.Id;
              //do something here if needed
        }

        public void ConsuntivareNonReso(Guid id, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausale, string note)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);

            ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = new InterventoConsuntivatoRotNonReso()
                {
                    Id = id,
                    IdInterventoAppaltatore = idInterventoAppaltatore,
                    IdCausale = idCausale,
                    DataConsuntivazione = dataConsuntivazione,
                    Note = note

                };
                RaiseEvent(evt);
            }
        }

        public void Apply(InterventoConsuntivatoRotNonReso e)
        {
            //do something here if needed
        }

        public void ConsuntivareNonResoTrenitalia(Guid id, DateTime dataConsuntivazione, Guid idCausale, string idInterventoAppaltatore, string note)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);

            ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = new InterventoConsuntivatoRotNonResoTrenitalia()
                {
                    Id = id,
                    IdInterventoAppaltatore = idInterventoAppaltatore,
                    IdCausale = idCausale,
                    DataConsuntivazione = dataConsuntivazione,
                    Note = note

                };
                RaiseEvent(evt);
            }
        }

        public void Apply(InterventoConsuntivatoRotNonResoTrenitalia e)
        {
            //do something here if needed
        }


       public void ConsuntivareReso(Guid id, DateTime dataConsuntivazione, RangeDate rangeDate, string idInterventoAppaltatore, string note, OggettoRot[] oggetti, string convoglio, DateTime dataTrenoArrivo, DateTime dataTrenoPartenza, string numeroTrenoArrivo, string numeroTrenoPartenza, string rigaTurnoTreno, string turnoTreno)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);
            

            ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = new InterventoConsuntivatoRotReso()
                {
                    Id = id
                    , IdInterventoAppaltatore = idInterventoAppaltatore
                    , DataConsuntivazione = dataConsuntivazione
                    , Note = note
                    , End = rangeDate.GetEnd()
                    , Start = rangeDate.GetStart()
                    , Oggetti = oggetti
                    , Convoglio = convoglio
                    , DataTrenoArrivo = dataTrenoArrivo
                    , DataTrenoPartenza = dataTrenoPartenza
                    , NumeroTrenoArrivo = numeroTrenoArrivo
                    , NumeroTrenoPartenza = numeroTrenoPartenza
                    , RigaTurnoTreno = rigaTurnoTreno
                    , TurnoTreno = turnoTreno
                };
                RaiseEvent(evt);
            }
        }

        public void Apply(InterventoConsuntivatoRotReso e)
        {
            //do something here if needed
        }
    }
}
