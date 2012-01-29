using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interventi.Stati
{
    public abstract class StatoTrenitalia 
    {
        public DateTime DataConsuntivazione { get; set; }

        public abstract void Consuntiva();

    }
}
