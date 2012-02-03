using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;
using System.ComponentModel.DataAnnotations;
using Commands.Attributes;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Commands.AreaIntervento
{
    public class AggiornareAreaIntervento : CommandBase
    {
        [AggregateRootId]
        public Guid Id { get; set; }
        public int IdAreaInterventoSuper { get; set; }
        [DataType(DataType.Date)]
        [DateRange("2010/12/01", "2020/12/16")]
        [Required]
        public DateTime Inizio { get; set; }
        [DataType(DataType.Date)]
        [DateRange("2010/12/01", null)]
        public DateTime? Fine { get; set; }
        public string Descrizione { get; set; }

        public AggiornareAreaIntervento()
        {
        }

        public AggiornareAreaIntervento(Guid id, int idAreaInterventoSuper, DateTime inizio, DateTime? fine, string descrizione)
        {
            this.Id = id;
            this.IdAreaInterventoSuper = idAreaInterventoSuper;
            this.Inizio = inizio;
            this.Fine = fine;
            this.Descrizione = descrizione;
        }

        //public ValidationResult Validate()
        //{
        //    ValidationResult vr = new ValidationResult();
            
        //    InizioGreaterThanFineSpecification InizioGreaterThanFine = new InizioGreaterThanFineSpecification();
            
        //    ISpecification<CreareNuovoAreaIntervento> specs = InizioGreaterThanFine;

        //    specs.IsSatisfiedBy(this, vr);

        //    return vr;
        //}
    }
}
