using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain.Core.Super.ValueObjects
{
    public class RangeDateUnfinished
    {
        private readonly DateTime _start;
        private readonly DateTime? _end;

        public RangeDateUnfinished(DateTime start, DateTime? end)
        {
            if (!IsValid(start, end))
                throw  new Exception();
            _start = start;
            _end = end;
        }

        public static bool IsValid(DateTime start, DateTime? end)
        {
            if (start == DateTime.MinValue)
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
    }


    public class RangeDate
        {
        private readonly DateTime _start;
        private readonly DateTime _end;

        public RangeDate(DateTime start, DateTime end)
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
