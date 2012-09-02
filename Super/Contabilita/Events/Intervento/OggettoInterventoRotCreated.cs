using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.Intervento
{
    public class OggettoInterventoRotCreated : Message,IEvent
    {
        public Guid IdIntervento { get; set; }
        public Guid IdTipoOggettoIntervento { get; set; }
        public Guid IdGruppoOggettoIntervento { get; set; }
        public string Description { get; set; }

        public override string ToDescription()
        {
            return string.Format("l'oggetto intervento rotabile é stato creato");
        }

        public OggettoInterventoRotCreated(Guid id,
                                          Guid commitId,
                                          long version,
            Guid idIntervento, Guid idTipoOggettoIntervento, Guid idGruppoOggettoIntervento, string description)
            : base(id,commitId,  version)
        {
            Contract.Requires(idIntervento!= Guid.Empty);
            Contract.Requires(idTipoOggettoIntervento != Guid.Empty);
            Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

            IdIntervento = idIntervento;
            IdTipoOggettoIntervento = idTipoOggettoIntervento;
            IdGruppoOggettoIntervento = idGruppoOggettoIntervento;
            Description = description;
        }

        public bool Equals(OggettoInterventoRotCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdIntervento.Equals(IdIntervento) && other.IdTipoOggettoIntervento.Equals(IdTipoOggettoIntervento) && other.IdGruppoOggettoIntervento.Equals(IdGruppoOggettoIntervento) && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as OggettoInterventoRotCreated);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ IdIntervento.GetHashCode();
                result = (result*397) ^ IdTipoOggettoIntervento.GetHashCode();
                result = (result*397) ^ IdGruppoOggettoIntervento.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                return result;
            }
        }
    }
}
