using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Programmazione.Commands.Schedulazione
{
    public abstract class AddRuleToSchedulazione : CommandBase
    {
        public Rule Rule { get; set; }


        public AddRuleToSchedulazione()
        {
            
        }

        public AddRuleToSchedulazione(Guid id, Guid idCommitId, long version,
            Rule rule)
            : base(id, idCommitId,version)
        {
            Contract.Requires(rule != null);

            Rule = rule;
            
        }

        public override string ToDescription()
        {
            return string.Format("Aggiungere una regola alla schedulazione {0} ", Id);
        }

        protected bool Equals(AddRuleToSchedulazione other)
        {
            return base.Equals(other) && Equals(Rule, other.Rule);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AddRuleToSchedulazione) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Rule != null ? Rule.GetHashCode() : 0);
            }
        }
    }

    public class AddRuleToSchedulazioneRot : AddRuleToSchedulazione
    {
        public Treno TrenoArrivo { get; set; }
        public WorkPeriod WorkPeriod { get; set; }

        public AddRuleToSchedulazioneRot()
        {

        }

        public AddRuleToSchedulazioneRot(Guid id, Guid idCommitId, long version,
            Rule rule,Treno trenoArrivo,WorkPeriod workPeriod)
            : base(id, idCommitId, version, rule)
        {
            TrenoArrivo = trenoArrivo;
            WorkPeriod = workPeriod;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiungere una regola alla schedulazione rotabile {0} ", Id);
        }

        public bool Equals(AddRuleToSchedulazioneRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.TrenoArrivo, TrenoArrivo) && Equals(other.WorkPeriod, WorkPeriod);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AddRuleToSchedulazioneRot);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (TrenoArrivo != null ? TrenoArrivo.GetHashCode() : 0);
                result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class AddRuleToSchedulazioneRotMan : AddRuleToSchedulazione
    {


        public AddRuleToSchedulazioneRotMan()
        {

        }

        public AddRuleToSchedulazioneRotMan(Guid id, Guid idCommitId, long version,Rule rule)
            : base(id, idCommitId, version,  rule)
        {

        }

        public override string ToDescription()
        {
            return string.Format("Aggiungere una regola alla schedulazione rotabile in manutenzione {0} ", Id);
        }

        public bool Equals(AddRuleToSchedulazioneRotMan other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AddRuleToSchedulazioneRotMan);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class AddRuleToSchedulazioneAmb : AddRuleToSchedulazione
    {


        public AddRuleToSchedulazioneAmb()
        {

        }

        public AddRuleToSchedulazioneAmb(Guid id, Guid idCommitId, long version,Rule rule)
            : base(id, idCommitId, version,  rule)
        {

        }

        public override string ToDescription()
        {
            return string.Format("Aggiungere una regola alla schedulazione ambiente {0} ", Id);
        }

        public bool Equals(AddRuleToSchedulazioneAmb other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AddRuleToSchedulazioneAmb);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
