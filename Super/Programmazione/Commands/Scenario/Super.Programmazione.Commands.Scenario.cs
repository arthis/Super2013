

using System;
using System.Linq;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain;
using CommonDomain.Core;


namespace Super.Programmazione.Commands.Scenario
{


	public class AddSchedulazioneRotToScenario :  CommandBase  
	{
	 
		public Guid IdPeriodoProgrammazione { get; set;} 
		public Guid IdSchedulazione { get; set;} 
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

		public AddSchedulazioneRotToScenario ()
		{
			//for serialisation
		}


		public AddSchedulazioneRotToScenario(Guid id, Guid commitId,Guid idPeriodoProgrammazione,Guid idSchedulazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,Period period,string convoglio,string rigaTurnoTreno,string turnoTreno,Treno trenoArrivo,Treno trenoPartenza,OggettoRot[] oggetti)
		   : base(id,commitId)
		{
			Contract.Requires(idPeriodoProgrammazione != Guid.Empty);

	Contract.Requires(idSchedulazione != Guid.Empty);

	Contract.Requires(idCommittente != Guid.Empty);

	Contract.Requires(idLotto != Guid.Empty);

	Contract.Requires(idImpianto != Guid.Empty);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idAppaltatore != Guid.Empty);

	Contract.Requires(idCategoriaCommerciale != Guid.Empty);

	Contract.Requires(idDirezioneRegionale != Guid.Empty);

	Contract.Requires(oggetti != null);

			IdPeriodoProgrammazione = idPeriodoProgrammazione ;
			IdSchedulazione = idSchedulazione ;
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
	     

		public AddSchedulazioneRotToScenario(Guid id, Guid commitId, long version,Guid idPeriodoProgrammazione,Guid idSchedulazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,Period period,string convoglio,string rigaTurnoTreno,string turnoTreno,Treno trenoArrivo,Treno trenoPartenza,OggettoRot[] oggetti)
		   : base(id,commitId,version)
		{
			Contract.Requires(idPeriodoProgrammazione != Guid.Empty);

	Contract.Requires(idSchedulazione != Guid.Empty);

	Contract.Requires(idCommittente != Guid.Empty);

	Contract.Requires(idLotto != Guid.Empty);

	Contract.Requires(idImpianto != Guid.Empty);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idAppaltatore != Guid.Empty);

	Contract.Requires(idCategoriaCommerciale != Guid.Empty);

	Contract.Requires(idDirezioneRegionale != Guid.Empty);

	Contract.Requires(oggetti != null);

			IdPeriodoProgrammazione = idPeriodoProgrammazione ;
			IdSchedulazione = idSchedulazione ;
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

		
		public AddSchedulazioneRotToScenario(Guid id, Guid commitId, DateTime wakeupTime,Guid idPeriodoProgrammazione,Guid idSchedulazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,Period period,string convoglio,string rigaTurnoTreno,string turnoTreno,Treno trenoArrivo,Treno trenoPartenza,OggettoRot[] oggetti)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(idPeriodoProgrammazione != Guid.Empty);

	Contract.Requires(idSchedulazione != Guid.Empty);

	Contract.Requires(idCommittente != Guid.Empty);

	Contract.Requires(idLotto != Guid.Empty);

	Contract.Requires(idImpianto != Guid.Empty);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idAppaltatore != Guid.Empty);

	Contract.Requires(idCategoriaCommerciale != Guid.Empty);

	Contract.Requires(idDirezioneRegionale != Guid.Empty);

	Contract.Requires(oggetti != null);

			IdPeriodoProgrammazione = idPeriodoProgrammazione ;
			IdSchedulazione = idSchedulazione ;
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


