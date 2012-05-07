using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interventi
{
    public class TipoOggettoIntervento
    {
        public Guid Id { get; set; }
        public string Descrizione { get; set; }
        public string Sigla { get; set; }
    }
}
