


using System;
using System.Linq;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain;
using CommonDomain.Core;


namespace Super.Programmazione.Events.Plan
{


	public class PlanCancelled : EventBase  
	{
	

		public PlanCancelled ()
		{
			//for serialisation
		}	     

		public PlanCancelled(Guid id, Guid commitId, long version)
		   : base(id,commitId,version)
		{
				}

		
			public override string ToDescription()
		{
			return string.Format("piano {0} é stato cancellato", Id);
		}
		
		public bool Equals(PlanCancelled other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as PlanCancelled);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				return result;
            }
        }
	}

	public class PlanCreated : EventBase  
	{
	 
		public Guid IdScenario { get; set;} 
		public Guid IdProgramma { get; set;}

		public PlanCreated ()
		{
			//for serialisation
		}	     

		public PlanCreated(Guid id, Guid commitId, long version,Guid idScenario,Guid idProgramma)
		   : base(id,commitId,version)
		{
			Contract.Requires(idScenario != Guid.Empty);

	Contract.Requires(idProgramma != Guid.Empty);

			IdScenario = idScenario ;
			IdProgramma = idProgramma ;
		}

		
			public override string ToDescription()
		{
			return string.Format("piano {0} é stato creato", Id);
		}
		
		public bool Equals(PlanCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdScenario, IdScenario)  	 && Equals(other.IdProgramma, IdProgramma) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as PlanCreated);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ IdScenario.GetHashCode();
				result = (result*397) ^ IdProgramma.GetHashCode();
				return result;
            }
        }
	}

	public class SchedulazioneRotAddedToPlan : EventBase  
	{
	 
		public Guid IdSchedulazione { get; set;} 
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

		public SchedulazioneRotAddedToPlan ()
		{
			//for serialisation
		}	     

		public SchedulazioneRotAddedToPlan(Guid id, Guid commitId, long version,Guid idSchedulazione,Guid idProgramma,Guid idPeriodoProgrammazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,Period period,string convoglio,string rigaTurnoTreno,string turnoTreno,Treno trenoArrivo,Treno trenoPartenza,OggettoRot[] oggetti)
		   : base(id,commitId,version)
		{
			Contract.Requires(idSchedulazione != Guid.Empty);

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

			IdSchedulazione = idSchedulazione ;
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
			return string.Format("La schedulazione rotabile é stata  aggiunta al piano", Id);
		}
		
		public bool Equals(SchedulazioneRotAddedToPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdSchedulazione, IdSchedulazione)  	 && Equals(other.IdProgramma, IdProgramma)  	 && Equals(other.IdPeriodoProgrammazione, IdPeriodoProgrammazione)  	 && Equals(other.IdCommittente, IdCommittente)  	 && Equals(other.IdLotto, IdLotto)  	 && Equals(other.IdImpianto, IdImpianto)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdAppaltatore, IdAppaltatore)  	 && Equals(other.IdCategoriaCommerciale, IdCategoriaCommerciale)  	 && Equals(other.IdDirezioneRegionale, IdDirezioneRegionale)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.Period, Period)  	 && Equals(other.Convoglio, Convoglio)  	 && Equals(other.RigaTurnoTreno, RigaTurnoTreno)  	 && Equals(other.TurnoTreno, TurnoTreno)  	 && Equals(other.TrenoArrivo, TrenoArrivo)  	 && Equals(other.TrenoPartenza, TrenoPartenza)  	 && other.Oggetti.SequenceEqual(Oggetti) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SchedulazioneRotAddedToPlan);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ IdSchedulazione.GetHashCode();
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

	public class SchedulazioneRotManAddedToPlan : EventBase  
	{
	 
		public Guid IdSchedulazione { get; set;} 
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

		public SchedulazioneRotManAddedToPlan ()
		{
			//for serialisation
		}	     

		public SchedulazioneRotManAddedToPlan(Guid id, Guid commitId, long version,Guid idSchedulazione,Guid idProgramma,Guid idPeriodoProgrammazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,Period period,OggettoRotMan[] oggetti)
		   : base(id,commitId,version)
		{
			Contract.Requires(idSchedulazione != Guid.Empty);

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

			IdSchedulazione = idSchedulazione ;
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
			return string.Format("La schedulazione rotabile in manutenzione é stata  aggiuntata al piano", Id);
		}
		
		public bool Equals(SchedulazioneRotManAddedToPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdSchedulazione, IdSchedulazione)  	 && Equals(other.IdProgramma, IdProgramma)  	 && Equals(other.IdPeriodoProgrammazione, IdPeriodoProgrammazione)  	 && Equals(other.IdCommittente, IdCommittente)  	 && Equals(other.IdLotto, IdLotto)  	 && Equals(other.IdImpianto, IdImpianto)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdAppaltatore, IdAppaltatore)  	 && Equals(other.IdCategoriaCommerciale, IdCategoriaCommerciale)  	 && Equals(other.IdDirezioneRegionale, IdDirezioneRegionale)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.Period, Period)  	 && other.Oggetti.SequenceEqual(Oggetti) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SchedulazioneRotManAddedToPlan);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ IdSchedulazione.GetHashCode();
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

	public class SchedulazioneAmbAddedToPlan : EventBase  
	{
	 
		public Guid IdSchedulazione { get; set;} 
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

		public SchedulazioneAmbAddedToPlan ()
		{
			//for serialisation
		}	     

		public SchedulazioneAmbAddedToPlan(Guid id, Guid commitId, long version,Guid idSchedulazione,Guid idProgramma,Guid idPeriodoProgrammazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,Period period,int quantity,string description)
		   : base(id,commitId,version)
		{
			Contract.Requires(idSchedulazione != Guid.Empty);

	Contract.Requires(idProgramma != Guid.Empty);

	Contract.Requires(idPeriodoProgrammazione != Guid.Empty);

	Contract.Requires(idCommittente != Guid.Empty);

	Contract.Requires(idLotto != Guid.Empty);

	Contract.Requires(idImpianto != Guid.Empty);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idAppaltatore != Guid.Empty);

	Contract.Requires(idCategoriaCommerciale != Guid.Empty);

	Contract.Requires(idDirezioneRegionale != Guid.Empty);

			IdSchedulazione = idSchedulazione ;
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
			return string.Format("La schedulazione ambiente é stata  aggiunta al piano", Id);
		}
		
		public bool Equals(SchedulazioneAmbAddedToPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdSchedulazione, IdSchedulazione)  	 && Equals(other.IdProgramma, IdProgramma)  	 && Equals(other.IdPeriodoProgrammazione, IdPeriodoProgrammazione)  	 && Equals(other.IdCommittente, IdCommittente)  	 && Equals(other.IdLotto, IdLotto)  	 && Equals(other.IdImpianto, IdImpianto)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdAppaltatore, IdAppaltatore)  	 && Equals(other.IdCategoriaCommerciale, IdCategoriaCommerciale)  	 && Equals(other.IdDirezioneRegionale, IdDirezioneRegionale)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.Period, Period)  	 && Equals(other.Quantity, Quantity)  	 && Equals(other.Description, Description) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SchedulazioneAmbAddedToPlan);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ IdSchedulazione.GetHashCode();
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

	public class SchedulazioneCancelledFromPlan : EventBase  
	{
	 
		public Guid IdUser { get; set;} 
		public Guid DeleteGeneratedInterventoToo { get; set;}

		public SchedulazioneCancelledFromPlan ()
		{
			//for serialisation
		}	     

		public SchedulazioneCancelledFromPlan(Guid id, Guid commitId, long version,Guid idUser,Guid deleteGeneratedInterventoToo)
		   : base(id,commitId,version)
		{
			Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(deleteGeneratedInterventoToo != Guid.Empty);

			IdUser = idUser ;
			DeleteGeneratedInterventoToo = deleteGeneratedInterventoToo ;
		}

		
			public override string ToDescription()
		{
			return string.Format("Schedulazione {0} é stat cancellata dal piano", Id);
		}
		
		public bool Equals(SchedulazioneCancelledFromPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdUser, IdUser)  	 && Equals(other.DeleteGeneratedInterventoToo, DeleteGeneratedInterventoToo) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SchedulazioneCancelledFromPlan);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ IdUser.GetHashCode();
				result = (result*397) ^ DeleteGeneratedInterventoToo.GetHashCode();
				return result;
            }
        }
	}
}
