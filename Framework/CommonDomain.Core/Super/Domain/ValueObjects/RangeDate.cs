using System;

namespace CommonDomain.Core.Super.Domain.ValueObjects
{
    public class RangeDate
    {
        private readonly DateTime? _start;
        private readonly DateTime? _end;

        public RangeDate(DateTime?start, DateTime? end)
        {
            if (!IsValid(start, end))
                throw  new Exception();
            _start = start;
            _end = end;
        }

        public static bool IsValid(DateTime? start, DateTime? end)
        {
            if (start.HasValue && start.Value == DateTime.MaxValue)
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
    }
}