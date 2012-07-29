using System;

namespace Core_Web.Models
{
    

    public class VisualizzareCommittente
    {
        public string Description { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
    }


    public class CreateCommittente : CommandBase
    {
        public string Description { get; set; }
        
    }

    public class EditCommittente : CommandBase
    {
        public string Description { get; set; }
    }

    public class DeleteCommittente : CommandBase
    {
        public string Description { get; set; }
    }
    
    
}