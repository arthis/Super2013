using System;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Appaltatore.Events.Programmazione
{
    public abstract class InterventoProgrammato : Message, IEvent
    {
        private readonly Guid _id;
        private readonly Guid _idAreaIntervento;
        private readonly Guid _idTipoIntervento;
        private readonly Guid _idAppaltatore;
        private readonly Guid _idCategoriaCommerciale;
        private readonly Guid _idDirezioneRegionale;
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
        public Guid IdDirezioneRegionale
        {
            get { return _idDirezioneRegionale; }
        }
        public Guid IdCategoriaCommerciale
        {
            get { return _idCategoriaCommerciale; }
        }
        public Guid IdAppaltatore
        {
            get { return _idAppaltatore; }
        }
        public Guid IdTipoIntervento
        {
            get { return _idTipoIntervento; }
        }
        public Guid IdAreaIntervento
        {
            get { return _idAreaIntervento; }
        }
        public Guid Id
        {
            get { return _id; }
        }

        public InterventoProgrammato(Guid id,
                                     Guid idAreaIntervento,
                                     Guid idTipoIntervento,
                                     Guid idAppaltatore,
                                     Guid idCategoriaCommerciale,
                                     Guid idDirezioneRegionale,
                                     WorkPeriod period,
                                     string note)
        {
            _id = id;
            _idAreaIntervento = idAreaIntervento;
            _idTipoIntervento = idTipoIntervento;
            _idAppaltatore = idAppaltatore;
            _idCategoriaCommerciale = idCategoriaCommerciale;
            _idDirezioneRegionale = idDirezioneRegionale;
            _period = period;
            _note = note;
        }


        public bool Equals(InterventoProgrammato other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._id.Equals(_id) && other._idAreaIntervento.Equals(_idAreaIntervento) && other._idTipoIntervento.Equals(_idTipoIntervento) && other._idAppaltatore.Equals(_idAppaltatore) && other._idCategoriaCommerciale.Equals(_idCategoriaCommerciale) && other._idDirezioneRegionale.Equals(_idDirezioneRegionale) && Equals(other._period, _period) && Equals(other._note, _note);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoProgrammato);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ _id.GetHashCode();
                result = (result*397) ^ _idAreaIntervento.GetHashCode();
                result = (result*397) ^ _idTipoIntervento.GetHashCode();
                result = (result*397) ^ _idAppaltatore.GetHashCode();
                result = (result*397) ^ _idCategoriaCommerciale.GetHashCode();
                result = (result*397) ^ _idDirezioneRegionale.GetHashCode();
                result = (result*397) ^ (_period != null ? _period.GetHashCode() : 0);
                result = (result*397) ^ (_note != null ? _note.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class InterventoRotProgrammato : InterventoProgrammato
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
        
        public InterventoRotProgrammato(Guid id,
                                     Guid idAreaIntervento,
                                     Guid idTipoIntervento,
                                     Guid idAppaltatore,
                                     Guid idCategoriaCommerciale,
                                     Guid idDirezioneRegionale,
                                     WorkPeriod period,
                                     string note,
                OggettoRot[] oggetti,
            Treno trenoPartenza,
            Treno trenoArrivo,
            string turnoTreno,
            string rigaTurnoTreno,
            string convoglio
            )
            : base(id, idAreaIntervento, idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, period, note)
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
            return string.Format("Il intervento rotabile '{0}' é stato programmato.", Id);
        }

        public bool Equals(InterventoRotProgrammato other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other._oggetti, _oggetti) && Equals(other._trenoPartenza, _trenoPartenza) && Equals(other._trenoArrivo, _trenoArrivo) && Equals(other._turnoTreno, _turnoTreno) && Equals(other._rigaTurnoTreno, _rigaTurnoTreno) && Equals(other._convoglio, _convoglio);
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

    public class InterventoRotManProgrammato : InterventoProgrammato
    {
        private readonly OggettoRotMan[] _oggetti;

        public OggettoRotMan[] Oggetti { get { return _oggetti; } }

        public InterventoRotManProgrammato(Guid id,
                                     Guid idAreaIntervento,
                                     Guid idTipoIntervento,
                                     Guid idAppaltatore,
                                     Guid idCategoriaCommerciale,
                                     Guid idDirezioneRegionale,
                                     WorkPeriod period,
                                     string note,
                                     OggettoRotMan[] oggetti)
            : base(id, idAreaIntervento, idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, period, note)
        {
            _oggetti = oggetti;
        }

        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile in manutenzione '{0}' é stato programmato.", Id);
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotManProgrammato);
        }

        public bool Equals(InterventoRotManProgrammato other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other._oggetti, _oggetti);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (_oggetti != null ? _oggetti.GetHashCode() : 0);
            }
        }
    }

    public class InterventoAmbProgrammato : InterventoProgrammato
    {
        private readonly int _quantita;
        private readonly string _description;

        public InterventoAmbProgrammato(Guid id,
                                     Guid idAreaIntervento,
                                     Guid idTipoIntervento,
                                     Guid idAppaltatore,
                                     Guid idCategoriaCommerciale,
                                     Guid idDirezioneRegionale,
                                     WorkPeriod period,
                                     string note,
                                     int quantita,
                                     string description)
            : base(id, idAreaIntervento, idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, period, note)
        {
            _quantita = quantita;
            _description = description;
        }

        public string Description
        {
            get { return _description; }
        }

        public int Quantita
        {
            get { return _quantita; }
        }

        public override string ToDescription()
        {
            return string.Format("Il intervento ambiente '{0}' é stato programmato.", Id);
        }

        public bool Equals(InterventoAmbProgrammato other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._quantita == _quantita && Equals(other._description, _description);
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
                result = (result*397) ^ _quantita;
                result = (result*397) ^ (_description != null ? _description.GetHashCode() : 0);
                return result;
            }
        }
    }
}