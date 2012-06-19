using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Appaltatore.Events.Consuntivazione;
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
                                        , RolloutPeriod rolloutPeriod
                                        , string note
                                        , OggettoRotMan[] oggetti
                    )
        {
            var evt = new InterventoRotManProgrammato()
            {
                End = rolloutPeriod.GetEnd(),
                Start = rolloutPeriod.GetStart(),
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
            Id = e.Id;
            //do something here if needed
        }


        public void ConsuntivareNonReso(Guid id, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausale, string note)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);

            ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = new InterventoConsuntivatoRotManNonReso()
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

        public void Apply(InterventoConsuntivatoRotManNonReso e)
        {
            //do something here if needed
        }


        public void ConsuntivareNonResoTrenitalia(Guid id, DateTime dataConsuntivazione, Guid idCausale, string idInterventoAppaltatore, string note)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);

            ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = new InterventoConsuntivatoRotManNonResoTrenitalia()
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

        public void Apply(InterventoConsuntivatoRotManNonResoTrenitalia e)
        {
            //do something here if needed
        }

        public void ConsuntivareReso(Guid id, DateTime dataConsuntivazione, RolloutPeriod rolloutPeriod, string idInterventoAppaltatore, string note, OggettoRotMan[] oggetti)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);

            ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = new InterventoConsuntivatoRotManReso()
                {
                    Id = id,
                    IdInterventoAppaltatore = idInterventoAppaltatore,
                    DataConsuntivazione = dataConsuntivazione,
                    Note = note,
                    Start = rolloutPeriod.GetStart(),
                    End = rolloutPeriod.GetEnd(),
                     Oggetti = oggetti
                };
                RaiseEvent(evt);
            }
        }

        public void Apply(InterventoConsuntivatoRotManReso e)
        {
            //do something here if needed
        }
    }
}
