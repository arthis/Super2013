using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;
using System.ComponentModel.DataAnnotations;
using Commands.Attributes;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Commands.TipoIntervento
{
    public class AggiornareTipoInterventoRotMan : CommandBase
    {
        [AggregateRootId]
        public Guid Id { get; set; }
        public int IdTipoInterventoSuper { get; set; }
        [DataType(DataType.Date)]
        //[DateRange("2010/12/01", "2020/12/16")]
        [Required]
        public DateTime Inizio { get; set; }
        [DataType(DataType.Date)]
        //[DateRange("2010/12/01", null)]
        public DateTime? Fine { get; set; }
        public string Descrizione { get; set; }

        public AggiornareTipoInterventoRotMan()
        {
        }

        public AggiornareTipoInterventoRotMan(Guid id, int idTipoInterventoRotManSuper, DateTime inizio, DateTime? fine, string descrizione)
        {

            this.Id = id;
            this.IdTipoInterventoSuper = idTipoInterventoRotManSuper;
            this.Inizio = inizio;
            this.Fine = fine;
            this.Descrizione = descrizione;
        }

        //public ValidationResult Validate()
        //{
        //    ValidationResult vr = new ValidationResult();
            
        //    InizioGreaterThanFineSpecification InizioGreaterThanFine = new InizioGreaterThanFineSpecification();
            
        //    ISpecification<CreareNuovoTipoInterventoRotMan> specs = InizioGreaterThanFine;

        //    specs.IsSatisfiedBy(this, vr);

        //    return vr;
        //}
    }
}
