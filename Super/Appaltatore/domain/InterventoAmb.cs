using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
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

        public void ConsuntivareReso(Guid id, DateTime dataConsuntivazione, DateTime end, DateTime start, string idInterventoAppaltatore, string note, string descrizione, int quantita)
        {
            var is_data_consuntivazione_valid = new Is_data_consuntivazione_valid(dataConsuntivazione);
            var has_start_date_greater_than_end_date = new Has_start_date_greater_than_end_date(start, end);

            ISpecification<Intervento> specs = is_data_consuntivazione_valid.And(has_start_date_greater_than_end_date);

            if (specs.IsSatisfiedBy(this))
            {
                var evt = new ConsuntivatoAmbReso()
                {
                    Id = id,
                    IdInterventoAppaltatore = idInterventoAppaltatore,
                    DataConsuntivazione = dataConsuntivazione,
                    Note = note,
                    Descrizione = descrizione,
                    End = end,
                    Quantita = quantita,
                    Start = start
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
