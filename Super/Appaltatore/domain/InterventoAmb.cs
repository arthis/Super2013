using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.ValueObjects;
using Super.Appaltatore.Events.Consuntivazione;
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
                                , RangeDate rangeDate
                                , string note
            )
        {
            var evt = new InterventoAmbProgrammato()
            {
                End = rangeDate.GetEnd(),
                Start = rangeDate.GetStart(),
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
            Id = e.Id;
            //do something here if needed
        }


        public void ConsuntivareNonReso(Guid id, string idInterventoAppaltatore, DateTime dataConsuntivazione, Guid idCausale, string note)
        {
           var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);

           ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if(specs.IsSatisfiedBy(this))
            {
                var evt = new ConsuntivatoAmbNonReso()
                {
                    Id = id,
                    IdInterventoAppaltatore = idInterventoAppaltatore,
                    IdCausale =  idCausale,
                    DataConsuntivazione = dataConsuntivazione,
                    Note = note

                };
                RaiseEvent(evt);
            }
        }

        public void Apply(ConsuntivatoAmbNonReso e)
        {
            //do something here if needed
        }

        public void ConsuntivareNonResoTrenitalia(Guid id, DateTime dataConsuntivazione, Guid idCausale, string idInterventoAppaltatore, string note)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);

            ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = new ConsuntivatoAmbNonResoTrenitalia()
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

        public void Apply(ConsuntivatoAmbNonResoTrenitalia e)
        {
            //do something here if needed
        }

        public void ConsuntivareReso(Guid id, DateTime dataConsuntivazione, RangeDate rangeDate, string idInterventoAppaltatore, string note, string descrizione, int quantita)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);

            ISpecification<Intervento> specs = is_data_consuntivazione_valid;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = new ConsuntivatoAmbReso()
                {
                    Id = id,
                    IdInterventoAppaltatore = idInterventoAppaltatore,
                    DataConsuntivazione = dataConsuntivazione,
                    Note = note,
                    Descrizione = descrizione,
                    End = rangeDate.GetEnd(),
                    Quantita = quantita,
                    Start = rangeDate.GetStart()
                };
                RaiseEvent(evt);
            }
        }

        public void Apply(ConsuntivatoAmbReso e)
        {
            //do something here if needed
        }
    }
}
