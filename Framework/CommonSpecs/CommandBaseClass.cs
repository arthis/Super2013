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
    public abstract class CommandBaseClass<TCommand> where TCommand : class, IMessage
    {
        
        public Guid Id { get; set; }
        public abstract IEnumerable<IMessage> Given();
        public abstract TCommand When();
        public abstract IEnumerable<IMessage> Expect();
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