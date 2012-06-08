using System;
using System.Threading;

namespace EasyNetQ.Tests
{
    public class SimpleSagaSpike
    {
        /// <summary>
        /// Run both EasyNetQ.Tests.SimpleSaga and EasyNetQ.Tests.SimpleService first
        /// You should see the message hit the SimpleSaga, bounce to the SimpleService
        /// and then bounce back to the SimpleSaga again before ending here.
        /// </summary>
        public void RunSaga()
        {
            var bus = RabbitHutch.CreateBus("host=localhost");

            bus.Subscribe<EndMessage>("runSaga_spike", endMessage => 
                Console.WriteLine("Got EndMessage: {0}", endMessage.Text));

            var startMessage = new StartMessage
            {
                Text = "Hello Saga! "
            };

            bus.Publish(startMessage);

            // give the message time to run through the process
            Thread.Sleep(1000);
        }

        public void Can_call_publish_inside_a_subscribe_handler()
        {
            var bus = RabbitHutch.CreateBus("host=localhost");

            // setup the Saga
            Console.WriteLine("Setting up the Saga");
            bus.Subscribe<StartMessage>("simpleSaga", startMessage =>
            {
                Console.WriteLine("Saga got StartMessage: {0}", startMessage.Text);
                var firstProcessedMessage = startMessage.Text + " - initial process ";
                var request = new TestRequestMessage { Text = firstProcessedMessage };

                bus.Request<TestRequestMessage, TestResponseMessage>(request, response =>
                {
                    Console.WriteLine("Saga got Response: {0}", response.Text);
                    var secondProcessedMessage = response.Text + " - final process ";
                    var endMessage = new EndMessage { Text = secondProcessedMessage };
                    bus.Publish(endMessage);
                });
            });
            
            // setup the RPC endpoint
            Console.WriteLine("Setting up the RPC endpoint");
            bus.Respond<TestRequestMessage, TestResponseMessage>(request =>
            {
                Console.WriteLine("RPC got Request: {0}", request.Text);
                return new TestResponseMessage {Text = request.Text + " Responded! "};
            });

            // setup the final subscription
            Console.WriteLine("Setting up the final subscription");
            bus.Subscribe<EndMessage>("inline_saga_spike", endMessage => 
                Console.WriteLine("Test got EndMessage: {0}", endMessage.Text));

            Thread.Sleep(1000);
            // now kick it off
            Console.WriteLine("Test is publishing StartMessage");
            bus.Publish(new StartMessage { Text = "Hello Saga!! " });

            // give the message time to run through the process
            Thread.Sleep(1000);
        }
    }
}