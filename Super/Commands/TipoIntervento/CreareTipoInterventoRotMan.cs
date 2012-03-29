using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;
using System.ComponentModel.DataAnnotations;
using Commands.Attributes;

namespace Commands.TipoIntervento
{
    public class CreareTipoInterventoRotMan : CommandBase
    {
        public Guid Id { get; set; }
        public int IdTipoInterventoSuper { get; set; }
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
        public string Mnemo { get; set; }
        public Guid UnitaDiMisura { get; set; }
        public Guid IdContratto { get; set; }

        public CreareTipoInterventoRotMan()
        {
        }

        public CreareTipoInterventoRotMan(Guid id, int idTipoInterventoRotManSuper, DateTime inizio, DateTime? fine, string descrizione, DateTime creationDate)
        {
            this.Id = id;
            this.IdTipoInterventoSuper = idTipoInterventoRotManSuper;
            this.Inizio = inizio;
            this.Fine = fine;
            this.Descrizione = descrizione;
            this.CreationDate = creationDate;
        }

       
    }
}
