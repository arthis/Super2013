


using System;
using System.Linq;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain;
using CommonDomain.Core;


namespace Super.Controllo.Events.Programmazione
{


	public class InterventoRotProgrammato : EventBase  
	{
	 
		public Guid IdProgramma { get; set;} 
		public Guid IdPeriodoProgrammazione { get; set;} 
		public Guid IdCommittente { get; set;} 
		public Guid IdLotto { get; set;} 
		public Guid IdImpianto { get; set;} 
		public Guid IdTipoIntervento { get; set;} 
		public Guid IdAppaltatore { get; set;} 
		public Guid IdCategoriaCommerciale { get; set;} 
		public Guid IdDirezioneRegionale { get; set;} 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public string Convoglio { get; set;} 
		public string RigaTurnoTreno { get; set;} 
		public string TurnoTreno { get; set;} 
		public Treno TrenoArrivo { get; set;} 
		public Treno TrenoPartenza { get; set;} 
		public OggettoRot[] Oggetti { get; set;}

		public InterventoRotProgrammato ()
		{
			//for serialisation
		}	     

		public InterventoRotProgrammato(Guid id, Guid commitId, long version,Guid idProgramma,Guid idPeriodoProgrammazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,string convoglio,string rigaTurnoTreno,string turnoTreno,Treno trenoArrivo,Treno trenoPartenza,OggettoRot[] oggetti)
		   : base(id,commitId,version)
		{
			Contract.Requires(idProgramma != Guid.Empty);

	Contract.Requires(idPeriodoProgrammazione != Guid.Empty);

	Contract.Requires(idCommittente != Guid.Empty);

	Contract.Requires(idLotto != Guid.Empty);

	Contract.Requires(idImpianto != Guid.Empty);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idAppaltatore != Guid.Empty);

	Contract.Requires(idCategoriaCommerciale != Guid.Empty);

	Contract.Requires(idDirezioneRegionale != Guid.Empty);

	Contract.Requires(oggetti != null);

			IdProgramma = idProgramma ;
			IdPeriodoProgrammazione = idPeriodoProgrammazione ;
			IdCommittente = idCommittente ;
			IdLotto = idLotto ;
			IdImpianto = idImpianto ;
			IdTipoIntervento = idTipoIntervento ;
			IdAppaltatore = idAppaltatore ;
			IdCategoriaCommerciale = idCategoriaCommerciale ;
			IdDirezioneRegionale = idDirezioneRegionale ;
			Note = note ;
			WorkPeriod = workPeriod ;
			Convoglio = convoglio ;
			RigaTurnoTreno = rigaTurnoTreno ;
			TurnoTreno = turnoTreno ;
			TrenoArrivo = trenoArrivo ;
			TrenoPartenza = trenoPartenza ;
			Oggetti = oggetti ;
		}

		
			public override string ToDescription()
		{
			return string.Format("il intervento rotabile é stato  programmato", Id);
		}
		
