using System;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.MeasuringUnit
{
    
    public class DeleteMeasuringUnit : CommandBase
    {

        public DeleteMeasuringUnit()
        {
                
        }
      

         public DeleteMeasuringUnit(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
        }


        public override string ToDescription()
        {
            return string.Format("Cancelliamo l'unità di misura (Id:'{0}')", Id);
        }


        public bool Equals(DeleteMeasuringUnit other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DeleteMeasuringUnit);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
