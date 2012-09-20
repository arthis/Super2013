using System;
using CommonDomain;
using Super.Programmazione.Commands.Scenario;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Schedulazione
{
    public  class CalculateSchedulazionePriceBuilder : ICommandBuilder<CalculateSchedulazionePriceOfScenario>
    {
        private decimal _price;
        private Guid _idScenario;

        public CalculateSchedulazionePriceBuilder ForScenario(Guid idScenario)
        {
            _idScenario = idScenario;
            return this;
        }



        public CalculateSchedulazionePriceBuilder ToPrice(decimal price)
        {
            _price = price;
            return this;
        }

        public CalculateSchedulazionePriceOfScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CalculateSchedulazionePriceOfScenario Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new CalculateSchedulazionePriceOfScenario(id, idCommitId, version, _idScenario, _price);

            return cmd;
        }



    }
}