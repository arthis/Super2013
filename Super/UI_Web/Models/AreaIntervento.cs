using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UI_Web.Models
{
    public class CreareAreaIntervento
    {
        public Guid Id { get; set; }
        public int IdAreaInterventoSuper { get; set; }
        [DataType(DataType.Date)]
        public DateTime Inizio { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fine { get; set; }
        public string Descrizione { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
    }
}