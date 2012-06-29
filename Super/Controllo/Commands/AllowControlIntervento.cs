﻿using System;
using System.Diagnostics.Contracts;
using System.Linq;
using CommandService;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Controllo.Commands
{

    public class AllowControlIntervento : CommandBase
    {
        //for serialization
        public AllowControlIntervento()
        {
            
        }
        
        public AllowControlIntervento(Guid id)
        {
            Contract.Requires<ArgumentNullException>(id == Guid.Empty);

            Id = id;
        }


        public override string ToDescription()
        {
            return string.Format("si permette il controllo dell'intervento {0}.", Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AllowControlIntervento);
        }

        public bool Equals(AllowControlIntervento other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result * 397) ^ Id.GetHashCode();
                return result;
            }
        }
    }

    
}
