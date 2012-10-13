



using System;
using System.Linq;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain;
using CommonDomain.Core;


namespace Super.Programmazione.Events.Schedulazione
{


	public class SchedulazioneRotCreated : Message, IEvent
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
		public Period Period { get; set;} 
		public string Convoglio { get; set;} 
		public string RigaTurnoTreno { get; set;} 
		public string TurnoTreno { get; set;} 
		public Treno TrenoArrivo { get; set;} 
		public Treno TrenoPartenza { get; set;} 
		public OggettoRot[] Oggetti { get; set;}

		public SchedulazioneRotCreated ()
		{
			//for serialisation
		}	     

		public SchedulazioneRotCreated(Guid id, Guid commitId, long version,Guid idProgramma,Guid idPeriodoProgrammazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,Period period,string convoglio,string rigaTurnoTreno,string turnoTreno,Treno trenoArrivo,Treno trenoPartenza,OggettoRot[] oggetti)
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
			Period = period ;
			Convoglio = convoglio ;
			RigaTurnoTreno = rigaTurnoTreno ;
			TurnoTreno = turnoTreno ;
			TrenoArrivo = trenoArrivo ;
			TrenoPartenza = trenoPartenza ;
			Oggetti = oggetti ;
		}
			public override string ToDescription()
		{
			return string.Format("La schedulazione rotabile é stata  creata", Id);
		}
		
		public bool Equals(SchedulazioneRotCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdProgramma, IdProgramma)  	 && Equals(other.IdPeriodoProgrammazione, IdPeriodoProgrammazione)  	 && Equals(other.IdCommittente, IdCommittente)  	 && Equals(other.IdLotto, IdLotto)  	 && Equals(other.IdImpianto, IdImpianto)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdAppaltatore, IdAppaltatore)  	 && Equals(other.IdCategoriaCommerciale, IdCategoriaCommerciale)  	 && Equals(other.IdDirezioneRegionale, IdDirezioneRegionale)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.Period, Period)  	 && Equals(other.Convoglio, Convoglio)  	 && Equals(other.RigaTurnoTreno, RigaTurnoTreno)  	 && Equals(other.TurnoTreno, TurnoTreno)  	 && Equals(other.TrenoArrivo, TrenoArrivo)  	 && Equals(other.TrenoPartenza, TrenoPartenza)  	 && other.Oggetti.SequenceEqual(Oggetti) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SchedulazioneRotCreated);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdProgramma != null ? IdProgramma.GetHashCode() : 0);
				result = (result*397) ^ (IdPeriodoProgrammazione != null ? IdPeriodoProgrammazione.GetHashCode() : 0);
				result = (result*397) ^ (IdCommittente != null ? IdCommittente.GetHashCode() : 0);
				result = (result*397) ^ (IdLotto != null ? IdLotto.GetHashCode() : 0);
				result = (result*397) ^ (IdImpianto != null ? IdImpianto.GetHashCode() : 0);
				result = (result*397) ^ (IdTipoIntervento != null ? IdTipoIntervento.GetHashCode() : 0);
				result = (result*397) ^ (IdAppaltatore != null ? IdAppaltatore.GetHashCode() : 0);
				result = (result*397) ^ (IdCategoriaCommerciale != null ? IdCategoriaCommerciale.GetHashCode() : 0);
				result = (result*397) ^ (IdDirezioneRegionale != null ? IdDirezioneRegionale.GetHashCode() : 0);
				result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				result = (result*397) ^ (Period != null ? Period.GetHashCode() : 0);
				result = (result*397) ^ (Convoglio != null ? Convoglio.GetHashCode() : 0);
				result = (result*397) ^ (RigaTurnoTreno != null ? RigaTurnoTreno.GetHashCode() : 0);
				result = (result*397) ^ (TurnoTreno != null ? TurnoTreno.GetHashCode() : 0);
				result = (result*397) ^ (TrenoArrivo != null ? TrenoArrivo.GetHashCode() : 0);
				result = (result*397) ^ (TrenoPartenza != null ? TrenoPartenza.GetHashCode() : 0);
				result = (result*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class SchedulazioneRotManCreated : Message, IEvent
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
		public Period Period { get; set;} 
		public OggettoRotMan[] Oggetti { get; set;}

		public SchedulazioneRotManCreated ()
		{
			//for serialisation
		}	     

		public SchedulazioneRotManCreated(Guid id, Guid commitId, long version,Guid idProgramma,Guid idPeriodoProgrammazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,Period period,OggettoRotMan[] oggetti)
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
			Period = period ;
			Oggetti = oggetti ;
		}
			public override string ToDescription()
		{
			return string.Format("La schedulazione rotabile in manutenzione é stata  creata", Id);
		}
		
		public bool Equals(SchedulazioneRotManCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdProgramma, IdProgramma)  	 && Equals(other.IdPeriodoProgrammazione, IdPeriodoProgrammazione)  	 && Equals(other.IdCommittente, IdCommittente)  	 && Equals(other.IdLotto, IdLotto)  	 && Equals(other.IdImpianto, IdImpianto)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdAppaltatore, IdAppaltatore)  	 && Equals(other.IdCategoriaCommerciale, IdCategoriaCommerciale)  	 && Equals(other.IdDirezioneRegionale, IdDirezioneRegionale)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.Period, Period)  	 && other.Oggetti.SequenceEqual(Oggetti) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SchedulazioneRotManCreated);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdProgramma != null ? IdProgramma.GetHashCode() : 0);
				result = (result*397) ^ (IdPeriodoProgrammazione != null ? IdPeriodoProgrammazione.GetHashCode() : 0);
				result = (result*397) ^ (IdCommittente != null ? IdCommittente.GetHashCode() : 0);
				result = (result*397) ^ (IdLotto != null ? IdLotto.GetHashCode() : 0);
				result = (result*397) ^ (IdImpianto != null ? IdImpianto.GetHashCode() : 0);
				result = (result*397) ^ (IdTipoIntervento != null ? IdTipoIntervento.GetHashCode() : 0);
				result = (result*397) ^ (IdAppaltatore != null ? IdAppaltatore.GetHashCode() : 0);
				result = (result*397) ^ (IdCategoriaCommerciale != null ? IdCategoriaCommerciale.GetHashCode() : 0);
				result = (result*397) ^ (IdDirezioneRegionale != null ? IdDirezioneRegionale.GetHashCode() : 0);
				result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				result = (result*397) ^ (Period != null ? Period.GetHashCode() : 0);
				result = (result*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class SchedulazioneAmbCreated : Message, IEvent
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
		public Period Period { get; set;} 
		public int Quantity { get; set;} 
		public string Description { get; set;}

		public SchedulazioneAmbCreated ()
		{
			//for serialisation
		}	     

		public SchedulazioneAmbCreated(Guid id, Guid commitId, long version,Guid idProgramma,Guid idPeriodoProgrammazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,Period period,int quantity,string description)
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
			Period = period ;
			Quantity = quantity ;
			Description = description ;
		}
			public override string ToDescription()
		{
			return string.Format("La schedulazione ambiente é stata  creata", Id);
		}
		
		public bool Equals(SchedulazioneAmbCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdProgramma, IdProgramma)  	 && Equals(other.IdPeriodoProgrammazione, IdPeriodoProgrammazione)  	 && Equals(other.IdCommittente, IdCommittente)  	 && Equals(other.IdLotto, IdLotto)  	 && Equals(other.IdImpianto, IdImpianto)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdAppaltatore, IdAppaltatore)  	 && Equals(other.IdCategoriaCommerciale, IdCategoriaCommerciale)  	 && Equals(other.IdDirezioneRegionale, IdDirezioneRegionale)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.Period, Period)  	 && Equals(other.Quantity, Quantity)  	 && Equals(other.Description, Description) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SchedulazioneAmbCreated);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdProgramma != null ? IdProgramma.GetHashCode() : 0);
				result = (result*397) ^ (IdPeriodoProgrammazione != null ? IdPeriodoProgrammazione.GetHashCode() : 0);
				result = (result*397) ^ (IdCommittente != null ? IdCommittente.GetHashCode() : 0);
				result = (result*397) ^ (IdLotto != null ? IdLotto.GetHashCode() : 0);
				result = (result*397) ^ (IdImpianto != null ? IdImpianto.GetHashCode() : 0);
				result = (result*397) ^ (IdTipoIntervento != null ? IdTipoIntervento.GetHashCode() : 0);
				result = (result*397) ^ (IdAppaltatore != null ? IdAppaltatore.GetHashCode() : 0);
				result = (result*397) ^ (IdCategoriaCommerciale != null ? IdCategoriaCommerciale.GetHashCode() : 0);
				result = (result*397) ^ (IdDirezioneRegionale != null ? IdDirezioneRegionale.GetHashCode() : 0);
				result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				result = (result*397) ^ (Period != null ? Period.GetHashCode() : 0);
				result = (result*397) ^ (Quantity != null ? Quantity.GetHashCode() : 0);
				result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
				return result;
            }
        }
	}
}
