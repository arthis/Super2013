



using System;
using System.Linq;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain;
using CommonDomain.Core;


namespace Super.Appaltatore.Commands.Consuntivazione
{


	public class ConsuntivareAutomaticamenteNonReso :  CommandBase  
	{
	

		public ConsuntivareAutomaticamenteNonReso ()
		{
			//for serialisation
		}	     

		public ConsuntivareAutomaticamenteNonReso(Guid id, Guid commitId, long version)
		   : base(id,commitId,version)
		{
				}

		public ConsuntivareAutomaticamenteNonReso(Guid id, Guid commitId, long version, DateTime wakeupTime)
		   : base(id,commitId,version,wakeupTime)
		{
				}
			public override string ToDescription()
		{
			return string.Format("il intervento é stato  consuntivato non reso appaltatore automaticamente", Id);
		}
		
		public bool Equals(ConsuntivareAutomaticamenteNonReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareAutomaticamenteNonReso);
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

	public class ConsuntivareNonReso :  CommandBase  
	{
	 
		public string Note { get; set;} 
		public Guid IdCausaleAppaltatore { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;}

		public ConsuntivareNonReso ()
		{
			//for serialisation
		}	     

		public ConsuntivareNonReso(Guid id, Guid commitId, long version,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,version)
		{
			Contract.Requires(idCausaleAppaltatore != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleAppaltatore = idCausaleAppaltatore ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}

		public ConsuntivareNonReso(Guid id, Guid commitId, long version, DateTime wakeupTime,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idCausaleAppaltatore != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleAppaltatore = idCausaleAppaltatore ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}
			public override string ToDescription()
		{
			return string.Format("il intervento é stato  consuntivato non reso appaltatore", Id);
		}
		
		public bool Equals(ConsuntivareNonReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.IdCausaleAppaltatore, IdCausaleAppaltatore)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareNonReso);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
				result = (result*397) ^ (IdCausaleAppaltatore != null ? IdCausaleAppaltatore.GetHashCode() : 0);
				result = (result*397) ^ (DataConsuntivazione != null ? DataConsuntivazione.GetHashCode() : 0);
				result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class ConsuntivareNonResoTrenitalia :  CommandBase  
	{
	 
		public string Note { get; set;} 
		public Guid IdCausaleTrenitalia { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;}

		public ConsuntivareNonResoTrenitalia ()
		{
			//for serialisation
		}	     

		public ConsuntivareNonResoTrenitalia(Guid id, Guid commitId, long version,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,version)
		{
			Contract.Requires(idCausaleTrenitalia != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleTrenitalia = idCausaleTrenitalia ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}

		public ConsuntivareNonResoTrenitalia(Guid id, Guid commitId, long version, DateTime wakeupTime,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idCausaleTrenitalia != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleTrenitalia = idCausaleTrenitalia ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}
			public override string ToDescription()
		{
			return string.Format("il intervento é stato  consuntivato non reso trenitalia", Id);
		}
		
		public bool Equals(ConsuntivareNonResoTrenitalia other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.IdCausaleTrenitalia, IdCausaleTrenitalia)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareNonResoTrenitalia);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
				result = (result*397) ^ (IdCausaleTrenitalia != null ? IdCausaleTrenitalia.GetHashCode() : 0);
				result = (result*397) ^ (DataConsuntivazione != null ? DataConsuntivazione.GetHashCode() : 0);
				result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class ConsuntivareResoRot :  CommandBase  
	{
	 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;} 
		public string Convoglio { get; set;} 
		public string RigaTurnoTreno { get; set;} 
		public string TurnoTreno { get; set;} 
		public Treno TrenoArrivo { get; set;} 
		public Treno TrenoPartenza { get; set;} 
		public OggettoRot[] Oggetti { get; set;}

		public ConsuntivareResoRot ()
		{
			//for serialisation
		}	     

		public ConsuntivareResoRot(Guid id, Guid commitId, long version,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,string convoglio,string rigaTurnoTreno,string turnoTreno,Treno trenoArrivo,Treno trenoPartenza,OggettoRot[] oggetti)
		   : base(id,commitId,version)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Convoglio = convoglio ;
			RigaTurnoTreno = rigaTurnoTreno ;
			TurnoTreno = turnoTreno ;
			TrenoArrivo = trenoArrivo ;
			TrenoPartenza = trenoPartenza ;
			Oggetti = oggetti ;
		}

