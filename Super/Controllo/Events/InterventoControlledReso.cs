using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Controllo.Events
{
    public abstract class InterventoControlledReso : Message , IEvent
    {
        
        private readonly Guid _idUser;
        private readonly DateTime _controlDate;
        private readonly WorkPeriod _period;
        private readonly string _note;

        
        public string Note
        {
            get { return _note; }
        }
        public WorkPeriod Period
        {
            get { return _period; }
        }
        public DateTime ControlDate
        {
            get { return _controlDate; }
        }
        public Guid IdUser
        {
            get { return _idUser; }
        }

        //for serialization
        public InterventoControlledReso()
        {
            
        }

        public InterventoControlledReso(Guid id, Guid commitId, long version, Guid idUser, DateTime controlDate, WorkPeriod period, string note)
            :base(id,commitId,version)
        {
            
            Contract.Requires<ArgumentNullException>(idUser != Guid.Empty);
            Contract.Requires<ArgumentOutOfRangeException>(controlDate > DateTime.MinValue);
            Contract.Requires<ArgumentNullException>(period != null);

            
            _idUser = idUser;
            _controlDate = controlDate;
            _period = period;
            _note = note;
            
        }


        public bool Equals(InterventoControlledReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  && other._idUser.Equals(_idUser) && other._controlDate.Equals(_controlDate) && Equals(other._period, _period) && Equals(other._note, _note);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoControlledReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ _idUser.GetHashCode();
                result = (result*397) ^ _controlDate.GetHashCode();
                result = (result*397) ^ (_period != null ? _period.GetHashCode() : 0);
                result = (result*397) ^ (_note != null ? _note.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class InterventoRotControlledReso : InterventoControlledReso
    {

         private readonly OggettoRot[] _oggetti;
        private readonly Treno _trenoArrivo;
        private readonly Treno _trenoPartenza;
        private readonly string _turnoTreno;
        private readonly string _rigaTurnoTreno;
        private readonly string _convoglio;

        public string Convoglio
        {
            get { return _convoglio; }
        }
        public string RigaTurnoTreno
        {
            get { return _rigaTurnoTreno; }
        }
        public string TurnoTreno
        {
            get { return _turnoTreno; }
        }
        public Treno TrenoPartenza
        {
            get { return _trenoPartenza; }
        }
        public Treno TrenoArrivo
        {
            get { return _trenoArrivo; }
        }
        public OggettoRot[] Oggetti
        {
            get { return _oggetti; }
        }

        //for serialization
        public InterventoRotControlledReso()
        {
            
        }

        public InterventoRotControlledReso(Guid id, Guid commitId, long version,
                                        Guid idUser,
                                        DateTime controlDate,
                                        WorkPeriod period,
                                        string note,
                                        OggettoRot[] oggetti, 
                                        Treno trenoArrivo,
                                        Treno trenoPartenza,
                                        string turnoTreno,
                                        string rigaTurnoTreno,
                                        string convoglio) 
            : base(id,commitId,version, idUser, controlDate, period, note)
        {
            Contract.Requires(oggetti != null);

            _oggetti = oggetti;
            _trenoArrivo = trenoArrivo;
            _trenoPartenza = trenoPartenza;
            _turnoTreno = turnoTreno;
            _rigaTurnoTreno = rigaTurnoTreno;
            _convoglio = convoglio;
        }


        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile '{0}' é stato controllato reso.", Id);
        }

        public bool Equals(InterventoRotControlledReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other._oggetti, _oggetti) && Equals(other._trenoArrivo, _trenoArrivo) && Equals(other._trenoPartenza, _trenoPartenza) && Equals(other._turnoTreno, _turnoTreno) && Equals(other._rigaTurnoTreno, _rigaTurnoTreno) && Equals(other._convoglio, _convoglio);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotControlledReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (_oggetti != null ? _oggetti.GetHashCode() : 0);
                result = (result*397) ^ (_trenoArrivo != null ? _trenoArrivo.GetHashCode() : 0);
                result = (result*397) ^ (_trenoPartenza != null ? _trenoPartenza.GetHashCode() : 0);
                result = (result*397) ^ (_turnoTreno != null ? _turnoTreno.GetHashCode() : 0);
                result = (result*397) ^ (_rigaTurnoTreno != null ? _rigaTurnoTreno.GetHashCode() : 0);
                result = (result*397) ^ (_convoglio != null ? _convoglio.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class InterventoRotManControlledReso : InterventoControlledReso
    {
        private readonly OggettoRotMan[] _oggetti;

        public OggettoRotMan[] Oggetti
        {
            get { return _oggetti; }
        }

        //for serialization
        public InterventoRotManControlledReso()
        {
            
        }

        public InterventoRotManControlledReso(Guid id, Guid commitId, long version,
                                        Guid idUser,
                                        DateTime controlDate,
                                        WorkPeriod period,
                                        string note,
                                        OggettoRotMan[] oggetti)
            : base(id,commitId,version, idUser, controlDate, period, note)
        {
            Contract.Requires(oggetti != null);

            _oggetti = oggetti;
        }

        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile in manutenzione '{0}' é stato controllato reso.", Id);
        }

        public bool Equals(InterventoRotManControlledReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other._oggetti, _oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotManControlledReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (_oggetti != null ? _oggetti.GetHashCode() : 0);
            }
        }
    }

    public class InterventoAmbControlledReso : InterventoControlledReso
    {
         private readonly int _quantity;
        private readonly string _description;

        public string Description
        {
            get { return _description; }
        }
        public int Quantity
        {
            get { return _quantity; }
        }

        //for serialization
        public InterventoAmbControlledReso()
        {
            
        }

        public InterventoAmbControlledReso(Guid id, Guid commitId, long version,
                                        Guid idUser,
                                        DateTime controlDate,
                                        WorkPeriod period,
                                        string note, 
                                        int quantity,
                                        string description)
            : base(id,commitId,version, idUser, controlDate, period, note)
        {
            _quantity = quantity;
            _description = description;
        }



        public override string ToDescription()
        {
            return string.Format("Il intervento ambiente '{0}' é stato controllato reso.", Id);
        }

        public bool Equals(InterventoAmbControlledReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._quantity == _quantity && Equals(other._description, _description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoAmbControlledReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ _quantity;
                result = (result*397) ^ (_description != null ? _description.GetHashCode() : 0);
                return result;
            }
        }
    }
	
}
