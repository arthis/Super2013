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
    [KnownType(typeof(CreareInterventoEstRot))]
    [KnownType(typeof(CreareInterventoEstAmb))]
    [KnownType(typeof(CreareInterventoEstRotMan))]
    public abstract class CreareInterventoEst : CommandBase
    {
        public Guid Id { get; set; }
        public int InterventoIdSuper { get; set; }
        public DateTime? Creazione { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public Guid IdAreaIntervento { get; set; }
        public Guid IdTipoIntervento { get; set; }
        public Guid IdAppaltatore { get; set; }
        public Guid IdCategoriaCommerciale { get; set; }
        public Guid IdDirezioneRegionale { get; set; }
        public string Note { get; set; }
        public string InterventoIdAppaltatore { get; set; }
        public DateTime DataConsuntivazione { get; set; }


        protected CreareInterventoEst(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, DateTime dataCreazione)
        {
            this.Id = id;
            this.InterventoIdSuper = interventoIdSuper;
            this.Inizio = inizio;
            this.Fine = fine;
            this.IdAreaIntervento = idAreaIntervento;
            this.Creazione = dataCreazione;
        }
    }

    [DataContract]
    public class CreareInterventoEstRot : CreareInterventoEst
    {
        public OggettoRot[] Oggetti { get; set; }
        public string NumeroTrenoArrivo { get; set; }
        public DateTime DataTrenoArrivo { get; set; }
        public string NumeroTrenoPartenza { get; set; }
        public DateTime DataTrenoPartenza { get; set; }
        public string TurnoTreno { get; set; }
        public string RigaTurnoTreno { get; set; }
        public string Convoglio { get; set; }

     
        public CreareInterventoEstRot(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, DateTime dataCreazione, OggettoRot[] oggetti)
            : base(id, interventoIdSuper, inizio, fine, idAreaIntervento, dataCreazione)
        {
            Oggetti = oggetti; 
        }
    }

    [DataContract]
    public class CreareInterventoEstAmb : CreareInterventoEst
    {
        public int Quantita { get; set; }
        public string Descrizione { get; set; }


        public CreareInterventoEstAmb(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, DateTime dataCreazione, int quantita, string descrizione)
            : base(id, interventoIdSuper, inizio, fine, idAreaIntervento, dataCreazione)
        {
            this.Quantita = quantita;
            this.Descrizione = descrizione;
        }
    }

    [DataContract]
    public class CreareInterventoEstRotMan : CreareInterventoEst
    {

        public OggettoRotMan[] Oggetti { get; set; }


        public CreareInterventoEstRotMan(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, DateTime dataCreazione, OggettoRotMan[] oggetti)
            : base(id, interventoIdSuper, inizio, fine, idAreaIntervento, dataCreazione)
        {
            Oggetti = oggetti; 
        }
    }
}
