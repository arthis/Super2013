using System;

namespace Core_Web.Models
{
    

    public class VisualizzareTipoInterventoRot
    {
        public string Description { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
    }


    public class CreateTipoInterventoRot : CommandBase
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Description { get; set; }
        
    }

    public class EditTipoInterventoRot : CommandBase
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Description { get; set; }
    }

    public class DeleteTipoInterventoRot : CommandBase
    {
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
    
    
}