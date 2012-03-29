using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UI_Web.Models
{
    public class VisualizzareTipoIntervento
    {
        public string Descrizione { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
    }

    
}