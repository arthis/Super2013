using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UI_Web.Models
{
    

    public class VisualizzareImpianto
    {
        public string Description { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
    }


    public class CreateImpianto 
    {
        public Super.Contabilita.Commands.Impianto.CreateImpianto Command { get; set; }
        public List<SelectListItem> Lotti { get; set; }
    }

    public class EditImpianto 
    {
        public Super.Contabilita.Commands.Impianto.UpdateImpianto Command { get; set; }
        public string LottoDescription { get; set; }
    }

    public class DeleteImpianto
    {
        public Super.Contabilita.Commands.Impianto.DeleteImpianto Command { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string LottoDescription { get; set; }
    }
    
    
}