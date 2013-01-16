using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;

namespace CommonDomain.Core
{
    public class RabbitBus : IBus
    {
        private readonly EasyNetQ.IBus _bus;

        public RabbitBus()
        {
            _bus = RabbitHutch.CreateBus("host=localhost");
        }
        public void Dispose()
        {
            if (_bus != null)
                _bus.Dispose();
        }

        public void Publish<T>(T message) where T : IMessage
        {
            using (var publishChannel = _bus.OpenPublishChannel())
            {
                publishChannel.Publish(message);
            }
        }

        public void Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : IMessage
        {
            _bus.Subscribe(subscriptionId, onMessage);
        }

        
        public void FuturePublish<T>(DateTime timeToRespond, T message) where T : IMessage
        {
            using (var publishChannel = _bus.OpenPublishChannel())
            {
                publishChannel.FuturePublish(timeToRespond, message);
            }
        }

        
    }
}
