using System;
using CommonDomain.Core.Super.Messaging.Builders;

namespace CommonDomain.Core.Super.Domain.ValueObjects
{
    public class Intervall
    {
        private readonly DateTime _start;
        private readonly DateTime? _end;

        public Intervall(DateTime start, DateTime? end)
        {
            if (!IsValid(start, end))
                throw new Exception("Intervall not valid");
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

        public void BuildValue(IntervallBuilder builder)
        {
            builder.From(_start).To(_end);
        }



    }
}