		public bool Equals(InterventoRotProgrammato other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdProgramma, IdProgramma)  	 && Equals(other.IdPeriodoProgrammazione, IdPeriodoProgrammazione)  	 && Equals(other.IdCommittente, IdCommittente)  	 && Equals(other.IdLotto, IdLotto)  	 && Equals(other.IdImpianto, IdImpianto)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdAppaltatore, IdAppaltatore)  	 && Equals(other.IdCategoriaCommerciale, IdCategoriaCommerciale)  	 && Equals(other.IdDirezioneRegionale, IdDirezioneRegionale)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.Convoglio, Convoglio)  	 && Equals(other.RigaTurnoTreno, RigaTurnoTreno)  	 && Equals(other.TurnoTreno, TurnoTreno)  	 && Equals(other.TrenoArrivo, TrenoArrivo)  	 && Equals(other.TrenoPartenza, TrenoPartenza)  	 && other.Oggetti.SequenceEqual(Oggetti) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotProgrammato);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ IdProgramma.GetHashCode();
				result = (result*397) ^ IdPeriodoProgrammazione.GetHashCode();
				result = (result*397) ^ IdCommittente.GetHashCode();
				result = (result*397) ^ IdLotto.GetHashCode();
				result = (result*397) ^ IdImpianto.GetHashCode();
				result = (result*397) ^ IdTipoIntervento.GetHashCode();
				result = (result*397) ^ IdAppaltatore.GetHashCode();
				result = (result*397) ^ IdCategoriaCommerciale.GetHashCode();
				result = (result*397) ^ IdDirezioneRegionale.GetHashCode();
				
				
				
				
				
				
				
				result = (result*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class InterventoRotManProgrammato : EventBase  
	{
	 
		public Guid IdProgramma { get; set;} 
		public Guid IdPeriodoProgrammazione { get; set;} 
		public Guid IdCommittente { get; set;} 
		public Guid IdLotto { get; set;} 
		public Guid IdImpianto { get; set;} 
		public Guid IdTipoIntervento { get; set;} 
		public Guid IdAppaltatore { get; set;} 
		public Guid IdCategoriaCommerciale { get; set;} 
		public Guid IdDirezioneRegionale { get; set;} 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public OggettoRotMan[] Oggetti { get; set;}

		public InterventoRotManProgrammato ()
		{
			//for serialisation
		}	     

		public InterventoRotManProgrammato(Guid id, Guid commitId, long version,Guid idProgramma,Guid idPeriodoProgrammazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,OggettoRotMan[] oggetti)
		   : base(id,commitId,version)
		{
			Contract.Requires(idProgramma != Guid.Empty);

	Contract.Requires(idPeriodoProgrammazione != Guid.Empty);

	Contract.Requires(idCommittente != Guid.Empty);

	Contract.Requires(idLotto != Guid.Empty);

	Contract.Requires(idImpianto != Guid.Empty);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idAppaltatore != Guid.Empty);

	Contract.Requires(idCategoriaCommerciale != Guid.Empty);

	Contract.Requires(idDirezioneRegionale != Guid.Empty);

	Contract.Requires(oggetti != null);

			IdProgramma = idProgramma ;
			IdPeriodoProgrammazione = idPeriodoProgrammazione ;
			IdCommittente = idCommittente ;
			IdLotto = idLotto ;
			IdImpianto = idImpianto ;
			IdTipoIntervento = idTipoIntervento ;
			IdAppaltatore = idAppaltatore ;
			IdCategoriaCommerciale = idCategoriaCommerciale ;
			IdDirezioneRegionale = idDirezioneRegionale ;
			Note = note ;
			WorkPeriod = workPeriod ;
			Oggetti = oggetti ;
		}

		
			public override string ToDescription()
		{
			return string.Format("Il intervento rotabile in manutenzione é stato programmato", Id);
		}
		
		public bool Equals(InterventoRotManProgrammato other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdProgramma, IdProgramma)  	 && Equals(other.IdPeriodoProgrammazione, IdPeriodoProgrammazione)  	 && Equals(other.IdCommittente, IdCommittente)  	 && Equals(other.IdLotto, IdLotto)  	 && Equals(other.IdImpianto, IdImpianto)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdAppaltatore, IdAppaltatore)  	 && Equals(other.IdCategoriaCommerciale, IdCategoriaCommerciale)  	 && Equals(other.IdDirezioneRegionale, IdDirezioneRegionale)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && other.Oggetti.SequenceEqual(Oggetti) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotManProgrammato);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ IdProgramma.GetHashCode();
				result = (result*397) ^ IdPeriodoProgrammazione.GetHashCode();
				result = (result*397) ^ IdCommittente.GetHashCode();
				result = (result*397) ^ IdLotto.GetHashCode();
				result = (result*397) ^ IdImpianto.GetHashCode();
				result = (result*397) ^ IdTipoIntervento.GetHashCode();
				result = (result*397) ^ IdAppaltatore.GetHashCode();
				result = (result*397) ^ IdCategoriaCommerciale.GetHashCode();
				result = (result*397) ^ IdDirezioneRegionale.GetHashCode();
				
				
				result = (result*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class InterventoAmbProgrammato : EventBase  
	{
	 
		public Guid IdProgramma { get; set;} 
		public Guid IdPeriodoProgrammazione { get; set;} 
		public Guid IdCommittente { get; set;} 
		public Guid IdLotto { get; set;} 
		public Guid IdImpianto { get; set;} 
		public Guid IdTipoIntervento { get; set;} 
		public Guid IdAppaltatore { get; set;} 
		public Guid IdCategoriaCommerciale { get; set;} 
		public Guid IdDirezioneRegionale { get; set;} 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public int Quantity { get; set;} 
		public string Description { get; set;}

		public InterventoAmbProgrammato ()
		{
			//for serialisation
		}	     

		public InterventoAmbProgrammato(Guid id, Guid commitId, long version,Guid idProgramma,Guid idPeriodoProgrammazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,int quantity,string description)
		   : base(id,commitId,version)
		{
			Contract.Requires(idProgramma != Guid.Empty);

	Contract.Requires(idPeriodoProgrammazione != Guid.Empty);

	Contract.Requires(idCommittente != Guid.Empty);

	Contract.Requires(idLotto != Guid.Empty);

	Contract.Requires(idImpianto != Guid.Empty);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idAppaltatore != Guid.Empty);

	Contract.Requires(idCategoriaCommerciale != Guid.Empty);

	Contract.Requires(idDirezioneRegionale != Guid.Empty);

			IdProgramma = idProgramma ;
			IdPeriodoProgrammazione = idPeriodoProgrammazione ;
			IdCommittente = idCommittente ;
			IdLotto = idLotto ;
			IdImpianto = idImpianto ;
			IdTipoIntervento = idTipoIntervento ;
			IdAppaltatore = idAppaltatore ;
			IdCategoriaCommerciale = idCategoriaCommerciale ;
			IdDirezioneRegionale = idDirezioneRegionale ;
			Note = note ;
			WorkPeriod = workPeriod ;
			Quantity = quantity ;
			Description = description ;
		}

		
			public override string ToDescription()
		{
			return string.Format("Il intervento ambiente é stato programmato", Id);
		}
		
		public bool Equals(InterventoAmbProgrammato other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdProgramma, IdProgramma)  	 && Equals(other.IdPeriodoProgrammazione, IdPeriodoProgrammazione)  	 && Equals(other.IdCommittente, IdCommittente)  	 && Equals(other.IdLotto, IdLotto)  	 && Equals(other.IdImpianto, IdImpianto)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdAppaltatore, IdAppaltatore)  	 && Equals(other.IdCategoriaCommerciale, IdCategoriaCommerciale)  	 && Equals(other.IdDirezioneRegionale, IdDirezioneRegionale)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.Quantity, Quantity)  	 && Equals(other.Description, Description) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoAmbProgrammato);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ IdProgramma.GetHashCode();
				result = (result*397) ^ IdPeriodoProgrammazione.GetHashCode();
				result = (result*397) ^ IdCommittente.GetHashCode();
				result = (result*397) ^ IdLotto.GetHashCode();
				result = (result*397) ^ IdImpianto.GetHashCode();
				result = (result*397) ^ IdTipoIntervento.GetHashCode();
				result = (result*397) ^ IdAppaltatore.GetHashCode();
				result = (result*397) ^ IdCategoriaCommerciale.GetHashCode();
				result = (result*397) ^ IdDirezioneRegionale.GetHashCode();
				
				
				
				
				return result;
            }
        }
	}
}
