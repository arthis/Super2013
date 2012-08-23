using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace Core_Web.Models
{
    

    public class VisualizzareAppaltatore
    {
        public string Description { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
    }


    public class CreateAppaltatore : CommandBase
    {
        public string Description { get; set; }

    }

    public class EditAppaltatore : CommandBase
    {

        public string Description { get; set; }
    }

    public class DeleteAppaltatore : CommandBase
    {
        public string Description { get; set; }

    }
    
    
}