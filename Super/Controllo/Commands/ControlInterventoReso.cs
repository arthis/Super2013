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
        private readonly Guid _idUtente;
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
        public Guid IdUtente
        {
            get { return _idUtente; }
        }

        public ControlInterventoReso(Guid id, Guid idUtente, DateTime controlDate, WorkPeriod period, string note)
        {
            Contract.Requires<ArgumentNullException>(id == Guid.Empty);
            Contract.Requires<ArgumentNullException>(idUtente == Guid.Empty);
            Contract.Requires<ArgumentOutOfRangeException>(controlDate == DateTime.MinValue);
            Contract.Requires<ArgumentNullException>(period == null);

            Id = id;
            _idUtente = idUtente;
            _controlDate = controlDate;
            _period = period;
            _note = note;
            
        }

        public bool Equals(ControlInterventoReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._idUtente.Equals(_idUtente) && other._controlDate.Equals(_controlDate) && Equals(other._period, _period) && Equals(other._note, _note);
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
                result = (result*397) ^ _idUtente.GetHashCode();
                result = (result*397) ^ _controlDate.GetHashCode();
                result = (result*397) ^ (_period != null ? _period.GetHashCode() : 0);
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

        public ControlInterventoRotReso(Guid id,
                                        Guid idUtente,
                                        DateTime controlDate,
                                        WorkPeriod period,
                                        string note,
                                        OggettoRot[] oggetti, 
                                        Treno trenoArrivo,
                                        Treno trenoPartenza,
                                        string turnoTreno,
                                        string rigaTurnoTreno,
                                        string convoglio) 
            : base(id, idUtente, controlDate, period, note)
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

        public ControlInterventoRotManReso(Guid id,
                                        Guid idUtente,
                                        DateTime controlDate,
                                        WorkPeriod period,
                                        string note,
                                        OggettoRotMan[] oggetti)
            : base(id, idUtente, controlDate, period, note)
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
        private readonly int _quantita;
        private readonly string _descrizione;

        public string Descrizione
        {
            get { return _descrizione; }
        }
        public int Quantita
        {
            get { return _quantita; }
        }

        public ControlInterventoAmbReso(Guid id,
                                        Guid idUtente,
                                        DateTime controlDate,
                                        WorkPeriod period,
                                        string note, 
                                        int quantita,
                                        string descrizione)
            : base(id, idUtente, controlDate, period, note)
        {
            _quantita = quantita;
            _descrizione = descrizione;
        }



        public override string ToDescription()
        {
            return string.Format("si controlla reso il intervento ambiente '{0}' ", Id);
        }

        public bool Equals(ControlInterventoAmbReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._quantita == _quantita && Equals(other._descrizione, _descrizione);
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
                result = (result*397) ^ _quantita;
                result = (result*397) ^ (_descrizione != null ? _descrizione.GetHashCode() : 0);
                return result;
            }
        }
    }


}
