using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;

namespace CommonSpecs
{

    [TestFixture]
    public abstract class SagaBaseClass<TMessage> : SpecsBaseClass where TMessage : class, IMessage
    {

        public Guid Id { get; set; }
        public abstract IEnumerable<IMessage> Given();
        public abstract TMessage When();
        public abstract IEnumerable<IMessage> Expect();
        protected Exception Caught;
        protected abstract SagaHandler<TMessage> SagaHandler(ISagaRepository repository, IBus bus);
        readonly FakeSagaRepository _fakeRepository = new FakeSagaRepository();
        readonly FakeBus _fakeBus = new FakeBus();

        protected Dictionary<string, object> _Headers = new Dictionary<string, object>();

        public SagaBaseClass()
        {
        }

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