		public AddSchedulazioneRotToScenario(Guid id, Guid commitId, long version, DateTime wakeupTime,Guid idPeriodoProgrammazione,Guid idSchedulazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,Period period,string convoglio,string rigaTurnoTreno,string turnoTreno,Treno trenoArrivo,Treno trenoPartenza,OggettoRot[] oggetti)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idPeriodoProgrammazione != Guid.Empty);

	Contract.Requires(idSchedulazione != Guid.Empty);

	Contract.Requires(idCommittente != Guid.Empty);

	Contract.Requires(idLotto != Guid.Empty);

	Contract.Requires(idImpianto != Guid.Empty);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idAppaltatore != Guid.Empty);

	Contract.Requires(idCategoriaCommerciale != Guid.Empty);

	Contract.Requires(idDirezioneRegionale != Guid.Empty);

	Contract.Requires(oggetti != null);

			IdPeriodoProgrammazione = idPeriodoProgrammazione ;
			IdSchedulazione = idSchedulazione ;
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
			return string.Format("Aggiungere una schedulazione rotabile al scenario", Id);
		}
		
		public bool Equals(AddSchedulazioneRotToScenario other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdPeriodoProgrammazione, IdPeriodoProgrammazione)  	 && Equals(other.IdSchedulazione, IdSchedulazione)  	 && Equals(other.IdCommittente, IdCommittente)  	 && Equals(other.IdLotto, IdLotto)  	 && Equals(other.IdImpianto, IdImpianto)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdAppaltatore, IdAppaltatore)  	 && Equals(other.IdCategoriaCommerciale, IdCategoriaCommerciale)  	 && Equals(other.IdDirezioneRegionale, IdDirezioneRegionale)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.Period, Period)  	 && Equals(other.Convoglio, Convoglio)  	 && Equals(other.RigaTurnoTreno, RigaTurnoTreno)  	 && Equals(other.TurnoTreno, TurnoTreno)  	 && Equals(other.TrenoArrivo, TrenoArrivo)  	 && Equals(other.TrenoPartenza, TrenoPartenza)  	 && other.Oggetti.SequenceEqual(Oggetti) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AddSchedulazioneRotToScenario);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdPeriodoProgrammazione != null ? IdPeriodoProgrammazione.GetHashCode() : 0);
				result = (result*397) ^ (IdSchedulazione != null ? IdSchedulazione.GetHashCode() : 0);
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

	public class AddSchedulazioneRotManToScenario :  CommandBase  
	{
	 
		public Guid IdPeriodoProgrammazione { get; set;} 
		public Guid IdSchedulazione { get; set;} 
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

		public AddSchedulazioneRotManToScenario ()
		{
			//for serialisation
		}


		public AddSchedulazioneRotManToScenario(Guid id, Guid commitId,Guid idPeriodoProgrammazione,Guid idSchedulazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,Period period,OggettoRotMan[] oggetti)
		   : base(id,commitId)
		{
			Contract.Requires(idPeriodoProgrammazione != Guid.Empty);

	Contract.Requires(idSchedulazione != Guid.Empty);

	Contract.Requires(idCommittente != Guid.Empty);

	Contract.Requires(idLotto != Guid.Empty);

	Contract.Requires(idImpianto != Guid.Empty);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idAppaltatore != Guid.Empty);

	Contract.Requires(idCategoriaCommerciale != Guid.Empty);

	Contract.Requires(idDirezioneRegionale != Guid.Empty);

	Contract.Requires(oggetti != null);

			IdPeriodoProgrammazione = idPeriodoProgrammazione ;
			IdSchedulazione = idSchedulazione ;
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
	     

		public AddSchedulazioneRotManToScenario(Guid id, Guid commitId, long version,Guid idPeriodoProgrammazione,Guid idSchedulazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,Period period,OggettoRotMan[] oggetti)
		   : base(id,commitId,version)
		{
			Contract.Requires(idPeriodoProgrammazione != Guid.Empty);

	Contract.Requires(idSchedulazione != Guid.Empty);

	Contract.Requires(idCommittente != Guid.Empty);

	Contract.Requires(idLotto != Guid.Empty);

	Contract.Requires(idImpianto != Guid.Empty);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idAppaltatore != Guid.Empty);

	Contract.Requires(idCategoriaCommerciale != Guid.Empty);

	Contract.Requires(idDirezioneRegionale != Guid.Empty);

	Contract.Requires(oggetti != null);

			IdPeriodoProgrammazione = idPeriodoProgrammazione ;
			IdSchedulazione = idSchedulazione ;
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

		
		public AddSchedulazioneRotManToScenario(Guid id, Guid commitId, DateTime wakeupTime,Guid idPeriodoProgrammazione,Guid idSchedulazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,Period period,OggettoRotMan[] oggetti)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(idPeriodoProgrammazione != Guid.Empty);

	Contract.Requires(idSchedulazione != Guid.Empty);

	Contract.Requires(idCommittente != Guid.Empty);

	Contract.Requires(idLotto != Guid.Empty);

	Contract.Requires(idImpianto != Guid.Empty);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idAppaltatore != Guid.Empty);

	Contract.Requires(idCategoriaCommerciale != Guid.Empty);

	Contract.Requires(idDirezioneRegionale != Guid.Empty);

	Contract.Requires(oggetti != null);

			IdPeriodoProgrammazione = idPeriodoProgrammazione ;
			IdSchedulazione = idSchedulazione ;
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


		public AddSchedulazioneRotManToScenario(Guid id, Guid commitId, long version, DateTime wakeupTime,Guid idPeriodoProgrammazione,Guid idSchedulazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,Period period,OggettoRotMan[] oggetti)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idPeriodoProgrammazione != Guid.Empty);

	Contract.Requires(idSchedulazione != Guid.Empty);

	Contract.Requires(idCommittente != Guid.Empty);

	Contract.Requires(idLotto != Guid.Empty);

	Contract.Requires(idImpianto != Guid.Empty);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idAppaltatore != Guid.Empty);

	Contract.Requires(idCategoriaCommerciale != Guid.Empty);

	Contract.Requires(idDirezioneRegionale != Guid.Empty);

	Contract.Requires(oggetti != null);

			IdPeriodoProgrammazione = idPeriodoProgrammazione ;
			IdSchedulazione = idSchedulazione ;
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
			return string.Format("Aggiungere una schedulazione rotabile in manutenzione al scenario", Id);
		}
		
		public bool Equals(AddSchedulazioneRotManToScenario other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdPeriodoProgrammazione, IdPeriodoProgrammazione)  	 && Equals(other.IdSchedulazione, IdSchedulazione)  	 && Equals(other.IdCommittente, IdCommittente)  	 && Equals(other.IdLotto, IdLotto)  	 && Equals(other.IdImpianto, IdImpianto)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdAppaltatore, IdAppaltatore)  	 && Equals(other.IdCategoriaCommerciale, IdCategoriaCommerciale)  	 && Equals(other.IdDirezioneRegionale, IdDirezioneRegionale)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.Period, Period)  	 && other.Oggetti.SequenceEqual(Oggetti) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AddSchedulazioneRotManToScenario);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdPeriodoProgrammazione != null ? IdPeriodoProgrammazione.GetHashCode() : 0);
				result = (result*397) ^ (IdSchedulazione != null ? IdSchedulazione.GetHashCode() : 0);
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

	public class AddSchedulazioneAmbToScenario :  CommandBase  
	{
	 
		public Guid IdPeriodoProgrammazione { get; set;} 
		public Guid IdSchedulazione { get; set;} 
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

		public AddSchedulazioneAmbToScenario ()
		{
			//for serialisation
		}


		public AddSchedulazioneAmbToScenario(Guid id, Guid commitId,Guid idPeriodoProgrammazione,Guid idSchedulazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,Period period,int quantity,string description)
		   : base(id,commitId)
		{
			Contract.Requires(idPeriodoProgrammazione != Guid.Empty);

	Contract.Requires(idSchedulazione != Guid.Empty);

	Contract.Requires(idCommittente != Guid.Empty);

	Contract.Requires(idLotto != Guid.Empty);

	Contract.Requires(idImpianto != Guid.Empty);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idAppaltatore != Guid.Empty);

	Contract.Requires(idCategoriaCommerciale != Guid.Empty);

	Contract.Requires(idDirezioneRegionale != Guid.Empty);

			IdPeriodoProgrammazione = idPeriodoProgrammazione ;
			IdSchedulazione = idSchedulazione ;
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
	     

		public AddSchedulazioneAmbToScenario(Guid id, Guid commitId, long version,Guid idPeriodoProgrammazione,Guid idSchedulazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,Period period,int quantity,string description)
		   : base(id,commitId,version)
		{
			Contract.Requires(idPeriodoProgrammazione != Guid.Empty);

	Contract.Requires(idSchedulazione != Guid.Empty);

	Contract.Requires(idCommittente != Guid.Empty);

	Contract.Requires(idLotto != Guid.Empty);

	Contract.Requires(idImpianto != Guid.Empty);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idAppaltatore != Guid.Empty);

	Contract.Requires(idCategoriaCommerciale != Guid.Empty);

	Contract.Requires(idDirezioneRegionale != Guid.Empty);

			IdPeriodoProgrammazione = idPeriodoProgrammazione ;
			IdSchedulazione = idSchedulazione ;
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

		
		public AddSchedulazioneAmbToScenario(Guid id, Guid commitId, DateTime wakeupTime,Guid idPeriodoProgrammazione,Guid idSchedulazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,Period period,int quantity,string description)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(idPeriodoProgrammazione != Guid.Empty);

	Contract.Requires(idSchedulazione != Guid.Empty);

	Contract.Requires(idCommittente != Guid.Empty);

	Contract.Requires(idLotto != Guid.Empty);

	Contract.Requires(idImpianto != Guid.Empty);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idAppaltatore != Guid.Empty);

	Contract.Requires(idCategoriaCommerciale != Guid.Empty);

	Contract.Requires(idDirezioneRegionale != Guid.Empty);

			IdPeriodoProgrammazione = idPeriodoProgrammazione ;
			IdSchedulazione = idSchedulazione ;
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


		public AddSchedulazioneAmbToScenario(Guid id, Guid commitId, long version, DateTime wakeupTime,Guid idPeriodoProgrammazione,Guid idSchedulazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,Period period,int quantity,string description)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idPeriodoProgrammazione != Guid.Empty);

	Contract.Requires(idSchedulazione != Guid.Empty);

	Contract.Requires(idCommittente != Guid.Empty);

	Contract.Requires(idLotto != Guid.Empty);

	Contract.Requires(idImpianto != Guid.Empty);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idAppaltatore != Guid.Empty);

	Contract.Requires(idCategoriaCommerciale != Guid.Empty);

	Contract.Requires(idDirezioneRegionale != Guid.Empty);

			IdPeriodoProgrammazione = idPeriodoProgrammazione ;
			IdSchedulazione = idSchedulazione ;
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
			return string.Format("Aggiungere una schedulazione ambiente al scenario", Id);
		}
		
		public bool Equals(AddSchedulazioneAmbToScenario other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdPeriodoProgrammazione, IdPeriodoProgrammazione)  	 && Equals(other.IdSchedulazione, IdSchedulazione)  	 && Equals(other.IdCommittente, IdCommittente)  	 && Equals(other.IdLotto, IdLotto)  	 && Equals(other.IdImpianto, IdImpianto)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdAppaltatore, IdAppaltatore)  	 && Equals(other.IdCategoriaCommerciale, IdCategoriaCommerciale)  	 && Equals(other.IdDirezioneRegionale, IdDirezioneRegionale)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.Period, Period)  	 && Equals(other.Quantity, Quantity)  	 && Equals(other.Description, Description) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AddSchedulazioneAmbToScenario);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdPeriodoProgrammazione != null ? IdPeriodoProgrammazione.GetHashCode() : 0);
				result = (result*397) ^ (IdSchedulazione != null ? IdSchedulazione.GetHashCode() : 0);
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

	public class CreateScenario :  CommandBase  
	{
	 
		public string Description { get; set;} 
		public Guid IdProgramma { get; set;}

		public CreateScenario ()
		{
			//for serialisation
		}


		public CreateScenario(Guid id, Guid commitId,string description,Guid idProgramma)
		   : base(id,commitId)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

	Contract.Requires(idProgramma != Guid.Empty);

			Description = description ;
			IdProgramma = idProgramma ;
		}
	     

		public CreateScenario(Guid id, Guid commitId, long version,string description,Guid idProgramma)
		   : base(id,commitId,version)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

	Contract.Requires(idProgramma != Guid.Empty);

			Description = description ;
			IdProgramma = idProgramma ;
		}

		
		public CreateScenario(Guid id, Guid commitId, DateTime wakeupTime,string description,Guid idProgramma)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

	Contract.Requires(idProgramma != Guid.Empty);

			Description = description ;
			IdProgramma = idProgramma ;
		}


		public CreateScenario(Guid id, Guid commitId, long version, DateTime wakeupTime,string description,Guid idProgramma)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

	Contract.Requires(idProgramma != Guid.Empty);

			Description = description ;
			IdProgramma = idProgramma ;
		}
			public override string ToDescription()
		{
			return string.Format("Creare un scenario {0}", Id);
		}
		
		public bool Equals(CreateScenario other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Description, Description)  	 && Equals(other.IdProgramma, IdProgramma) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreateScenario);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
				result = (result*397) ^ (IdProgramma != null ? IdProgramma.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class CancelScenario :  CommandBase  
	{
	

		public CancelScenario ()
		{
			//for serialisation
		}


		public CancelScenario(Guid id, Guid commitId)
		   : base(id,commitId)
		{
				}
	     

		public CancelScenario(Guid id, Guid commitId, long version)
		   : base(id,commitId,version)
		{
				}

		
		public CancelScenario(Guid id, Guid commitId, DateTime wakeupTime)
		   : base(id,commitId,wakeupTime)
		{
				}


		public CancelScenario(Guid id, Guid commitId, long version, DateTime wakeupTime)
		   : base(id,commitId,version,wakeupTime)
		{
				}
			public override string ToDescription()
		{
			return string.Format("Cancellare un scenario {0}", Id);
		}
		
		public bool Equals(CancelScenario other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CancelScenario);
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

	public class ChangeDescriptionScenario :  CommandBase  
	{
	 
		public string Description { get; set;}

		public ChangeDescriptionScenario ()
		{
			//for serialisation
		}


		public ChangeDescriptionScenario(Guid id, Guid commitId,string description)
		   : base(id,commitId)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}
	     

		public ChangeDescriptionScenario(Guid id, Guid commitId, long version,string description)
		   : base(id,commitId,version)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}

		
		public ChangeDescriptionScenario(Guid id, Guid commitId, DateTime wakeupTime,string description)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}


		public ChangeDescriptionScenario(Guid id, Guid commitId, long version, DateTime wakeupTime,string description)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(!string.IsNullOrEmpty(description));

			Description = description ;
		}
			public override string ToDescription()
		{
			return string.Format("Cambiare la descrizione del scenario {0}", Id);
		}
		
		public bool Equals(ChangeDescriptionScenario other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Description, Description) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ChangeDescriptionScenario);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class PromoteScenarioToPlan :  CommandBase  
	{
	 
		public DateTime PromotionDate { get; set;} 
		public Guid IdPlan { get; set;}

		public PromoteScenarioToPlan ()
		{
			//for serialisation
		}


		public PromoteScenarioToPlan(Guid id, Guid commitId,DateTime promotionDate,Guid idPlan)
		   : base(id,commitId)
		{
			Contract.Requires(promotionDate > DateTime.MinValue);

	Contract.Requires(idPlan != Guid.Empty);

			PromotionDate = promotionDate ;
			IdPlan = idPlan ;
		}
	     

		public PromoteScenarioToPlan(Guid id, Guid commitId, long version,DateTime promotionDate,Guid idPlan)
		   : base(id,commitId,version)
		{
			Contract.Requires(promotionDate > DateTime.MinValue);

	Contract.Requires(idPlan != Guid.Empty);

			PromotionDate = promotionDate ;
			IdPlan = idPlan ;
		}

		
		public PromoteScenarioToPlan(Guid id, Guid commitId, DateTime wakeupTime,DateTime promotionDate,Guid idPlan)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(promotionDate > DateTime.MinValue);

	Contract.Requires(idPlan != Guid.Empty);

			PromotionDate = promotionDate ;
			IdPlan = idPlan ;
		}


		public PromoteScenarioToPlan(Guid id, Guid commitId, long version, DateTime wakeupTime,DateTime promotionDate,Guid idPlan)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(promotionDate > DateTime.MinValue);

	Contract.Requires(idPlan != Guid.Empty);

			PromotionDate = promotionDate ;
			IdPlan = idPlan ;
		}
			public override string ToDescription()
		{
			return string.Format("Promuovere il scenario {0} come piano ", Id);
		}
		
		public bool Equals(PromoteScenarioToPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.PromotionDate, PromotionDate)  	 && Equals(other.IdPlan, IdPlan) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as PromoteScenarioToPlan);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (PromotionDate != null ? PromotionDate.GetHashCode() : 0);
				result = (result*397) ^ (IdPlan != null ? IdPlan.GetHashCode() : 0);
				return result;
            }
        }
	}
}
