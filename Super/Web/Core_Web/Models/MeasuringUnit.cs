using System;

namespace Core_Web.Models
{
    

    public class VisualizzareMeasuringUnit
    {
        public string Description { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
    }


    public class CreateMeasuringUnit : CommandBase
    {
        public string Description { get; set; }
        
    }

    public class EditMeasuringUnit : CommandBase
    {
        public string Description { get; set; }
    }

    public class DeleteMeasuringUnit : CommandBase
    {
        public string Description { get; set; }
    }
    
    
}