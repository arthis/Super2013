using System;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Controllo.Events.Builders
{
    public class InterventoRotManControlledResoBuilder
    {
        private Guid _id;
        private Guid _idUtente;
        private DateTime _controlDate;
        private string _note;
        private WorkPeriod _period;
        private OggettoRotMan[] _oggetti;



        public InterventoRotManControlledResoBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

        public InterventoRotManControlledResoBuilder By(Guid idUtente)
        {
            _idUtente = idUtente;
            return this;
        }

        public InterventoRotManControlledResoBuilder When(DateTime controlDate)
        {
            _controlDate = controlDate;
            return this;
        }


        public InterventoRotManControlledResoBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }


        public InterventoRotManControlledResoBuilder ForPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }

        public InterventoRotManControlledResoBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }



        public InterventoRotManControlledReso Build()
        {
            var cmd = new InterventoRotManControlledReso(_id, _idUtente, _controlDate, _period, _note, _oggetti);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }


    }
}