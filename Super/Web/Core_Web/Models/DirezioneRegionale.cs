using System;

namespace Core_Web.Models
{
    

    public class VisualizzareDirezioneRegionale
    {
        public string Description { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
    }


    public class CreateDirezioneRegionale : CommandBase
    {
        public string Description { get; set; }
        
    }

    public class EditDirezioneRegionale : CommandBase
    {
        public string Description { get; set; }
    }

    public class DeleteDirezioneRegionale : CommandBase
    {
        public string Description { get; set; }
    }
    
    
}