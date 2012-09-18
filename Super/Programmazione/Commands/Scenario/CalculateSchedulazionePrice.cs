using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Scenario
{
    public class CalculateSchedulazionePrice : CommandBase
    {
        
        public CalculateSchedulazionePrice()
        {
            
        }

        public CalculateSchedulazionePrice(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Calcolare il prezzo della schedulazione {0} con i dati di contabilita", Id);
        }

        public bool Equals(CancelScenario other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CancelScenario);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
