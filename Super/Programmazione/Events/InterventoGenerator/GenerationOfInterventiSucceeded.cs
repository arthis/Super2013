﻿using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Programmazione.Events.InterventoGenerator
{
    public class GenerationOfInterventiSucceeded : Message,IEvent
    {
        public GenerationOfInterventiSucceeded()
        {
            
        }

        public GenerationOfInterventiSucceeded(Guid id, Guid idCommitId, long version)
            : base(id, idCommitId,version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("la generazione degli interventi della schedulazione {0}  é stato un successo  ", Id);
        }
    }
}
