using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging;
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

        public void BuildValue(MsgIntervalBuilder builder)
        {
            Contract.Requires(builder != null);

            builder.From(_start).To(_end);
        }

        public bool Contains(Interval other)
        {
            Contract.Requires(other != null);

            if (_start > other._start)
                return false;
            if(_end.HasValue && !other._end.HasValue)
                return false;
            if (_end.HasValue && other._end.HasValue && _end.Value < other._end.Value)
                return false;

            return true;
        }
    }

    public static class IntervalExtension
    {
        public static Messaging.ValueObjects.Interval ToMessage(this  Interval interval)
        {
            Contract.Requires(interval != null);

            var builder = BuildMessagingVO.MsgInterval;
            interval.BuildValue(builder);
            return builder.Build();
        }

        public static Interval ToDomain(this  Messaging.ValueObjects.Interval interval)
        {
            Contract.Requires(interval != null);

            return BuildDomainVO.Interval
                .From(interval.Start)
                .To(interval.End)
                .Build();
        }
    }
}