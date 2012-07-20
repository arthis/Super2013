using System;
using CommonDomain;

namespace Super.Controllo.Events.Builders
{
    public class InterventoControlledNonResoBuilder : IEventBuilder<InterventoControlledNonReso>
    {
        private Guid _idUser;
        private DateTime _controlDate;
        private Guid _idCausale;
        private string _note;
      

        public InterventoControlledNonResoBuilder By(Guid idUser)
        {
            _idUser = idUser;
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

        public InterventoControlledNonReso Build(Guid id, long version)
        {
            var cmd = new InterventoControlledNonReso(id, Guid.NewGuid(), version,  _idUser, _controlDate,_idCausale,_note);

            

            return cmd;
        }

    }
}