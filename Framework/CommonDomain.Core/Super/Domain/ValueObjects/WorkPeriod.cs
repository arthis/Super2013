using System;
using System.Collections.Generic;
using CommonDomain.Core.Super.Messaging;
using CommonDomain.Core.Super.Messaging.Builders;

namespace CommonDomain.Core.Super.Domain.ValueObjects
{
    public class WorkPeriod
        {
        private readonly DateTime _start;
        private readonly DateTime _end;

        public WorkPeriod(DateTime start, DateTime end)
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

        public void BuildValue(MsgWorkPeriodBuilder builder)
        {
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

    public static class WorkPeriodExtension
    {
        public static Messaging.ValueObjects.WorkPeriod ToMessage(this  WorkPeriod workPeriod)
        {
            var builder = BuildMessagingVO.MsgWorkPeriod;
            workPeriod.BuildValue(builder);
            return builder.Build();
        }

        public static WorkPeriod ToDomain(this  Messaging.ValueObjects.WorkPeriod workPeriod)
        {
            return BuildDomainVO.WorkPeriod
                .From(workPeriod.StartDate)
                .To(workPeriod.EndDate)
                .Build();
        }
    }
}
