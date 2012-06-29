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
    public abstract class CommandBaseClass<TCommand> : SpecsBaseClass where TCommand : class, IMessage
    {
        
        public Guid Id { get; set; }
        public abstract IEnumerable<IMessage> Given();
        public abstract TCommand When();
        public abstract IEnumerable<IMessage> Expect();
        protected Exception Caught;
        protected abstract CommandHandler<TCommand> OnHandle(IEventRepository eventRepository);
        FakeEventRepository _fakeEventRepository = new FakeEventRepository();

        protected Dictionary<string, object> Headers = new Dictionary<string, object>();

        public CommandBaseClass()
        {

        }

        [SetUp]
        public void Setup()
        {
            var commandHandler = OnHandle(_fakeEventRepository);
            _fakeEventRepository.CommittedEvents = Given();
            var command = When();
            var expect = Expect();

            try
            {
                commandHandler.Execute(command,null);
                var actual = _fakeEventRepository.CommittedEvents.ToList();

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