using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Appaltatore.Events.Consuntivazione
{
    public abstract class InterventoConsuntivatoReso : Message, IEvent
    {
        private Guid _id;
        private readonly string _idInterventoAppaltatore;
        private readonly DateTime _dataConsuntivazione;
        private readonly WorkPeriod _period;
        private readonly string _note;

        public Guid Id
        {
            get { return _id; }
        }
        public string Note
        {
            get { return _note; }
        }
        public WorkPeriod Period
        {
            get { return _period; }
        }
        public string IdInterventoAppaltatore
        {
            get { return _idInterventoAppaltatore; }
        }
        public DateTime DataConsuntivazione
        {
            get { return _dataConsuntivazione; }
        }

        //for serialization
        public InterventoConsuntivatoReso()
        {
            
        }

        public InterventoConsuntivatoReso(Guid id,
                                     string idInterventoAppaltatore,
                                     DateTime dataConsuntivazione,
                                     WorkPeriod period,
                                     string note)
        {
            Contract.Requires<ArgumentNullException>(id == Guid.Empty);
            Contract.Requires<ArgumentNullException>(string.IsNullOrEmpty(idInterventoAppaltatore));
            Contract.Requires<ArgumentNullException>(dataConsuntivazione == DateTime.MinValue);
            Contract.Requires<ArgumentNullException>(period == null);

            _id = id;
            _idInterventoAppaltatore = idInterventoAppaltatore;
            _dataConsuntivazione = dataConsuntivazione;
            _period = period;
            _note = note;
        }

        public bool Equals(InterventoConsuntivatoReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._id.Equals(_id) && Equals(other._idInterventoAppaltatore, _idInterventoAppaltatore) && other._dataConsuntivazione.Equals(_dataConsuntivazione) && Equals(other._period, _period) && Equals(other._note, _note);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoConsuntivatoReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ _id.GetHashCode();
                result = (result*397) ^ (_idInterventoAppaltatore != null ? _idInterventoAppaltatore.GetHashCode() : 0);
                result = (result*397) ^ _dataConsuntivazione.GetHashCode();
                result = (result*397) ^ (_period != null ? _period.GetHashCode() : 0);
                result = (result*397) ^ (_note != null ? _note.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class InterventoConsuntivatoRotReso : InterventoConsuntivatoReso, IInterventoRotConsuntivato
    {
        private readonly OggettoRot[] _oggetti;
        private readonly Treno _trenoPartenza;
        private readonly Treno _trenoArrivo;
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
        public Treno TrenoArrivo
        {
            get { return _trenoArrivo; }
        }
        public Treno TrenoPartenza
        {
            get { return _trenoPartenza; }
        }
        public OggettoRot[] Oggetti
        {
            get { return _oggetti; }
        }


        //for serialization
        public InterventoConsuntivatoRotReso()
        {
            
        }

        public InterventoConsuntivatoRotReso(Guid id, string idInterventoAppaltatore, DateTime dataConsuntivazione, WorkPeriod period, string note, 
                OggettoRot[] oggetti, Treno trenoPartenza, Treno trenoArrivo, string turnoTreno, string rigaTurnoTreno, string convoglio) 
            : base(id, idInterventoAppaltatore, dataConsuntivazione, period, note)
        {
            _oggetti = oggetti;
            _trenoPartenza = trenoPartenza;
            _trenoArrivo = trenoArrivo;
            _turnoTreno = turnoTreno;
            _rigaTurnoTreno = rigaTurnoTreno;
            _convoglio = convoglio;
        }
        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile '{0}' é stato consuntivato reso.", Id);
        }

        public bool Equals(InterventoConsuntivatoRotReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other._oggetti, _oggetti) && Equals(other._trenoPartenza, _trenoPartenza) && Equals(other._trenoArrivo, _trenoArrivo) && Equals(other._turnoTreno, _turnoTreno) && Equals(other._rigaTurnoTreno, _rigaTurnoTreno) && Equals(other._convoglio, _convoglio);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoConsuntivatoRotReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (_oggetti != null ? _oggetti.GetHashCode() : 0);
                result = (result*397) ^ (_trenoPartenza != null ? _trenoPartenza.GetHashCode() : 0);
                result = (result*397) ^ (_trenoArrivo != null ? _trenoArrivo.GetHashCode() : 0);
                result = (result*397) ^ (_turnoTreno != null ? _turnoTreno.GetHashCode() : 0);
                result = (result*397) ^ (_rigaTurnoTreno != null ? _rigaTurnoTreno.GetHashCode() : 0);
                result = (result*397) ^ (_convoglio != null ? _convoglio.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class InterventoConsuntivatoRotManReso : InterventoConsuntivatoReso, IInterventoRotManConsuntivato
    {
         private readonly OggettoRotMan[] _oggetti;


        public OggettoRotMan[] Oggetti
        {
            get { return _oggetti; }
        }

        //for serialization
        public InterventoConsuntivatoRotManReso()
        {
            
        }

        public InterventoConsuntivatoRotManReso(Guid id, string idInterventoAppaltatore, DateTime dataConsuntivazione, WorkPeriod period, string note, OggettoRotMan[] oggetti)
            : base(id, idInterventoAppaltatore, dataConsuntivazione, period, note)
        {
            _oggetti = oggetti;
        }


        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile in manutenzione '{0}' é stato consuntivato reso.", Id);
        }

        public bool Equals(InterventoConsuntivatoRotManReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Oggetti, Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoConsuntivatoRotManReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
            }
        }
    }

    public class InterventoConsuntivatoAmbReso : InterventoConsuntivatoReso, IInterventoAmbConsuntivato
    {
        private readonly int _quantity;
        private readonly string _description;

        //for serialization
        public InterventoConsuntivatoAmbReso()
        {
            
        }

        public InterventoConsuntivatoAmbReso(Guid id,
                                            string idInterventoAppaltatore,
                                            DateTime dataConsuntivazione,
                                            WorkPeriod period,
                                            string note,
                                            int quantity,
                                            string description)
            : base(id, idInterventoAppaltatore, dataConsuntivazione, period, note)
        {
            Contract.Requires<ArgumentOutOfRangeException>(quantity <= 0);

            _quantity = quantity;
            _description = description;
        }


        public string Description
        {
            get { return _description; }
        }
        public int Quantity
        {
            get { return _quantity; }
        }

        public override string ToDescription()
        {
            return string.Format("Il intervento ambiente '{0}' é stato consuntivato reso.", Id);
        }

        public bool Equals(InterventoConsuntivatoAmbReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._quantity == _quantity && Equals(other._description, _description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoConsuntivatoAmbReso);
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
