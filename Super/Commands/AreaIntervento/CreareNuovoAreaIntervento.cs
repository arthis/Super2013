using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;
using System.ComponentModel.DataAnnotations;
using Commands.Attributes;

namespace Commands.AreaIntervento
{
    public class CreareNuovoAreaIntervento : CommandBase
    {
        public Guid Id { get; set; }
        public int IdAreaInterventoSuper { get; set; }
        [DataType(DataType.Date)]
        //[DateRange("2010/12/01", "2020/12/16")]
        //[Required]
        public DateTime Inizio { get; set; }
        [DataType(DataType.Date)]
        //[DateRange("2010/12/01", null)]
        public DateTime? Fine { get; set; }
        [Required(ErrorMessage ="test error message")]
        public string Descrizione { get; set; }
        [DataType(DataType.Date)]
        //[DateRange("2010/12/01", null)]
        //[Required]
        public DateTime CreationDate { get; set; }

        public CreareNuovoAreaIntervento()
        {
        }

        public CreareNuovoAreaIntervento(Guid id, int idAreaInterventoSuper, DateTime inizio, DateTime? fine, string descrizione, DateTime creationDate)
        {
            this.Id = id;
            this.IdAreaInterventoSuper = idAreaInterventoSuper;
            this.Inizio = inizio;
            this.Fine = fine;
            this.Descrizione = descrizione;
            this.CreationDate = creationDate;
        }

       
    }
}
