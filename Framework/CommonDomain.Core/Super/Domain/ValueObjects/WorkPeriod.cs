using System;
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

        public void BuildValue(WorkPeriodBuilder builder)
        {
            builder.From(_start).To(_end);
        }

        public static WorkPeriod FromMessage(Messaging.ValueObjects.WorkPeriod workPeriod)
        {
            return new WorkPeriod(workPeriod.StartDate, workPeriod.EndDate);
        }


    }
}
