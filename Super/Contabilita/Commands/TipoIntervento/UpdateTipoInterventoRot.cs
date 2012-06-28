using System;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoIntervento
{

    public class UpdateTipoInterventoRot : CommandBase
    {
        public bool AiTreni { get; set; }
        public bool CalcoloDetrazioni { get; set; }
        public char Classe { get; set; }
        public Guid IdContract { get; set; }
        public Guid IdMasuringUnit { get; set; }
        public string Description { get; set; }
        public string Mnemo { get; set; }
 

        public UpdateTipoInterventoRot()
        {}

        public UpdateTipoInterventoRot(Guid id, string mnemo, Guid idMeasuringUnit, Guid idContract, bool calcoloDetrazioni, bool aiTreni, char classe, string description)
        {
            Contract.Requires<ArgumentNullException>(id != Guid.Empty);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(mnemo));
            Contract.Requires<ArgumentNullException>(idMeasuringUnit != Guid.Empty);
            Contract.Requires<ArgumentNullException>(idContract != Guid.Empty);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(description));

            Mnemo = mnemo;
            IdMasuringUnit = idMeasuringUnit;
            IdContract = idContract;
            CalcoloDetrazioni = calcoloDetrazioni;
            AiTreni = aiTreni;
            Classe = classe;
            Id = id;
            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiorniamo il tipo intervento rotabile '{0}')", Description);
        }

        
    }
}
