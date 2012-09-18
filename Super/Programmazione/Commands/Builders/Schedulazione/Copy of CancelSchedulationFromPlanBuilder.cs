using System;
using CommonDomain;
using Super.Programmazione.Commands.Scenario;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Schedulazione
{
    public  class CalculateSchedulazionePriceBuilder : ICommandBuilder<CalculateSchedulazionePrice>
    {

        public CalculateSchedulazionePrice Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CalculateSchedulazionePrice Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new CalculateSchedulazionePrice(id, idCommitId, version);

            return cmd;
        }



    }
}