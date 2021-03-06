﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Domain.Builders;
using CommonDomain.Core.Super.Messaging;
using CommonDomain.Core.Super.Messaging.Builders;

namespace CommonDomain.Core.Super.Domain.ValueObjects
{
    public class Period
    {
        private readonly DateTime _start;
        private readonly DateTime _end;

        public Period(DateTime start, DateTime end)
        {
            if (!IsValid(start, end))
                throw new Exception();
            _start = start;
            _end = end;
        }

        public static bool IsValid(DateTime start, DateTime? end)
        {
            if (start == DateTime.MinValue || end == DateTime.MinValue)
                return false;

            if (start > end)
                return false;

            return true;
        }

        public DateTime GetStart()
        {
            return _start;
        }
        public DateTime GetEnd()
        {
            return _end;
        }

        public void BuildValue(MsgPeriodBuilder builder)
        {
            Contract.Requires(builder != null);

            builder.From(_start).To(_end);
        }

        public IEnumerable<DateTime> GetDays()
        {
            for (DateTime mydate = _start; mydate <= _end; mydate = mydate.AddDays(1))
            {
                yield return mydate;
            }
        }

    }

    public static class PeriodExtension
    {
        public static Messaging.ValueObjects.Period ToMessage(this  Period period)
        {
            Contract.Requires(period != null);

            var builder = BuildMessagingVO.MsgPeriod;
            period.BuildValue(builder);
            return builder.Build();
        }

        public static Period ToDomain(this  Messaging.ValueObjects.Period period)
        {
            Contract.Requires(period != null);

            return BuildDomainVO.Period
                .From(period.StartDate)
                .To(period.EndDate)
                .Build();
        }
    }
}
