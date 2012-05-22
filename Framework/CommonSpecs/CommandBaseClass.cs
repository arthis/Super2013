using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using EasyNetQ;
using NUnit.Framework;

namespace CommonSpecs
{


    [TestFixture]
    public abstract class CommandBaseClass<TCommand> where TCommand : class, ICommand
    {
        
        public Guid Id { get; set; }
        public abstract IEnumerable<IEvent> Given();
        public abstract TCommand When();
        public abstract IEnumerable<IEvent> Expect();
        protected Exception Caught;
        protected abstract CommandHandler<TCommand> OnHandle(IRepository repository);
        FakeRepository fakeRepository = new FakeRepository();


        [SetUp]
        public void Setup()
        {
            var commandHandler = OnHandle(fakeRepository);
            fakeRepository.CommittedEvents = Given();
            var command = When();
            var expect = Expect();

            try
            {
                commandHandler.Execute(command);
                var actual = fakeRepository.CommittedEvents.ToList();

                Assert.IsNotNull(actual);
                Assert.IsTrue(expect.SequenceEqual(actual));
            }
            catch (Exception e)
            {
                Caught = e;
            }
        }

    }

    [TestFixture]
    public abstract class EventBaseClass<TEvent> where TEvent : class, IEvent
    {

        public Guid Id { get; set; }
        public abstract IEnumerable<IEvent> Given();
        public abstract TEvent When();
        public abstract IEnumerable<IEvent> Expect();
        protected Exception Caught;
        protected abstract IEventHandler<TEvent> OnHandle(ISagaRepository repository, IBus bus);
        readonly FakeSagaRepository fakeRepository = new FakeSagaRepository();
        readonly FakeBus fakeBus = new FakeBus();


        [SetUp]
        public void Setup()
        {
            var eventHandler = OnHandle(fakeRepository, fakeBus);
            fakeRepository.CommittedEvents = Given();
            var @event = When();
            var expect = Expect();

            try
            {
                eventHandler.Handle(@event);
                var actual = fakeRepository.CommittedEvents.ToList();

                Assert.IsNotNull(actual);
                Assert.IsTrue(expect.SequenceEqual(actual));
            }
            catch (Exception e)
            {
                Caught = e;
            }
        }

    }

    
}