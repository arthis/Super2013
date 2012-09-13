﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain
{
    public interface ISession
    {
        Guid UserId { get; }
        bool IsAuthenticated { get; }
    }
}