		public ConsuntivareResoRot(Guid id, Guid commitId, long version, DateTime wakeupTime,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,string convoglio,string rigaTurnoTreno,string turnoTreno,Treno trenoArrivo,Treno trenoPartenza,OggettoRot[] oggetti)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Convoglio = convoglio ;
			RigaTurnoTreno = rigaTurnoTreno ;
			TurnoTreno = turnoTreno ;
			TrenoArrivo = trenoArrivo ;
			TrenoPartenza = trenoPartenza ;
			Oggetti = oggetti ;
		}
			public override string ToDescription()
		{
			return string.Format("il intervento rotabile é stato  consuntivato reso", Id);
		}
		
		public bool Equals(ConsuntivareResoRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore)  	 && Equals(other.Convoglio, Convoglio)  	 && Equals(other.RigaTurnoTreno, RigaTurnoTreno)  	 && Equals(other.TurnoTreno, TurnoTreno)  	 && Equals(other.TrenoArrivo, TrenoArrivo)  	 && Equals(other.TrenoPartenza, TrenoPartenza)  	 && other.Oggetti.SequenceEqual(Oggetti) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareResoRot);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				result = (result*397) ^ (DataConsuntivazione != null ? DataConsuntivazione.GetHashCode() : 0);
				result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
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

	public class ConsuntivareResoRotMan :  CommandBase  
	{
	 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;} 
		public OggettoRotMan[] Oggetti { get; set;}

		public ConsuntivareResoRotMan ()
		{
			//for serialisation
		}	     

