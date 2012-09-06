using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Programmazione.Events.Schedulazione
{
    public class InterventiAskedTobeGeneratedFromSchedulazione : Message, IEvent
    {
        public InterventiAskedTobeGeneratedFromSchedulazione()
        {

        }

        public InterventiAskedTobeGeneratedFromSchedulazione(Guid id, Guid idCommitId, long version)
            : base(id, idCommitId, version)
        {

        }

        public override string ToDescription()
        {
            return string.Format("La schedulazione {0} é stata richiesta di generare interventi ", Id);
        }
    }
}