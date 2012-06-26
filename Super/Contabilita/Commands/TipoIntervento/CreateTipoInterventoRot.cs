using System;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoIntervento
{
    
    public class CreateTipoInterventoRot : CommandBase
    {
        private readonly string _mnemo;
        private readonly Guid _measuringUnit;
        private readonly Guid _idContract;
        private readonly char _classe;
        private readonly bool _calcoloDetrazioni;
        private readonly bool _aiTreni;


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
        public DateTime CreationDate { get; private set; }
        public string Mnemo
        {
            get { return _mnemo; }
        }

        public CreateTipoInterventoRot()
        {
            
        }

        public CreateTipoInterventoRot(Guid id, string mnemo, Guid measuringUnit, Guid idContract, char classe,bool calcoloDetrazioni,bool aiTreni, DateTime creationDate, string description)
        {
            _mnemo = mnemo;
            _measuringUnit = measuringUnit;
            _idContract = idContract;
            _classe = classe;
            _calcoloDetrazioni = calcoloDetrazioni;
            _aiTreni = aiTreni;
            this.Id = id;
            
            this.Description = description;
            this.CreationDate = creationDate;
        }

        public override string ToDescription()
        {
            return string.Format("Creiamo il tipo intervento rotabile '{0}'.", Description);
        }

        
    }
}
