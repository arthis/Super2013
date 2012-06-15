using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace CommonDomain.Core.Super.ValueObjects
{
    public class Treno
    {
        private readonly string _numeroTreno;
        private readonly DateTime _data;

        public Treno(string numeroTreno, DateTime data)
        {
            if (!IsValid(numeroTreno,data))
                throw new Exception(string.Format("Treno ({0},{1}) not valid", numeroTreno,data));
            _numeroTreno = numeroTreno;
            _data = data;
        }

        public static bool IsValid(string numeroTreno, DateTime data)
        {
            return !string.IsNullOrEmpty(numeroTreno) && data > DateTime.MinValue;
        }

        public string NumeroTreno
        {
            get { return _numeroTreno; }
        }

        public DateTime Data
        {
            get { return _data; }
        }
    }
}
