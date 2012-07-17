using System;

namespace Core_Web.Models
{
    

    public class VisualizzareLotto
    {
        public string Description { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
    }


    public class CreateLotto : CommandBase
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class EditLotto : CommandBase
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Description { get; set; }
    }

    public class DeleteLotto : CommandBase
    {
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
    
    
}