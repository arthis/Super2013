using System;

namespace Super.Controllo.Commands.Builders
{
    public class ControlInterventoNonResoBuilder
    {
        private Guid _id;
        private Guid _idUtente;
        private DateTime _controlDate;
        private Guid _idCausale;
        private string _note;


        public ControlInterventoNonResoBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

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

        public ControlInterventoNonReso Build()
        {
            var cmd = new ControlInterventoNonReso(_id, _idUtente, _controlDate,_idCausale,_note);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}