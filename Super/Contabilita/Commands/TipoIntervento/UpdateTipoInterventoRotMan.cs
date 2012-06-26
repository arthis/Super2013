using System;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoIntervento
{

    public class UpdateTipoInterventoRotMan : CommandBase
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
        public string Mnemo
        {
            get { return _mnemo; }
        }
 
        public UpdateTipoInterventoRotMan()
        {}

        public UpdateTipoInterventoRotMan(Guid id, string mnemo, Guid measuringUnit, Guid idContract,   string description)
        {
            _mnemo = mnemo;
            _measuringUnit = measuringUnit;
            _idContract = idContract;
            this.Id = id;
            this.Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiorniamo il tipo intervento rotabile in manutenzione '{0}')", Description);
        }

        
    }
}
