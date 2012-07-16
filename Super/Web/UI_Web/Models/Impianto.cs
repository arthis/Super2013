using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace UI_Web.Models
{
    

    public class VisualizzareImpianto
    {
        public string Description { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
    }


    public class CreateImpianto : CommandBase
    {
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        [DisplayName("Lotto")]
        public Guid IdLotto { get; set; }
        public List<SelectListItem> Lotti { get; set; }
    }

    public class EditImpianto : CommandBase
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Description { get; set; }
        public string LottoDescription { get; set; }
    }

    public class DeleteImpianto : CommandBase
    {
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string LottoDescription { get; set; }
    }
    
    
}