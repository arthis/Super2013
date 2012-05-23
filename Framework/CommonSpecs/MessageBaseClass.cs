using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using EasyNetQ;
using NUnit.Framework;

namespace CommonSpecs
{
    public static class EnumerableExtension
    {
        public static bool IsEquivalentTo(this IEnumerable first, IEnumerable second)
        {
            var secondList = second.Cast<object>().ToList();
            foreach (var item in first)
            {
                var index = secondList.FindIndex(item.Equals);
                if (index < 0)
                {
                    return false;
                }
                secondList.RemoveAt(index);
            }
            return secondList.Count == 0;
        }

        public static bool IsSubsetOf(this IEnumerable first, IEnumerable second)
        {
            var secondList = second.Cast<object>().ToList();
            foreach (var item in first)
            {
                var index = secondList.FindIndex(item.Equals);
                if (index < 0)
                {
                    return false;
                }
                secondList.RemoveAt(index);
            }
            return true;
        }
    }

    [TestFixture]
    public abstract class SagaBaseClass<TMessage> where TMessage : class, IMessage
    {

        public Guid Id { get; set; }
        public abstract IEnumerable<IMessage> Given();
        public abstract TMessage When();
        public abstract IEnumerable<IMessage> Expect();
        protected Exception Caught;
        protected abstract SagaHandler<TMessage> SagaHandler(ISagaRepository repository, IBus bus);
        readonly FakeSagaRepository _fakeRepository = new FakeSagaRepository();
        readonly FakeBus _fakeBus = new FakeBus();


        [SetUp]
        public void Setup()
        {
            var eventHandler = SagaHandler(_fakeRepository, _fakeBus);
            _fakeRepository.CommittedEvents = Given();
            var @event = When();
            var expect = Expect();

            try
            {
                var saga = eventHandler.OnHandle(@event);
                var actual = saga.GetUndispatchedMessages() as LinkedList<Message>;

                Assert.IsNotNull(actual);
                var muyb = expect.SequenceEqual(actual);
                Assert.IsTrue(muyb);
            }
            catch (Exception e)
            {
                Caught = e;
            }
        }

    }
}