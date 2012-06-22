using System;

namespace Super.Controllo.Events.Builders
{
    public class InterventoControlledNonResoBuilder
    {
        private Guid _id;
        private Guid _idUtente;
        private DateTime _controlDate;
        private Guid _idCausale;
        private string _note;


        public InterventoControlledNonResoBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

        public InterventoControlledNonResoBuilder By(Guid idUtente)
        {
            _idUtente = idUtente;
            return this;
        }

        public InterventoControlledNonResoBuilder When(DateTime controlDate)
        {
            _controlDate = controlDate;
            return this;
        }

        public InterventoControlledNonResoBuilder Because(Guid idCausale)
        {
            _idCausale = idCausale;
            return this;
        }

        public InterventoControlledNonResoBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public InterventoControlledNonReso Build()
        {
            var cmd = new InterventoControlledNonReso(_id, _idUtente, _controlDate,_idCausale,_note);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}