using System;
using System.Linq;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Machine.Specifications;
using Moq;
using NUnit.Framework;
using It = Machine.Specifications.It;

namespace CommonDomain.Core.Tests.Super.Domain.ValueObjects
{
    [TestFixture]
    public class IntervalTests
    {
        [Test]
        public void Create_interval()
        {
            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddHours(1);
            var interval = new Interval(startDate,endDate);
            Assert.IsNotNull(interval);
            Assert.AreEqual(startDate,interval.GetStart());
            Assert.AreEqual(endDate, interval.GetEnd());
        }

        [Test]
        public void Create_interval_without_end_value()
        {
            var startDate = DateTime.Now;
            DateTime? endDate = null;
            var workPeriod = new Interval(startDate, endDate);
            Assert.IsNotNull(workPeriod);
            Assert.AreEqual(startDate, workPeriod.GetStart());
            Assert.AreEqual(endDate, workPeriod.GetEnd());
        }

        [Test]
        public void Create_interval_with_start_greater_than_end()
        {
            var startDate = DateTime.Now.AddHours(1);
            var endDate = DateTime.Now;
            Assert.Catch<Exception>(()=>new Interval(startDate, endDate));
        }


        [Test]
        public void Contains_another_interval()
        {
            var startDate1 = DateTime.Today;
            var endDate1 = DateTime.Today.AddDays(3);
            var i1 = new Interval(startDate1, endDate1);

            var StartDate2 = startDate1.AddHours(1);
            var EndDate2 = endDate1.AddHours(-1);
            var i2 =new Interval(StartDate2, EndDate2);

            Assert.IsTrue(i1.Contains(i2));
        }

        [Test]
        public void Does_not_Contain_another_interval_whom_start_date_is_smaller()
        {
            var startDate1 = DateTime.Today;
            var Enddate1 = DateTime.Today.AddDays(3);
            var i1 = new Interval(startDate1, Enddate1);

            var StartDate2 = startDate1.AddHours(-1);
            var EndDate2 = Enddate1.AddHours(-1);
            var i2 = new Interval(StartDate2, EndDate2);

            Assert.IsFalse(i1.Contains(i2));
        }

        [Test]
        public void Contains_another_workperiod_whith_end_date_null()
        {
            var startDate1 = DateTime.Today;
            DateTime? Enddate1 = null;
            var i1 = new Interval(startDate1, Enddate1);

            var StartDate2 = startDate1.AddHours(1);
            var EndDate2 = DateTime.Today.AddDays(1);
            var i2 = new Interval(StartDate2, EndDate2);

            Assert.IsTrue(i1.Contains(i2));
        }


    }
}