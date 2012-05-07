using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot;
using Cqrs.Domain;
using Events;

namespace Domain
{
    [DynamicSnapshot]
    public class Settore : AggregateRootMappedByConvention
    {
        public string Mnemo { get; set; }
        public string Descrizione { get; set; }

        public Settore(Guid id,  string mnemo, string descrizione)
            : base(id)
        {
            SettoreCreato evt = new SettoreCreato()
            {
                Mnemo = mnemo,
                Descrizione = descrizione,
            };

            ApplyEvent(evt);
        }

        public void OnSettoreCreato(SettoreCreato e)
        {
            Mnemo = e.Mnemo;
            Descrizione = e.Descrizione;
        }
    }
}
