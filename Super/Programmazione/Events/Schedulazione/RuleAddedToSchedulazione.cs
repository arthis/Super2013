using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Programmazione.Events.Schedulazione
{
    public abstract class RuleAddedToSchedulazione : Message, IEvent
    {
        public Rule Rule { get; set; }


        public RuleAddedToSchedulazione()
        {

        }

        public RuleAddedToSchedulazione(Guid id, Guid idCommitId, long version, Rule rule)
            : base(id, idCommitId, version)
        {
            Contract.Requires(rule != null);
            Rule = rule;
        }

        public override string ToDescription()
        {
            return string.Format("Regola é stata aggiunta alla schedulazione {0} ", Id);
        }

        protected bool Equals(RuleAddedToSchedulazione other)
        {
            return base.Equals(other) && Equals(Rule, other.Rule);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RuleAddedToSchedulazione) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Rule != null ? Rule.GetHashCode() : 0);
            }
        }
    }


    public class RuleAddedToSchedulazioneRot : RuleAddedToSchedulazione
    {
        public Treno TrenoArrivo { get; set; }
        public WorkPeriod WorkPeriod { get; set; }

        public RuleAddedToSchedulazioneRot()
        {

        }

        public bool Equals(RuleAddedToSchedulazioneRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.TrenoArrivo, TrenoArrivo) && Equals(other.WorkPeriod, WorkPeriod);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as RuleAddedToSchedulazioneRot);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result * 397) ^ (TrenoArrivo != null ? TrenoArrivo.GetHashCode() : 0);
                result = (result * 397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
                return result;
            }
        }

        public RuleAddedToSchedulazioneRot(Guid id, Guid idCommitId, long version,
            Rule rule,
            Treno trenoArrivo,
            WorkPeriod workPeriod)
            : base(id, idCommitId, version, rule)
        {
            TrenoArrivo = trenoArrivo;
            WorkPeriod = workPeriod;
        }

        public override string ToDescription()
        {
            return string.Format("Regola é stata aggiunta alla schedulazione rotabile {0} ", Id);
        }


    }

    public class RuleAddedToSchedulazioneRotMan : RuleAddedToSchedulazione
    {


        public RuleAddedToSchedulazioneRotMan()
        {

        }

        public RuleAddedToSchedulazioneRotMan(Guid id, Guid idCommitId, long version, Rule rule)
            : base(id, idCommitId, version,  rule)
        {

        }

        public override string ToDescription()
        {
            return string.Format("Regola é stata aggiunta alla  schedulazione rotabile in manutenzione {0} ", Id);
        }

        public bool Equals(RuleAddedToSchedulazioneRotMan other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as RuleAddedToSchedulazioneRotMan);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class RuleAddedToSchedulazioneAmb : RuleAddedToSchedulazione
    {


        public RuleAddedToSchedulazioneAmb()
        {

        }

        public RuleAddedToSchedulazioneAmb(Guid id, Guid idCommitId, long version, Rule rule)
            : base(id, idCommitId, version, rule)
        {

        }

        public override string ToDescription()
        {
            return string.Format("Regola é stata aggiunta alla  schedulazione ambiente {0} ", Id);
        }

        public bool Equals(RuleAddedToSchedulazioneAmb other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as RuleAddedToSchedulazioneAmb);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}