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

        public bool Contains(IntervalOpened other)
        {
            throw new NotImplementedException();

            //if (_start.HasValue && )
            //if (_start > other._start)
            //    return false;
            //if (_end.HasValue && !other._end.HasValue)
            //    return false;
            //if (_end.HasValue && other._end.HasValue && _end.Value < other._end.Value)
            //    return false;

            //return true;
        }

        public static IntervalOpened FromMessage(Messaging.ValueObjects.IntervalOpened interval)
        {
            return new IntervalOpened(interval.Start, interval.End);
        }


    }
}