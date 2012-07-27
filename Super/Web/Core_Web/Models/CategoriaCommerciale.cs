using System;

namespace Core_Web.Models
{
    

    public class VisualizzareCategoriaCommerciale
    {
        public string Description { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
    }


    public class CreateCategoriaCommerciale : CommandBase
    {
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class EditCategoriaCommerciale : CommandBase
    {
        public string Description { get; set; }
    }

    public class DeleteCategoriaCommerciale : CommandBase
    {
        public string Description { get; set; }
    }
    
    
}