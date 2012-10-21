using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Programmazione.Events.InterventoGeneration
{
    public class InterventoGeneratedConfirmed : EventBase
    {
        public Guid IdIntervento { get; set; }


        public InterventoGeneratedConfirmed()
        {
            
        }

        public InterventoGeneratedConfirmed(Guid id, Guid idCommitId, long version, Guid idIntervento)
            : base(id, idCommitId,version)
        {
            Contract.Requires(idIntervento!= Guid.Empty);

            IdIntervento = idIntervento;
        }

        public override string ToDescription()
        {
            return string.Format("La generazione del'intervento {1} della schedulazione {0}  é stata comminciata  ", Id, IdIntervento);
        }
    }
}
