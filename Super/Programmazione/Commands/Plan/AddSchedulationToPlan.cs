using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Programmazione.Commands.Plan
{
    public class AddSchedulationToPlan : CommandBase
    {

        public Guid IdUser { get; set; }
        public string Note { get; set; }
        public Guid IdImpianto { get; set; }
        public Guid IdTipoIntervento { get; set; }
        public Guid IdAppaltatore { get; set; }
        public Guid IdCategoriaCommerciale { get; set; }
        public Guid IdDirezioneRegionale { get; set; }
        public WorkPeriod Period { get; set; }

        public AddSchedulationToPlan()
        {
            
        }

        public AddSchedulationToPlan(Guid id,
                                   Guid commitId,
                                   long version,
                                   Guid idImpianto,
                                   Guid idTipoIntervento,
                                   Guid idAppaltatore,
                                   Guid idCategoriaCommerciale,
                                   Guid idDirezioneRegionale,
                                   WorkPeriod period,
                                   string note,
                                   Guid idUser)
            : base(id, commitId, version)
        {
            Contract.Requires<ArgumentNullException>(idImpianto != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idTipoIntervento != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idAppaltatore != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idCategoriaCommerciale != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idDirezioneRegionale != Guid.Empty);
            Contract.Requires<ArgumentNullException>(period != null);
            Contract.Requires<ArgumentNullException>(idUser != Guid.Empty);

            IdImpianto = idImpianto;
            IdTipoIntervento = idTipoIntervento;
            IdAppaltatore = idAppaltatore;
            IdCategoriaCommerciale = idCategoriaCommerciale;
            IdDirezioneRegionale = idDirezioneRegionale;
            Period = period;
            Note = note;
            IdUser = idUser;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiungere una schedulazione {0}  al scenario ", Id);
        }

        public bool Equals(AddSchedulationToPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdUser.Equals(IdUser) && Equals(other.Note, Note) && other.IdImpianto.Equals(IdImpianto) && other.IdTipoIntervento.Equals(IdTipoIntervento) && other.IdAppaltatore.Equals(IdAppaltatore) && other.IdCategoriaCommerciale.Equals(IdCategoriaCommerciale) && other.IdDirezioneRegionale.Equals(IdDirezioneRegionale) && Equals(other.Period, Period);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AddSchedulationToPlan);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ IdUser.GetHashCode();
                result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
                result = (result*397) ^ IdImpianto.GetHashCode();
                result = (result*397) ^ IdTipoIntervento.GetHashCode();
                result = (result*397) ^ IdAppaltatore.GetHashCode();
                result = (result*397) ^ IdCategoriaCommerciale.GetHashCode();
                result = (result*397) ^ IdDirezioneRegionale.GetHashCode();
                result = (result*397) ^ (Period != null ? Period.GetHashCode() : 0);
                return result;
            }
        }
    }
}
