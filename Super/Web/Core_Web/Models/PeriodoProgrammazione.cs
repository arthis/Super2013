using System;

namespace Core_Web.Models
{
    

    public class VisualizzarePeriodoProgrammazione
    {
        public string Description { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
    }


    public class CreatePeriodoProgrammazione : CommandBase
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class EditPeriodoProgrammazione : CommandBase
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Description { get; set; }
    }

    public class DeletePeriodoProgrammazione : CommandBase
    {
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
    
    
}