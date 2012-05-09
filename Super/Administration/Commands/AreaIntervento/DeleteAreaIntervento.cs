using System;
using CommonDomain;

namespace Super.Administration.Commands.AreaIntervento
{
    public class DeleteAreaIntervento : ICommand
    {
        
        public Guid Id { get; set; }

        public DeleteAreaIntervento()
        {
                
        }
      

         public DeleteAreaIntervento(Guid id)
        {
            this.Id = id;
        }


        public string ToDescription()
        {
            return string.Format("We delete an Area Intervento (Id:'{0}')", Id);
        }
    }
}
