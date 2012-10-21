using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Events.Schedulazione
{
    public class SchedulazioneRotCreated : EventBase
    {
        public Guid IdTipoIntervento { get; set; }
        public Guid IdScenario { get; set; }
        public OggettoRot[] Oggetti { get; set; }
        public WorkPeriod WorkPeriod { get; set; }
        public Period Period { get; set; }

          public SchedulazioneRotCreated(Guid id, Guid commitId, long version, Guid idTipoIntervento, Guid idScenario, OggettoRot[] oggetti, WorkPeriod workPeriod)
            :base(id,commitId,version)
        {
            Contract.Requires(idTipoIntervento!=Guid.Empty);
            Contract.Requires(idScenario != Guid.Empty);
            Contract.Requires(oggetti!=null);
            Contract.Requires(workPeriod != null);

            IdTipoIntervento = idTipoIntervento;
            IdScenario = idScenario;
            Oggetti = oggetti;
            WorkPeriod = workPeriod;
        }

        public override string ToDescription()
        {
            return string.Format("l'intervento rotabile {0} é stato creato", Id);
        }
    }
}
