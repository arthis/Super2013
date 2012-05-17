using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using NUnit.Framework;

namespace CommonSpecs
{


    [TestFixture]
    public abstract class BaseClass<TCommand> where TCommand : class, ICommand
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

    
}