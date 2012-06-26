﻿using System;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Commands.Lotto
{
    
    public class CreateLotto : CommandBase
    {
        public Intervall Period { get; private set; }
        public string Description { get; private set; }
        public DateTime CreationDate { get; private set; }

        public CreateLotto()
        {
            
        }

        public CreateLotto(Guid id,  Intervall period, DateTime creationDate, string description)
        {
            this.Id = id;
            this.Period = period;
            this.Description = description;
            this.CreationDate = creationDate;
        }

        public override string ToDescription()
        {
            return string.Format("Creiamo il lotto '{0}'.", Description);
        }

        public bool Equals(CreateLotto other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Period, Period) && Equals(other.Description, Description) && other.CreationDate.Equals(CreationDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreateLotto);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Period != null ? Period.GetHashCode() : 0);
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ CreationDate.GetHashCode();
                return result;
            }
        }
    }
}
