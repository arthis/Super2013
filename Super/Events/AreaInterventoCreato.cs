using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events
{
    [Serializable]
    public class AreaInterventoCreato
    {
        public int IdAreaInterventoSuper { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
