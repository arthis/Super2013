using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using Ncqrs.Commanding;
using System.Runtime.Serialization;

namespace Commands.Interventi
{
    [DataContract]
    [KnownType(typeof(CreareNuovoInterventoRotabile))]
    [KnownType(typeof(CreareNuovoInterventoAmbienti))]
    [KnownType(typeof(CreareNuovoInterventoRotabileInManutenzione))]
    public abstract class CreareNuovoIntervento : CommandBase
    {
        public Guid Id { get; set; }
        public int InterventoIdSuper { get; set; }
        public DateTime? Creazione { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public Guid IdAreaIntervento { get; set; }

        protected CreareNuovoIntervento()
        {
        }

       protected CreareNuovoIntervento(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento)
        {
            this.Id = id;
            this.InterventoIdSuper = interventoIdSuper;
            this.Inizio = inizio;
            this.Fine = fine;
            this.IdAreaIntervento = idAreaIntervento;
        }

       protected CreareNuovoIntervento(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, DateTime dataCreazione)
            : this(id, interventoIdSuper, inizio, fine, idAreaIntervento)
        {
            this.Creazione = dataCreazione;
        }
    }

    [DataContract]
    public class CreareNuovoInterventoRotabile : CreareNuovoIntervento
    {
        public OggettoInterventoRotabile[] Oggetti { get; set; }

        public CreareNuovoInterventoRotabile()
        {
        }

        public CreareNuovoInterventoRotabile(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, OggettoInterventoRotabile[] oggetti)
            :base (id,interventoIdSuper, inizio,fine, idAreaIntervento)
        {
            Oggetti = oggetti;   
        }

        public CreareNuovoInterventoRotabile(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, DateTime dataCreazione, OggettoInterventoRotabile[] oggetti)
            : base(id, interventoIdSuper, inizio, fine, idAreaIntervento, dataCreazione)
        {
            Oggetti = oggetti; 
        }
    }

    [DataContract]
    public class CreareNuovoInterventoAmbienti : CreareNuovoIntervento
    {
        public int Quantita { get; set; }
        public string Descrizione { get; set; }



        public CreareNuovoInterventoAmbienti(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, int quantita, string descrizione)
            : base(id, interventoIdSuper, inizio, fine, idAreaIntervento)
        {
            this.Quantita = quantita;
            this.Descrizione = descrizione;
        }

        public CreareNuovoInterventoAmbienti(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, DateTime dataCreazione, int quantita, string descrizione)
            : base(id, interventoIdSuper, inizio, fine, idAreaIntervento, dataCreazione)
        {
            this.Quantita = quantita;
            this.Descrizione = descrizione;
        }
    }

    [DataContract]
    public class CreareNuovoInterventoRotabileInManutenzione : CreareNuovoIntervento
    {

        public OggettoInterventoRotabileInManutenzione[] Oggetti { get; set; }

        public CreareNuovoInterventoRotabileInManutenzione(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, OggettoInterventoRotabileInManutenzione[] oggetti)
            :base (id,interventoIdSuper, inizio,fine, idAreaIntervento)
        {
            Oggetti = oggetti;   
        }

        public CreareNuovoInterventoRotabileInManutenzione(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, DateTime dataCreazione, OggettoInterventoRotabileInManutenzione[] oggetti)
            : base(id, interventoIdSuper, inizio, fine, idAreaIntervento, dataCreazione)
        {
            Oggetti = oggetti; 
        }
    }
}
