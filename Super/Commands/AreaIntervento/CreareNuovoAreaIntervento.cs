using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;
using System.ComponentModel.DataAnnotations;
using Commands.Attributes;
using NServiceBus;

namespace Commands.AreaIntervento
{
    public class CreareNuovoAreaIntervento : CommandBase, IMessage
    {
        public Guid Id { get; set; }
        public int IdAreaInterventoSuper { get; set; }
        [DataType(DataType.Date)]
        public DateTime Inizio { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Fine { get; set; }
        public string Descrizione { get; set; }
        [DataType(DataType.Date)]
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
