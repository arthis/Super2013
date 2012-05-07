using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cqrs.Commanding.CommandExecution.Mapping.Attributes;
using Cqrs.Commanding;

namespace Commands
{
    public class CreareNuovaCausale : CommandBase
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; }
        public string Mnemo { get; set; }
        public string Descrizione { get; set; }
        public Guid IdSettoreIntervento { get; set; }

        public CreareNuovaCausale()
        {
        }

        public CreareNuovaCausale(Guid id, string tipo, string mnemo, string descrizione, Guid idSettoreIntervento)
        {
            this.Id = id;
            Tipo = tipo;
            Mnemo = mnemo;
            Descrizione = descrizione;
            IdSettoreIntervento = idSettoreIntervento;
        }
    }
}
