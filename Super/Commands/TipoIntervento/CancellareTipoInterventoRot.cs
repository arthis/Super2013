﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cqrs.Commanding;
using System.ComponentModel.DataAnnotations;
using Commands.Attributes;
using Cqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Commands.TipoIntervento
{
    public class CancellareTipoInterventoRot : CommandBase
    {
        [AggregateRootId]
        public Guid Id { get; set; }
      
         public CancellareTipoInterventoRot()
        {
        }

        public CancellareTipoInterventoRot(Guid id)
        {
            this.Id = id;
        }

       
    }
}
