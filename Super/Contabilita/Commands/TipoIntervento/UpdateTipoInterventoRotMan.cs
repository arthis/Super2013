using System;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoIntervento
{

    public class UpdateTipoInterventoRotMan : CommandBase
    {
        public Guid IdContract { get; set; }
        public Guid IdMasuringUnit { get; set; }
        public string Description { get; set; }
        public string Mnemo { get; set; }
        

 
        public UpdateTipoInterventoRotMan()
        {}

        public UpdateTipoInterventoRotMan(Guid id, string mnemo, Guid idMeasuringUnit, Guid idContract, string description)
        {
            Contract.Requires<ArgumentNullException>(id != Guid.Empty);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(mnemo));
            Contract.Requires<ArgumentNullException>(idMeasuringUnit != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idContract != Guid.Empty);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(description));

            Mnemo = mnemo;
            IdMasuringUnit = idMeasuringUnit;
            IdContract = idContract;
            Id = id;
            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiorniamo il tipo intervento rotabile in manutenzione '{0}')", Description);
        }

        
    }
}
