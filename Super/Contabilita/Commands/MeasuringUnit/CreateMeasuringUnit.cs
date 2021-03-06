﻿using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.MeasuringUnit
{
    
    public class CreateMeasuringUnit : CommandBase
    {
        
        public string Description { get;  set; }

        public CreateMeasuringUnit()
        {
            
        }

        public CreateMeasuringUnit(Guid id, Guid commitId, long version,  string description)
            : base(id, commitId, version)
        {
            Contract.Requires(!string.IsNullOrEmpty(description));
           
            this.Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Creiamo l'unità di misura '{0}'.", Description);
        }

        public bool Equals(CreateMeasuringUnit other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description) ;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreateMeasuringUnit);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                return result;
            }
        }
    }
}
