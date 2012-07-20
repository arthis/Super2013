using System;
using CommonDomain;

namespace Super.Controllo.Commands.Builders
{
    public class ControlInterventoNonResoBuilder : ICommandBuilder<ControlInterventoNonReso>
    {
        private Guid _idUser;
        private DateTime _controlDate;
        private Guid _idCausale;
        private string _note;

        public ControlInterventoNonResoBuilder By(Guid idUser)
        {
            _idUser = idUser;
            return this;
        }

        public ControlInterventoNonResoBuilder When(DateTime controlDate)
        {
            _controlDate = controlDate;
            return this;
        }

        public ControlInterventoNonResoBuilder Because(Guid idCausale)
        {
            _idCausale = idCausale;
            return this;
        }

        public ControlInterventoNonResoBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public ControlInterventoNonReso Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public ControlInterventoNonReso Build(Guid id, Guid commitId, long version)
        {
            var cmd = new ControlInterventoNonReso(id, commitId, version, _idUser, _controlDate,_idCausale,_note);

            

            return cmd;
        }

    }
}