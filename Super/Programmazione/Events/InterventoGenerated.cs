using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Programmazione.Events
{
    public abstract class InterventoGenerated : Message, IInterventoGenerated
    {
        
        public Guid IdImpianto { get; set; }
        public Guid IdTipoIntervento { get; set; }
        public Guid IdAppaltatore { get; set; }
        public Guid IdCategoriaCommerciale { get; set; }
        public Guid IdDirezioneRegionale { get; set; }
        public WorkPeriod Period { get; set; }
        public string Note { get; set; }

        public InterventoGenerated()
        {
            
        }

        public InterventoGenerated(Guid id,
                                   Guid commitId,
                                   long version,
                                   Guid idImpianto,
                                   Guid idTipoIntervento,
                                   Guid idAppaltatore,
                                   Guid idCategoriaCommerciale,
                                   Guid idDirezioneRegionale,
                                   WorkPeriod period,
                                   string note)
            : base(id,commitId,  version)
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
            Period = period;
            Note = note;
        }



        public bool Equals(InterventoGenerated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Id.Equals(Id) && other.IdImpianto.Equals(IdImpianto) && other.IdTipoIntervento.Equals(IdTipoIntervento) && other.IdAppaltatore.Equals(IdAppaltatore) && other.IdCategoriaCommerciale.Equals(IdCategoriaCommerciale) && other.IdDirezioneRegionale.Equals(IdDirezioneRegionale) && Equals(other.Period, Period) && Equals(other.Note, Note);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoGenerated);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ Id.GetHashCode();
                result = (result*397) ^ IdImpianto.GetHashCode();
                result = (result*397) ^ IdTipoIntervento.GetHashCode();
                result = (result*397) ^ IdAppaltatore.GetHashCode();
                result = (result*397) ^ IdCategoriaCommerciale.GetHashCode();
                result = (result*397) ^ IdDirezioneRegionale.GetHashCode();
                result = (result*397) ^ (Period != null ? Period.GetHashCode() : 0);
                result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
                return result;
            }
        }
    }
}