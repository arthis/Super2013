using System;

namespace Core_Web.Models
{
    

    public class VisualizzareTipoInterventoRotMan
    {
        public string Description { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
    }


    public class CreateTipoInterventoRotMan : CommandBase
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Description { get; set; }
        
    }

    public class EditTipoInterventoRotMan : CommandBase
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Description { get; set; }
    }

    public class DeleteTipoInterventoRotMan : CommandBase
    {
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
    
    
}