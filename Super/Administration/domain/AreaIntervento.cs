﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Administration.Events.AreaIntervento;
using Super.Administration.Events.Builders;

namespace Super.Administration.Domain
{
    public class AreaIntervento : AggregateBase
    {
        public bool Deleted { get; set; }

        public AreaIntervento()
        {
        }

        public AreaIntervento(Guid id, RollonPeriod rollonPeriod, DateTime creationDate, string description)
        {
            var evt = Build.AreaInterventoCreated
                          .ForPeriod(rollonPeriod)
                          .ForCreationDate(creationDate)
                          .ForDescription(description)
                          .Build(id,Version);
            RaiseEvent(evt);
        }

        public void Apply(AreaInterventoCreated e)
        {
            Id = e.Id;
        }



        public void Update(RollonPeriod rollonPeriod, string description)
        {
            var evt = Build.AreaInterventoUpdated
                          .ForPeriod(rollonPeriod)
                          .ForDescription(description)
                          .Build(Id, Version);
            RaiseEvent(evt);
        }

        public void Apply(AreaInterventoUpdated e)
        {

        }

        public void Delete()
        {
            var isAlreadyDeleted = new Is_Already_Deleted();

            ISpecification<AreaIntervento> specs = isAlreadyDeleted;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = Build.AreaInterventoDeleted
                               .Build(Id, Version);
                RaiseEvent(evt);
            }
        }

        public void Apply(AreaInterventoDeleted e)
        {
            this.Deleted = true;
        }


    }
}