		public ConsuntivareResoRotMan(Guid id, Guid commitId, long version,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,OggettoRotMan[] oggetti)
		   : base(id,commitId,version)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Oggetti = oggetti ;
		}

		public ConsuntivareResoRotMan(Guid id, Guid commitId, long version, DateTime wakeupTime,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,OggettoRotMan[] oggetti)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Oggetti = oggetti ;
		}
			public override string ToDescription()
		{
			return string.Format("il intervento rotabile in manutenzione é stato  consuntivato reso", Id);
		}
		
		public bool Equals(ConsuntivareResoRotMan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore)  	 && other.Oggetti.SequenceEqual(Oggetti) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareResoRotMan);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				result = (result*397) ^ (DataConsuntivazione != null ? DataConsuntivazione.GetHashCode() : 0);
				result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
				result = (result*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class ConsuntivareResoAmb :  CommandBase  
	{
	 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;} 
		public string Description { get; set;} 
		public int Quantity { get; set;}

		public ConsuntivareResoAmb ()
		{
			//for serialisation
		}	     

		public ConsuntivareResoAmb(Guid id, Guid commitId, long version,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,string description,int quantity)
		   : base(id,commitId,version)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(quantity != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Description = description ;
			Quantity = quantity ;
		}

		public ConsuntivareResoAmb(Guid id, Guid commitId, long version, DateTime wakeupTime,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,string description,int quantity)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(quantity != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Description = description ;
			Quantity = quantity ;
		}
			public override string ToDescription()
		{
			return string.Format("il intervento rotabile in manutenzione é stato  consuntivato reso", Id);
		}
		
		public bool Equals(ConsuntivareResoAmb other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore)  	 && Equals(other.Description, Description)  	 && Equals(other.Quantity, Quantity) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareResoAmb);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				result = (result*397) ^ (DataConsuntivazione != null ? DataConsuntivazione.GetHashCode() : 0);
				result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
				result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
				result = (result*397) ^ (Quantity != null ? Quantity.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class ProgramInterventoRot :  CommandBase  
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

		public ProgramInterventoRot ()
		{
			//for serialisation
		}	     

		public ProgramInterventoRot(Guid id, Guid commitId, long version,Guid idProgramma,Guid idPeriodoProgrammazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,string convoglio,string rigaTurnoTreno,string turnoTreno,Treno trenoArrivo,Treno trenoPartenza,OggettoRot[] oggetti)
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

		public ProgramInterventoRot(Guid id, Guid commitId, long version, DateTime wakeupTime,Guid idProgramma,Guid idPeriodoProgrammazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,string convoglio,string rigaTurnoTreno,string turnoTreno,Treno trenoArrivo,Treno trenoPartenza,OggettoRot[] oggetti)
		   : base(id,commitId,version,wakeupTime)
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
			return string.Format("Programmare un intervento rotabile", Id);
		}
		
		public bool Equals(ProgramInterventoRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdProgramma, IdProgramma)  	 && Equals(other.IdPeriodoProgrammazione, IdPeriodoProgrammazione)  	 && Equals(other.IdCommittente, IdCommittente)  	 && Equals(other.IdLotto, IdLotto)  	 && Equals(other.IdImpianto, IdImpianto)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdAppaltatore, IdAppaltatore)  	 && Equals(other.IdCategoriaCommerciale, IdCategoriaCommerciale)  	 && Equals(other.IdDirezioneRegionale, IdDirezioneRegionale)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.Convoglio, Convoglio)  	 && Equals(other.RigaTurnoTreno, RigaTurnoTreno)  	 && Equals(other.TurnoTreno, TurnoTreno)  	 && Equals(other.TrenoArrivo, TrenoArrivo)  	 && Equals(other.TrenoPartenza, TrenoPartenza)  	 && other.Oggetti.SequenceEqual(Oggetti) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ProgramInterventoRot);
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

	public class ProgramInterventoRotMan :  CommandBase  
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

		public ProgramInterventoRotMan ()
		{
			//for serialisation
		}	     

		public ProgramInterventoRotMan(Guid id, Guid commitId, long version,Guid idProgramma,Guid idPeriodoProgrammazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,OggettoRotMan[] oggetti)
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

		public ProgramInterventoRotMan(Guid id, Guid commitId, long version, DateTime wakeupTime,Guid idProgramma,Guid idPeriodoProgrammazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,OggettoRotMan[] oggetti)
		   : base(id,commitId,version,wakeupTime)
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
			return string.Format("Programmare un intervento rotabile", Id);
		}
		
		public bool Equals(ProgramInterventoRotMan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdProgramma, IdProgramma)  	 && Equals(other.IdPeriodoProgrammazione, IdPeriodoProgrammazione)  	 && Equals(other.IdCommittente, IdCommittente)  	 && Equals(other.IdLotto, IdLotto)  	 && Equals(other.IdImpianto, IdImpianto)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdAppaltatore, IdAppaltatore)  	 && Equals(other.IdCategoriaCommerciale, IdCategoriaCommerciale)  	 && Equals(other.IdDirezioneRegionale, IdDirezioneRegionale)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && other.Oggetti.SequenceEqual(Oggetti) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ProgramInterventoRotMan);
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
				result = (result*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class ProgramInterventoAmb :  CommandBase  
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

		public ProgramInterventoAmb ()
		{
			//for serialisation
		}	     

		public ProgramInterventoAmb(Guid id, Guid commitId, long version,Guid idProgramma,Guid idPeriodoProgrammazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,int quantity,string description)
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

		public ProgramInterventoAmb(Guid id, Guid commitId, long version, DateTime wakeupTime,Guid idProgramma,Guid idPeriodoProgrammazione,Guid idCommittente,Guid idLotto,Guid idImpianto,Guid idTipoIntervento,Guid idAppaltatore,Guid idCategoriaCommerciale,Guid idDirezioneRegionale,string note,WorkPeriod workPeriod,int quantity,string description)
		   : base(id,commitId,version,wakeupTime)
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
			return string.Format("Programmare una intervento ambiente", Id);
		}
		
		public bool Equals(ProgramInterventoAmb other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdProgramma, IdProgramma)  	 && Equals(other.IdPeriodoProgrammazione, IdPeriodoProgrammazione)  	 && Equals(other.IdCommittente, IdCommittente)  	 && Equals(other.IdLotto, IdLotto)  	 && Equals(other.IdImpianto, IdImpianto)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdAppaltatore, IdAppaltatore)  	 && Equals(other.IdCategoriaCommerciale, IdCategoriaCommerciale)  	 && Equals(other.IdDirezioneRegionale, IdDirezioneRegionale)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.Quantity, Quantity)  	 && Equals(other.Description, Description) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ProgramInterventoAmb);
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
				result = (result*397) ^ (Quantity != null ? Quantity.GetHashCode() : 0);
				result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
				return result;
            }
        }
	}
}
