using System;

namespace UI_Web.Models
{
    public class CommandBase
    {
        public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }
    }

}