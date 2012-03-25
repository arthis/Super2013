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
    [KnownType(typeof(CreareNuovoInterventoRot))]
    [KnownType(typeof(CreareNuovoInterventoAmb))]
    [KnownType(typeof(CreareNuovoInterventoRotMan))]
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
    public class CreareNuovoInterventoRot : CreareNuovoIntervento
    {
        public OggettoInterventoRot[] Oggetti { get; set; }

        public CreareNuovoInterventoRot()
        {
        }

        public CreareNuovoInterventoRot(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, OggettoInterventoRot[] oggetti)
            :base (id,interventoIdSuper, inizio,fine, idAreaIntervento)
        {
            Oggetti = oggetti;   
        }

        public CreareNuovoInterventoRot(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, DateTime dataCreazione, OggettoInterventoRot[] oggetti)
            : base(id, interventoIdSuper, inizio, fine, idAreaIntervento, dataCreazione)
        {
            Oggetti = oggetti; 
        }
    }

    [DataContract]
    public class CreareNuovoInterventoAmb : CreareNuovoIntervento
    {
        public int Quantita { get; set; }
        public string Descrizione { get; set; }



        public CreareNuovoInterventoAmb(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, int quantita, string descrizione)
            : base(id, interventoIdSuper, inizio, fine, idAreaIntervento)
        {
            this.Quantita = quantita;
            this.Descrizione = descrizione;
        }

        public CreareNuovoInterventoAmb(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, DateTime dataCreazione, int quantita, string descrizione)
            : base(id, interventoIdSuper, inizio, fine, idAreaIntervento, dataCreazione)
        {
            this.Quantita = quantita;
            this.Descrizione = descrizione;
        }
    }

    [DataContract]
    public class CreareNuovoInterventoRotMan : CreareNuovoIntervento
    {

        public OggettoInterventoRotMan[] Oggetti { get; set; }

        public CreareNuovoInterventoRotMan(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, OggettoInterventoRotMan[] oggetti)
            :base (id,interventoIdSuper, inizio,fine, idAreaIntervento)
        {
            Oggetti = oggetti;   
        }

        public CreareNuovoInterventoRotMan(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, DateTime dataCreazione, OggettoInterventoRotMan[] oggetti)
            : base(id, interventoIdSuper, inizio, fine, idAreaIntervento, dataCreazione)
        {
            Oggetti = oggetti; 
        }
    }
}
