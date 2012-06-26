using System;
using CommonDomain;

namespace Super.Controllo.Commands.Builders
{
    public class ControlInterventoNonResoBuilder : ICommandBuilder<ControlInterventoNonReso>
    {
        private Guid _idUtente;
        private DateTime _controlDate;
        private Guid _idCausale;
        private string _note;

        public ControlInterventoNonResoBuilder By(Guid idUtente)
        {
            _idUtente = idUtente;
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

        public ControlInterventoNonReso Build(Guid id)
        {
            var cmd = new ControlInterventoNonReso(id, _idUtente, _controlDate,_idCausale,_note);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}