using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UI_Web.Models
{
    

    public class VisualizzareLotto
    {
        public string Description { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
    }


    public class CreateLotto 
    {
        public Super.Contabilita.Commands.Lotto.CreateLotto Command { get; set; }
    }

    public class EditLotto 
    {
        public Super.Contabilita.Commands.Lotto.UpdateLotto Command { get; set; }
    }

    public class DeleteLotto
    {
        public Super.Contabilita.Commands.Lotto.DeleteLotto Command { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
    
    
}