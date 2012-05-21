﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain
{
    public interface IMessage
    {
        IEnumerable<KeyValuePair<string, object>> Headers { get; set; }
        void SetHeader(string key, object value);
    }
}
