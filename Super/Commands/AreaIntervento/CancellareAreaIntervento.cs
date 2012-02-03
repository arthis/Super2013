using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;
using System.ComponentModel.DataAnnotations;
using Commands.Attributes;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

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
