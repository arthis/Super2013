﻿using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoIntervento.Rotabile
{
    
    public class CreateTipoInterventoRot : CommandBase
    {
        public bool AiTreni { get; set; }
        public bool CalcoloDetrazioni { get; set; }
        public char Classe { get; set; }
        
        public Guid IdMeasuringUnit { get; set; }
        public string Description { get; set; }
        public string Mnemo { get; set; }
        

        public CreateTipoInterventoRot()
        {
            
        }

        public CreateTipoInterventoRot(Guid id, Guid commitId, long version, string mnemo, Guid idMeasuringUnit, char classe, bool calcoloDetrazioni, bool aiTreni, string description)
            : base(id, commitId, version)
        {
            Contract.Requires(!string.IsNullOrEmpty(mnemo));
            Contract.Requires(idMeasuringUnit != Guid.Empty);
            Contract.Requires(!string.IsNullOrEmpty(description));


            Mnemo = mnemo;
            IdMeasuringUnit = idMeasuringUnit;
            CalcoloDetrazioni = calcoloDetrazioni;
            AiTreni = aiTreni;
            Classe = classe;
            Description = description;

        }

        public override string ToDescription()
        {
            return string.Format("Creiamo il tipo intervento rotabile '{0}'.", Description);
        }

        public bool Equals(CreateTipoInterventoRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.AiTreni.Equals(AiTreni) && other.CalcoloDetrazioni.Equals(CalcoloDetrazioni) && other.Classe == Classe && other.IdMeasuringUnit.Equals(IdMeasuringUnit) && Equals(other.Description, Description) && Equals(other.Mnemo, Mnemo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreateTipoInterventoRot);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ AiTreni.GetHashCode();
                result = (result*397) ^ CalcoloDetrazioni.GetHashCode();
                result = (result*397) ^ Classe.GetHashCode();
                result = (result*397) ^ IdMeasuringUnit.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ (Mnemo != null ? Mnemo.GetHashCode() : 0);
                return result;
            }
        }
    }
}
