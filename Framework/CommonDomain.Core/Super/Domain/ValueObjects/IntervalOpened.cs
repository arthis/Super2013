using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging;
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

        public void BuildValue(MsgIntervalOpenedBuilder builder)
        {
            Contract.Requires(builder != null);

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
    }


    public static class IntervalOpenedExtension
    {
        public static Messaging.ValueObjects.IntervalOpened ToMessage(this  IntervalOpened IntervalOpened)
        {
            Contract.Requires(IntervalOpened != null);

            var builder = BuildMessagingVO.MsgIntervalOpened;
            IntervalOpened.BuildValue(builder);
            return builder.Build();
        }

        public static IntervalOpened ToDomain(this  Messaging.ValueObjects.IntervalOpened IntervalOpened)
        {
            Contract.Requires(IntervalOpened != null);

            return BuildDomainVO.IntervalOpened
                .From(IntervalOpened.Start)
                .To(IntervalOpened.End)
                .Build();
        }
    }
}