using System;
using System.Runtime.Serialization;
using CommandService;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Administration.Commands.AreaIntervento
{
    
    public class CreateAreaIntervento : CommandBase
    {
        
        public DateTime Start { get; set; }
        
        public DateTime? End { get; set; }
        
        public string Description { get; set; }
        
        public DateTime CreationDate { get; set; }


        public CreateAreaIntervento()
        {
            
        }

        public CreateAreaIntervento(Guid id, DateTime start, DateTime? end, string description, DateTime creationDate)
        {
            this.Id = id;
            this.Start = start;
            this.End = end;
            this.Description = description;
            this.CreationDate = creationDate;
        }


        public override string ToDescription()
        {
            return string.Format("We create an Area Intervento (description:'{0}',start:'{1}',End :'{2}',  Id :'{3}', CreationDate:'{4}', )", Description, Start, End, Id, CreationDate);
        }

    }
}
