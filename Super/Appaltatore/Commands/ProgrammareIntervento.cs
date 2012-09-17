﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Appaltatore.Commands
{

    public abstract class ProgrammareIntervento : CommandBase
    {

        public string Note { get; set; }
        public WorkPeriod WorkPeriod { get; set; }
        public Guid IdDirezioneRegionale { get; set; }
        public Guid IdCategoriaCommerciale { get; set; }
        public Guid IdAppaltatore { get; set; }
        public Guid IdTipoIntervento { get; set; }
        public Guid IdImpianto { get; set; }

        //for serialization
        public ProgrammareIntervento()
        {}

        public ProgrammareIntervento(Guid id,
                                     Guid commitId,
                                     long version,
                                     Guid idImpianto,
                                     Guid idTipoIntervento,
                                     Guid idAppaltatore,
                                     Guid idCategoriaCommerciale,
                                     Guid idDirezioneRegionale,
                                     WorkPeriod period,
                                     string note)
            : base(id, commitId, version)
        {
            Contract.Requires<ArgumentNullException>(idImpianto != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idTipoIntervento != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idAppaltatore != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idCategoriaCommerciale != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idDirezioneRegionale != Guid.Empty);
            Contract.Requires<ArgumentNullException>(period != null);

            IdImpianto = idImpianto;
            IdTipoIntervento = idTipoIntervento;
            IdAppaltatore = idAppaltatore;
            IdCategoriaCommerciale = idCategoriaCommerciale;
            IdDirezioneRegionale = idDirezioneRegionale;
            WorkPeriod = period;
            Note = note;
        }

        public bool Equals(ProgrammareIntervento other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Note, Note) && Equals(other.WorkPeriod, WorkPeriod) && other.IdDirezioneRegionale.Equals(IdDirezioneRegionale) && other.IdCategoriaCommerciale.Equals(IdCategoriaCommerciale) && other.IdAppaltatore.Equals(IdAppaltatore) && other.IdTipoIntervento.Equals(IdTipoIntervento) && other.IdImpianto.Equals(IdImpianto);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ProgrammareIntervento);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
                result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
                result = (result*397) ^ IdDirezioneRegionale.GetHashCode();
                result = (result*397) ^ IdCategoriaCommerciale.GetHashCode();
                result = (result*397) ^ IdAppaltatore.GetHashCode();
                result = (result*397) ^ IdTipoIntervento.GetHashCode();
                result = (result*397) ^ IdImpianto.GetHashCode();
                return result;
            }
        }
    }

    public class ProgrammareInterventoRot : ProgrammareIntervento
    {
        public string Convoglio { get; set; }
        public string RigaTurnoTreno { get; set; }
        public string TurnoTreno { get; set; }
        public Treno TrenoArrivo { get; set; }
        public Treno TrenoPartenza { get; set; }
        public OggettoRot[] Oggetti { get; set; }

        //for serialization
        public ProgrammareInterventoRot()
        {}

        public ProgrammareInterventoRot(Guid id,
                                     Guid commitId,
                                     long version,
                                     Guid idImpianto,
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
            : base(id, commitId, version, idImpianto, idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, period, note)
        {
            Contract.Requires(oggetti != null);

            Oggetti = oggetti;
            TrenoPartenza = trenoPartenza;
            TrenoArrivo = trenoArrivo;
            TurnoTreno = turnoTreno;
            RigaTurnoTreno = rigaTurnoTreno;
            Convoglio = convoglio;
        }

        public override string ToDescription()
        {
            return string.Format("si programma il intervento rotabile {0}.", Id);
        }

        public bool Equals(ProgrammareInterventoRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Convoglio, Convoglio) && Equals(other.RigaTurnoTreno, RigaTurnoTreno) && Equals(other.TurnoTreno, TurnoTreno) && Equals(other.TrenoArrivo, TrenoArrivo) && Equals(other.TrenoPartenza, TrenoPartenza) &&  Oggetti.SequenceEqual(other.Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ProgrammareInterventoRot);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
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

    public class ProgrammareInterventoRotMan : ProgrammareIntervento, IEquatable<ProgrammareInterventoRotMan>
    {
        public OggettoRotMan[] Oggetti { get; set; }

        //for serialization
        public ProgrammareInterventoRotMan()
        {}

        public ProgrammareInterventoRotMan(Guid id,
                                     Guid commitId,
                                     long version,
                                     Guid idImpianto,
                                     Guid idTipoIntervento,
                                     Guid idAppaltatore,
                                     Guid idCategoriaCommerciale,
                                     Guid idDirezioneRegionale,
                                     WorkPeriod period,
                                     string note,
                                     OggettoRotMan[] oggetti)
            : base(id, commitId, version, idImpianto, idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, period, note)
        {
            Contract.Requires(oggetti != null);

            Oggetti = oggetti;
        }


        public override string ToDescription()
        {
            return string.Format("si programma il intervento rotabile in manutenzione {0}.", Id);
        }

        public bool Equals(ProgrammareInterventoRotMan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) &&  other.Oggetti.SequenceEqual(Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ProgrammareInterventoRotMan);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
            }
        }
    }

    public class ProgrammareInterventoAmb : ProgrammareIntervento, IEquatable<ProgrammareInterventoAmb>
    {
        public string Description { get; set; }
        public int Quantity { get; set; }


        //for serialization
        public ProgrammareInterventoAmb()
        {}

        public ProgrammareInterventoAmb(Guid id,
                                     Guid commitId,
                                     long version,
                                     Guid idImpianto,
                                     Guid idTipoIntervento,
                                     Guid idAppaltatore,
                                     Guid idCategoriaCommerciale,
                                     Guid idDirezioneRegionale,
                                     WorkPeriod period,
                                     string note,
                                     int quantity,
                                     string description)
            : base(id, commitId, version, idImpianto, idTipoIntervento, idAppaltatore, idCategoriaCommerciale, idDirezioneRegionale, period, note)
        {
            Contract.Requires<ArgumentOutOfRangeException>(quantity >= 0);

            Quantity = quantity;
            Description = description;
        }


        public override string ToDescription()
        {
            return string.Format("si programma il intervento ambiente {0}.", Id);
        }

        public bool Equals(ProgrammareInterventoAmb other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description) && other.Quantity == Quantity;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ProgrammareInterventoAmb);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ Quantity;
                return result;
            }
        }
    }
}
