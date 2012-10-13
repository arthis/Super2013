using System;
using CommonDomain;
using Super.Programmazione.Events.InterventoGeneration;

namespace Super.Programmazione.Events.Builders.InterventoGeneration
{

    public class GenerationOfInterventiStartedBuilder : IEventBuilder<GenerationOfInterventiStarted>
    {
        private Guid _idSchedulazione;

        public GenerationOfInterventiStartedBuilder ForSchedulazione(Guid idSchedulazione)
        {
            _idSchedulazione = idSchedulazione;
            return this;
        }

        public GenerationOfInterventiStarted Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public GenerationOfInterventiStarted Build(Guid id, Guid commitId, long version)
        {
            return new GenerationOfInterventiStarted(id, commitId, version, _idSchedulazione);
        }

        public bool Equals(GenerationOfInterventiStartedBuilder other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other._idSchedulazione.Equals(_idSchedulazione);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (GenerationOfInterventiStartedBuilder)) return false;
            return Equals((GenerationOfInterventiStartedBuilder) obj);
        }

        public override int GetHashCode()
        {
            return _idSchedulazione.GetHashCode();
        }
    }
}
