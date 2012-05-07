using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cqrs.Commanding;
using System.ComponentModel.DataAnnotations;
using Commands.Attributes;
using Cqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Commands.TipoIntervento
{
    public class AggiornareTipoInterventoRot : CommandBase
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

        public AggiornareTipoInterventoRot()
        {
        }

        public AggiornareTipoInterventoRot(Guid id, int idTipoInterventoRotSuper, DateTime inizio, DateTime? fine, string descrizione)
        {

            this.Id = id;
            this.IdTipoInterventoSuper = idTipoInterventoRotSuper;
            this.Inizio = inizio;
            this.Fine = fine;
            this.Descrizione = descrizione;
        }

        //public ValidationResult Validate()
        //{
        //    ValidationResult vr = new ValidationResult();
            
        //    InizioGreaterThanFineSpecification InizioGreaterThanFine = new InizioGreaterThanFineSpecification();
            
        //    ISpecification<CreareNuovoTipoInterventoRot> specs = InizioGreaterThanFine;

        //    specs.IsSatisfiedBy(this, vr);

        //    return vr;
        //}
    }
}
