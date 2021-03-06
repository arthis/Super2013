﻿using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Programmazione.Events.Scenario
{
    public class DescriptionOfScenarioChanged : EventBase
    {
        public string Description { get; set; }

        public DescriptionOfScenarioChanged()
        {
            
        }

        public DescriptionOfScenarioChanged(Guid id, Guid commitId, long version, string description)
            : base(id, commitId, version)
        {
            Contract.Requires(!string.IsNullOrEmpty(description) );

            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Scenario {0} é stato aggiornato", Id);
        }

        public bool Equals(DescriptionOfScenarioChanged other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DescriptionOfScenarioChanged);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Description != null ? Description.GetHashCode() : 0);
            }
        }
    }
}
