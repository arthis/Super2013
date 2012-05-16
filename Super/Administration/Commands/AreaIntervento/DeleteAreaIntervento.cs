using System;
using System.Runtime.Serialization;
using CommandService;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Administration.Commands.AreaIntervento
{
    [DataContract]
    public class DeleteAreaIntervento : CommandBase
    {

        public DeleteAreaIntervento()
        {
                
        }
      

         public DeleteAreaIntervento(Guid id)
        {
            this.Id = id;
        }


        public override string ToDescription()
        {
            return string.Format("We delete an Area Intervento (Id:'{0}')", Id);
        }
    }
}
