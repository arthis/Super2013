using System;

namespace Core_Web.Models
{
    

    public class VisualizzareTipoInterventoAmb
    {
        public string Description { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
    }


    public class CreateTipoInterventoAmb : CommandBase
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class EditTipoInterventoAmb : CommandBase
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Description { get; set; }
    }

    public class DeleteTipoInterventoAmb : CommandBase
    {
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
    
    
}