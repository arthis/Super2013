using System;
using System.Linq;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Machine.Specifications;
using NUnit.Framework;
using It = Machine.Specifications.It;

namespace CommonDomain.Core.Tests.Super.Domain.ValueObjects
{
    [TestFixture]
    public class WorkPeriodTests
    {
        [Test]
        public void Create_workperiod()
        {
            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddHours(1);
            var workPeriod = new WorkPeriod(startDate,endDate);
            Assert.IsNotNull(workPeriod);
            Assert.AreEqual(startDate,workPeriod.GetStart());
            Assert.AreEqual(endDate, workPeriod.GetEnd());
        }

        [Test]
        public void Create_workperiod_with_start_greater_than_end()
        {
            var startDate = DateTime.Now.AddHours(1);
            var endDate = DateTime.Now;
            Assert.Catch<Exception>(()=>new WorkPeriod(startDate, endDate));
        }

        [Test]
        public void GetDays_from_a_workperiod()
        {
            var startDate = DateTime.Today;
            var endDate = DateTime.Today.AddDays(2);
            var workPeriod = new WorkPeriod(startDate, endDate);

            var days = workPeriod.GetDays();
            
            Assert.IsNotNull(days);
            Assert.AreEqual(3,days.Count());
            Assert.AreEqual(startDate, days.First());
            Assert.AreEqual(endDate, days.Last());
        }

        [Test]
        public void Contains_another_workperiod()
        {
            var startDate1 = DateTime.Today;
            var endDate1 = DateTime.Today.AddDays(3);
            var wp1 = new WorkPeriod(startDate1, endDate1);

            var StartDate2 = startDate1.AddHours(1);
            var EndDate2 = endDate1.AddHours(-1);
            var wp2 =new WorkPeriod(StartDate2, EndDate2);

            Assert.IsTrue(wp1.Contains(wp2));
        }

        [Test]
        public void Does_not_Contain_another_workperiod_whom_start_date_is_smaller()
        {
            var startDate1 = DateTime.Today;
            var Enddate1 = DateTime.Today.AddDays(3);
            var wp1 = new WorkPeriod(startDate1, Enddate1);

            var StartDate2 = startDate1.AddHours(-1);
            var EndDate2 = Enddate1.AddHours(-1);
            var wp2 = new WorkPeriod(StartDate2, EndDate2);

            Assert.IsFalse(wp1.Contains(wp2));
        }

        [Test]
        public void Does_not_Contain_another_workperiod_whom_end_date_is_greater()
        {
            var startDate1 = DateTime.Today;
            var Enddate1 = DateTime.Today.AddDays(3);
            var wp1 = new WorkPeriod(startDate1, Enddate1);

            var StartDate2 = startDate1.AddHours(1);
            var EndDate2 = Enddate1.AddHours(1);
            var wp2 = new WorkPeriod(StartDate2, EndDate2);

            Assert.IsFalse(wp1.Contains(wp2));
        }


    }
}