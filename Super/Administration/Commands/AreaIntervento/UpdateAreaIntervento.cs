using System;
using System.Runtime.Serialization;
using CommandService;
using CommonDomain;

namespace Super.Administration.Commands.AreaIntervento
{
    [DataContract]
    public class UpdateAreaIntervento : CommandBase
    {

        public Guid Id { get; set; }
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
            return string.Format("We update an Area Intervento (Description:'{0}',Start:'{1}',End:'{2}', Id:'{3}')", Description, Start, End, Id);
        }
    }
}
