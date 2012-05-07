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
    public class AggiornareTipoInterventoAmb : CommandBase
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

        public AggiornareTipoInterventoAmb()
        {
        }

        public AggiornareTipoInterventoAmb(Guid id, int idTipoInterventoAmbSuper, DateTime inizio, DateTime? fine, string descrizione)
        {

            this.Id = id;
            this.IdTipoInterventoSuper = idTipoInterventoAmbSuper;
            this.Inizio = inizio;
            this.Fine = fine;
            this.Descrizione = descrizione;
        }

        //public ValidationResult Validate()
        //{
        //    ValidationResult vr = new ValidationResult();
            
        //    InizioGreaterThanFineSpecification InizioGreaterThanFine = new InizioGreaterThanFineSpecification();
            
        //    ISpecification<CreareNuovoTipoInterventoAmb> specs = InizioGreaterThanFine;

        //    specs.IsSatisfiedBy(this, vr);

        //    return vr;
        //}
    }
}
