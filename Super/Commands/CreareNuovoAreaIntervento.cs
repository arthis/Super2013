﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using Ncqrs.Commanding;

namespace Commands
{
    public class CreareNuovoAreaIntervento : CommandBase
    {
        public Guid Id { get; set; }
        public int IdAreaInterventoSuper { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }

        public CreareNuovoAreaIntervento()
        {
        }

        public CreareNuovoAreaIntervento(Guid id, int idAreaInterventoSuper, DateTime inizio, DateTime fine)
        {
            this.Id = id;
            this.IdAreaInterventoSuper = idAreaInterventoSuper;
            this.Inizio = inizio;
            this.Fine = fine;
        }
    }
}
