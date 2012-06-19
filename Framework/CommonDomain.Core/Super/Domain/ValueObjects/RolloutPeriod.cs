using System;

namespace CommonDomain.Core.Super.Domain.ValueObjects
{
    public class RolloutPeriod
        {
        private readonly DateTime _start;
        private readonly DateTime _end;

        public RolloutPeriod(DateTime start, DateTime end)
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
    }
}
