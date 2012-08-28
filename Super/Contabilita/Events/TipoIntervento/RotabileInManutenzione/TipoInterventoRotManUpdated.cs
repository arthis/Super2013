﻿using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.TipoIntervento.RotabileInManutenzione
{

    public class TipoInterventoRotManUpdated : Message, IEvent
    {
        public Guid IdMeasuringUnit { get; set; }
        public string Description { get; set; }
        public string Mnemo { get; set; }
        

 
        public TipoInterventoRotManUpdated()
        {
            
        }

        public TipoInterventoRotManUpdated(Guid id, Guid commitId, long version, string mnemo, Guid idMeasuringUnit,  string description)
            : base(id, commitId, version)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(mnemo));
            Contract.Requires<ArgumentNullException>(idMeasuringUnit != Guid.Empty);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(description));

            Mnemo = mnemo;
            IdMeasuringUnit = idMeasuringUnit;
            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Il tipo intervento rotabile in manutenzione é stato aggiornato '{0}')", Description);
        }

        public bool Equals(TipoInterventoRotManUpdated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdMeasuringUnit.Equals(IdMeasuringUnit) && Equals(other.Description, Description) && Equals(other.Mnemo, Mnemo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as TipoInterventoRotManUpdated);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ IdMeasuringUnit.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ (Mnemo != null ? Mnemo.GetHashCode() : 0);
                return result;
            }
        }
    }

    class TipoInterventoRotManUpdatedImpl : TipoInterventoRotManUpdated
    {
    }
}
    