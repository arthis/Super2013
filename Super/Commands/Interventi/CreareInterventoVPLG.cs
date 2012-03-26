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
    [KnownType(typeof(CreareInterventoVPLGRot))]
    [KnownType(typeof(CreareInterventoVPLGAmb))]
    [KnownType(typeof(CreareInterventoVPLGRotMan))]
    public abstract class CreareInterventoVPLG : CommandBase
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

       protected CreareInterventoVPLG(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, DateTime dataCreazione)
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
    public class CreareInterventoVPLGRot : CreareInterventoVPLG
    {
        public OggettoRot[] Oggetti { get; set; }
        public string NumeroTrenoArrivo { get; set; }
        public DateTime DataTrenoArrivo { get; set; }
        public string NumeroTrenoPartenza { get; set; }
        public DateTime DataTrenoPartenza { get; set; }
        public string TurnoTreno { get; set; }
        public string RigaTurnoTreno { get; set; }
        public string Convoglio { get; set; }
        

        public CreareInterventoVPLGRot(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, DateTime dataCreazione, OggettoRot[] oggetti)
            : base(id, interventoIdSuper, inizio, fine, idAreaIntervento, dataCreazione)
        {
            Oggetti = oggetti; 
        }
    }

    [DataContract]
    public class CreareInterventoVPLGAmb : CreareInterventoVPLG
    {
        public int Quantita { get; set; }
        public string Descrizione { get; set; }


        public CreareInterventoVPLGAmb(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, DateTime dataCreazione, int quantita, string descrizione)
            : base(id, interventoIdSuper, inizio, fine, idAreaIntervento, dataCreazione)
        {
            this.Quantita = quantita;
            this.Descrizione = descrizione;
        }
    }

    [DataContract]
    public class CreareInterventoVPLGRotMan : CreareInterventoVPLG
    {

        public OggettoRotMan[] Oggetti { get; set; }


        public CreareInterventoVPLGRotMan(Guid id, int interventoIdSuper, DateTime inizio, DateTime fine, Guid idAreaIntervento, DateTime dataCreazione, OggettoRotMan[] oggetti)
            : base(id, interventoIdSuper, inizio, fine, idAreaIntervento, dataCreazione)
        {
            Oggetti = oggetti; 
        }
    }
}
