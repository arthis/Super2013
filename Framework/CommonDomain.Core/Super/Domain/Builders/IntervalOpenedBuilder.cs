using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core.Super.Domain.ValueObjects;

namespace CommonDomain.Core.Super.Domain.Builders
{
    public class IntervalOpenedBuilder
    {
        DateTime? _from;
        DateTime? _to;

        public IntervalOpenedBuilder From(DateTime? value)
        {
            _from = value;
            return this;
        }

        public IntervalOpenedBuilder To(DateTime? value)
        {
            _to = value;
            return this;
        }

        public IntervalOpenedBuilder FromIntervalOpened(Messaging.ValueObjects.IntervalOpened interval)
        {
            _from = interval.Start;
            _to = interval.End;
            return this;
        }



        public IntervalOpened Build()
        {
            return new IntervalOpened(_from, _to);
        }

    }
}
