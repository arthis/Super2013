using System;
using CommonDomain.Core.Super.Messaging.Builders;

namespace CommonDomain.Core.Super.Domain.ValueObjects
{
    public class IntervalOpened
    {
        private readonly DateTime? _start;
        private readonly DateTime? _end;

        public IntervalOpened(DateTime? start, DateTime? end)
        {
            if (!IsValid(start, end))
                throw new Exception("Interval not valid");
            _start = start;
            _end = end;
        }

        public static bool IsValid(DateTime? start, DateTime? end)
        {
            if (start == DateTime.MaxValue)
                return false;
            if (end.HasValue && end.Value == DateTime.MinValue)
                return false;
            if (start.HasValue && end.HasValue && start > end)
                return false;

            return true;
        }

        public DateTime? GetStart()
        {
            return _start;
        }
        public DateTime? GetEnd()
        {
            return _end;
        }

        public void BuildValue(IntervalOpenedBuilder builder)
        {
            builder.From(_start).To(_end);
        }

        public bool Contains(DateTime date)
        {
            if (_start.HasValue && date < _start.Value)
                return false;
            if (_end.HasValue && date > _end.Value)
                return false;
            
            return true;
        }

        public static IntervalOpened FromMessage(Messaging.ValueObjects.IntervalOpened interval)
        {
            return new IntervalOpened(interval.Start, interval.End);
        }


    }
}