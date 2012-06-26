using System;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoIntervento
{

    public class UpdateTipoInterventoRot : CommandBase
    {
        private readonly string _mnemo;
        private readonly Guid _measuringUnit;
        private readonly Guid _idContract;
        private readonly bool _calcoloDetrazioni;
        private readonly bool _aiTreni;
        private readonly char _classe;

        public bool AiTreni
        {
            get { return _aiTreni; }
        }
        public bool CalcoloDetrazioni
        {
            get { return _calcoloDetrazioni; }
        }
        public char Classe
        {
            get { return _classe; }
        }
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
 

        public UpdateTipoInterventoRot()
        {}

        public UpdateTipoInterventoRot(Guid id, string mnemo, Guid measuringUnit, Guid idContract, bool calcoloDetrazioni, bool aiTreni, char classe, string description)
        {
            _mnemo = mnemo;
            _measuringUnit = measuringUnit;
            _idContract = idContract;
            _calcoloDetrazioni = calcoloDetrazioni;
            _aiTreni = aiTreni;
            _classe = classe;
            this.Id = id;
            this.Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiorniamo il tipo intervento rotabile '{0}')", Description);
        }

        
    }
}
