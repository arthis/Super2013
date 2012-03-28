using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Commands.Interventi
{
    [DataContract]
    public class InibireIntervento
    {
        public Guid Id { get; set; }

        public InibireIntervento(Guid id)
        {
            Id = id;
        }
    }
}
