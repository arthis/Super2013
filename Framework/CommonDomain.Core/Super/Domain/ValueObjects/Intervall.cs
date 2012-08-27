using System;
using CommonDomain.Core.Super.Messaging.Builders;

namespace CommonDomain.Core.Super.Domain.ValueObjects
{
    public class Interval
    {
        private readonly DateTime _start;
        private readonly DateTime? _end;

        public Interval(DateTime start, DateTime? end)
        {
            if (!IsValid(start, end))
                throw new Exception("Interval not valid");
            _start = start;
            _end = end;
        }

        public static bool IsValid(DateTime start, DateTime? end)
        {
            if ( start == DateTime.MaxValue)
                return false;
            if (end.HasValue && end.Value == DateTime.MinValue)
                return false;
            if (end.HasValue && start > end)
                return false;

            return true;
        }

        public DateTime GetStart()
        {
            return _start;
        }
        public DateTime? GetEnd()
        {
            return _end;
        }

        public void BuildValue(IntervalBuilder builder)
        {
            builder.From(_start).To(_end);
        }

        public bool Contains(Interval other)
        {
            if (_start > other._start)
                return false;
            if(_end.HasValue && !other._end.HasValue)
                return false;
            if (_end.HasValue && other._end.HasValue && _end.Value < other._end.Value)
                return false;

            return true;
        }

        public static Interval FromMessage(Messaging.ValueObjects.Interval interval)
        {
            return new Interval(interval.Start, interval.End);
        }


    }
}