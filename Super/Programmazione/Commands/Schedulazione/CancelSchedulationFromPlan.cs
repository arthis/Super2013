using System;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Schedulazione
{
    public class CancelSchedulazioneFromPlan : CommandBase
    {
        public Guid IdUser { get; set; }

        public CancelSchedulazioneFromPlan()
        {

        }

        public CancelSchedulazioneFromPlan(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {

        }

        public override string ToDescription()
        {
            return string.Format("Cancellare schedulazione {0} dal piano ", Id);
        }


    }
}