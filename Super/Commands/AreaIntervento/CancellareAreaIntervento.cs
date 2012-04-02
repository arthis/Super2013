using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cqrs.Commanding;
using System.ComponentModel.DataAnnotations;
using Commands.Attributes;
using Cqrs.Commanding.CommandExecution.Mapping.Attributes;
using NServiceBus;

namespace Commands.AreaIntervento
{
    public class CancellareAreaIntervento : CommandBase
    {
        [AggregateRootId]
        public Guid Id { get; set; }
      
         public CancellareAreaIntervento()
        {
        }

        public CancellareAreaIntervento(Guid id)
        {
            this.Id = id;
        }

       
    }
}
