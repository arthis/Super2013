using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using Ncqrs.Commanding;

namespace Commands
{
    public class CreareNuovoSettore : CommandBase
    {
        public Guid Id { get; set; }
        public string Mnemo { get; set; }
        public string Descrizione { get; set; }

        public CreareNuovoSettore()
        {
        }

        public CreareNuovoSettore(Guid id, string mnemo, string descrizione)
        {
            this.Id = id;
            this.Mnemo = mnemo;
            this.Descrizione = descrizione;
        }
    }
}
