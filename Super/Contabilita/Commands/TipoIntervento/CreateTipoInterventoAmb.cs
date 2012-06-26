using System;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoIntervento
{
    
    public class CreateTipoInterventoAmb : CommandBase
    {
        private readonly string _mnemo;
        private readonly Guid _measuringUnit;
        private readonly Guid _idContract;

        public Guid IdContract
        {
            get { return _idContract; }
        }
        public Guid MeasuringUnit
        {
            get { return _measuringUnit; }
        }
        public string Description { get; private set; }
        public DateTime CreationDate { get; private set; }
        public string Mnemo
        {
            get { return _mnemo; }
        }

        public CreateTipoInterventoAmb()
        {
            
        }

        public CreateTipoInterventoAmb(Guid id, string mnemo, Guid measuringUnit, Guid idContract,  DateTime creationDate, string description)
        {
            _mnemo = mnemo;
            _measuringUnit = measuringUnit;
            _idContract = idContract;
            this.Id = id;
            
            this.Description = description;
            this.CreationDate = creationDate;
        }

        public override string ToDescription()
        {
            return string.Format("Creiamo il tipo intervento ambiente '{0}'.", Description);
        }

        
    }
}
