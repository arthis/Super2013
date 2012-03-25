using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using System.Runtime.Serialization;

namespace Commands.Interventi
{
    [DataContract]
    public class ScadereConsuntivazioneAppaltatore : CommandBase
    {
        [AggregateRootId]
        public Guid Id { get; set; }
        public DateTime DataScaduta { get; set; }


        public ScadereConsuntivazioneAppaltatore(Guid id, string interventoIdAppaltatore, DateTime dataScaduta)
        {
            Id = id;
            DataScaduta = dataScaduta;
        }
    }

}
