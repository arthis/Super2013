using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain.Core.Tests
{
    public class Event
    {
        
    }

    public class Command
    {

    }

    public class when_receiving_en_event
    {
        //static bool _configuredLoggerUsed;
        //static Bus _bus;

        //Establish context = () =>
        //{
        //    _bus = new BusBuilder().Configure(ctx => ctx.WithLogger(new TestLogger(() => _configuredLoggerUsed = true))
        //                                                .Publish<TestMessage>().WithExchange(ExchangeName)).Build();
        //    _bus.Connect();
        //};

        //Cleanup after = () => _bus.Close();

        //Because of = () => _bus.Publish(new TestMessage("test"));

        //It should_use_the_configured_logger = () => _configuredLoggerUsed.ShouldBeTrue();
    }
}
