﻿using System;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Commands.Lotto
{

    public class UpdateLotto : CommandBase
    {

        public Intervall Intervall { get;  set; }
        public string Description { get;  set; }

        public UpdateLotto()
        {}

        public UpdateLotto(Guid id, Guid commitId, long version,  Intervall period,  string description)
            :base (id,commitId,version)
        {
            
            Contract.Requires<ArgumentNullException>(period != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(description));

            
            Intervall = period;
            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiorniamo il lotto '{0}')", Description);
        }

        public bool Equals(UpdateLotto other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Intervall, Intervall) && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as UpdateLotto);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Intervall != null ? Intervall.GetHashCode() : 0);
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                return result;
            }
        }
    }
}
