using System;
using System.Diagnostics.Contracts;
using System.Linq;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Controllo.Commands
{

    public abstract class ControlInterventoReso : CommandBase
    {
        private readonly Guid _idUser;
        private readonly DateTime _controlDate;
        private readonly WorkPeriod _workPeriod;
        private readonly string _note;

        public string Note
        {
            get { return _note; }
        }
        public WorkPeriod WorkPeriod
        {
            get { return _workPeriod; }
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
        public ControlInterventoReso()
        {
            
        }

        public ControlInterventoReso(Guid id, Guid commitId, long version, Guid idUser, DateTime controlDate, WorkPeriod workPeriod, string note)
            : base(id, commitId, version)
        {
            Contract.Requires(idUser != Guid.Empty);
            Contract.Requires<ArgumentOutOfRangeException>(controlDate > DateTime.MinValue);
            Contract.Requires(workPeriod != null);

            _idUser = idUser;
            _controlDate = controlDate;
            _workPeriod = workPeriod;
            _note = note;
            
        }

        public bool Equals(ControlInterventoReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._idUser.Equals(_idUser) && other._controlDate.Equals(_controlDate) && Equals(other._workPeriod, _workPeriod) && Equals(other._note, _note);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ControlInterventoReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ _idUser.GetHashCode();
                result = (result*397) ^ _controlDate.GetHashCode();
                result = (result*397) ^ (_workPeriod != null ? _workPeriod.GetHashCode() : 0);
                result = (result*397) ^ (_note != null ? _note.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class ControlInterventoRotReso : ControlInterventoReso
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
        public ControlInterventoRotReso()
        {
            
        }

        public ControlInterventoRotReso(Guid id, Guid commitId, long version,
                                        Guid idUser,
                                        DateTime controlDate,
                                        WorkPeriod workPeriod,
                                        string note,
                                        OggettoRot[] oggetti, 
                                        Treno trenoArrivo,
                                        Treno trenoPartenza,
                                        string turnoTreno,
                                        string rigaTurnoTreno,
                                        string convoglio) 
            : base(id, commitId, version, idUser, controlDate, workPeriod, note)
        {
            _oggetti = oggetti;
            _trenoArrivo = trenoArrivo;
            _trenoPartenza = trenoPartenza;
            _turnoTreno = turnoTreno;
            _rigaTurnoTreno = rigaTurnoTreno;
            _convoglio = convoglio;
        }


        
        public override string ToDescription()
        {
            return string.Format("si controlla reso il intervento rotabile {0}.", Id);
        }

        public bool Equals(ControlInterventoRotReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other._oggetti, _oggetti) && Equals(other._trenoArrivo, _trenoArrivo) && Equals(other._trenoPartenza, _trenoPartenza) && Equals(other._turnoTreno, _turnoTreno) && Equals(other._rigaTurnoTreno, _rigaTurnoTreno) && Equals(other._convoglio, _convoglio);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ControlInterventoRotReso);
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

    public class ControlInterventoRotManReso : ControlInterventoReso
    {
        private readonly OggettoRotMan[] _oggetti;

        public OggettoRotMan[] Oggetti
        {
            get { return _oggetti; }
        }

        //for serialization
        public ControlInterventoRotManReso()
        {
            
        }

        public ControlInterventoRotManReso(Guid id, Guid commitId, long version,
                                        Guid idUser,
                                        DateTime controlDate,
                                        WorkPeriod workPeriod,
                                        string note,
                                        OggettoRotMan[] oggetti)
            : base(id, commitId, version, idUser, controlDate, workPeriod, note)
        {
            _oggetti = oggetti;
        }

        public override string ToDescription()
        {
            return string.Format("si controlla reso il intervento rotabile in manutenzione {0}.", Id);
        }

        public bool Equals(ControlInterventoRotManReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other._oggetti, _oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ControlInterventoRotManReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (_oggetti != null ? _oggetti.GetHashCode() : 0);
            }
        }
    }

    public class ControlInterventoAmbReso : ControlInterventoReso
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
        public ControlInterventoAmbReso()
        {
            
        }

        public ControlInterventoAmbReso(Guid id, Guid commitId, long version,
                                        Guid idUser,
                                        DateTime controlDate,
                                        WorkPeriod workPeriod,
                                        string note, 
                                        int quantity,
                                        string description)
            : base(id, commitId, version, idUser, controlDate, workPeriod, note)
        {
            _quantity = quantity;
            _description = description;
        }



        public override string ToDescription()
        {
            return string.Format("si controlla reso il intervento ambiente '{0}' ", Id);
        }

        public bool Equals(ControlInterventoAmbReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._quantity == _quantity && Equals(other._description, _description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ControlInterventoAmbReso);
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
