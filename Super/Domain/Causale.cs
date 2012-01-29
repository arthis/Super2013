using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot;
using Ncqrs.Domain;
using Events;

namespace Domain
{
    [DynamicSnapshot]
    public class Causale : AggregateRootMappedByConvention
    {
        public string Tipo { get; set; }
        public string Mnemo { get; set; }
        public string Descrizione { get; set; }
        public Guid IdSettoreIntervento { get; set; }

        public Causale(Guid id, string tipo, string mnemo, string descrizione, Guid idSettoreIntervento)
            : base(id)
        {
            CausaleCreata evt = new CausaleCreata()
            {
                Tipo = tipo,
                Mnemo = mnemo,
                Descrizione = descrizione,
                IdSettoreIntervento = idSettoreIntervento
            };

            ApplyEvent(evt);
        }

        public void OnCausaleCreata(CausaleCreata e)
        {
            Tipo = e.Tipo;
            Mnemo = e.Mnemo;
            Descrizione = e.Descrizione;
            IdSettoreIntervento = e.IdSettoreIntervento;
        }
    }
}
