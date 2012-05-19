using System;
using System.Runtime.Serialization;
using CommandService;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Administration.Commands.AreaIntervento
{

    public class UpdateAreaIntervento : CommandBase
    {
        
        
        public DateTime Start { get; set; }
        
        public DateTime? End { get; set; }
        
        public string Description { get; set; }


        public UpdateAreaIntervento()
        {
            
        }

        public UpdateAreaIntervento(Guid id,  DateTime start, DateTime? end, string description)
        {
            this.Id = id;
            this.Start = start;
            this.End = end;
            this.Description = description;
        }

    

        public override string ToDescription()
        {
            return string.Format("We update an Area Intervento '{0}')", Description);
        }
    }
}
