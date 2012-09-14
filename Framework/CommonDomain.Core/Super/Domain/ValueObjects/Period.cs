using System;
using System.Collections;
using System.Collections.Generic;
using CommonDomain.Core.Super.Domain.Builders;
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
                throw  new Exception();
            _start = start;
            _end = end;
        }

        public static bool IsValid(DateTime start, DateTime? end)
        {
            if (start == DateTime.MinValue || end== DateTime.MinValue)
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
            builder.From(_start).To(_end);
        }

        public static Period FromMessage(Messaging.ValueObjects.Period workPeriod)
        {
            return new Period(workPeriod.StartDate, workPeriod.EndDate);
        }

        public IEnumerable<DateTime> GetDays()
        {
            for (DateTime mydate = _start; mydate <= _end; mydate = mydate.AddDays(1))
            {
                yield return mydate;
            }
        }
    }
}
