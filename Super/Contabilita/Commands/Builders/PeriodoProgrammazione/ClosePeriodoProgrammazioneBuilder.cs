using System;
using CommonDomain;
using Super.Contabilita.Commands.PeriodoProgrammazione;

namespace Super.Contabilita.Commands.Builders.PeriodoProgrammazione
{
    public class ClosePeriodoProgrammazioneBuilder : ICommandBuilder<ClosePeriodoProgrammazione>
    {
        private DateTime _closingDate;
        private Guid _idUser;


        public ClosePeriodoProgrammazione Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public ClosePeriodoProgrammazione Build(Guid id, Guid commitId, long version)
        {
            var cmd =  new ClosePeriodoProgrammazione(id, commitId, version,_closingDate,_idUser);
            return cmd;
        }


        public ClosePeriodoProgrammazioneBuilder When(DateTime closingDate)
        {
            _closingDate = closingDate;
            return this;
        }

        public ClosePeriodoProgrammazioneBuilder By(Guid idUser)
        {
            _idUser = idUser;
            return this;
        }

    }
}
