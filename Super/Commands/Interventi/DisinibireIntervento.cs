using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Commands.Interventi
{
    [DataContract]
    public class DisinibireIntervento
    {
        public Guid Id { get; set; }

        public DisinibireIntervento(Guid id)
        {
            Id = id;
        }
    }
}
