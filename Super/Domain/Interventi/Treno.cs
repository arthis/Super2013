using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Domain;

namespace Domain.Interventi
{
    public class Treno : AggregateRootMappedByConvention
    {
        public string Numero { get; set; }
        public Guid CategoriaTreno { get; set; }
        public string StazionePartenza { get; set; }
        public DateTime DataPartenza { get; set; }
        public string StazioneArrivo { get; set; }
        public DateTime DataArrivo { get; set; }
        public bool IsValidaOtre { get; set; }
    }
}
