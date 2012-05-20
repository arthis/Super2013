using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyNetQ;
using Super.Schedulazione.Events;

namespace Super.Saga.SagaService
{
    public class Service
    {
        private static IBus _bus;

        public void Init()
        {
            _bus = RabbitHutch.CreateBus("host=localhost");
            string subscriptionId = "Super";

            _bus.Subscribe<InterventoSchedulato>(subscriptionId, evt => new InterventoSagaHandler().Handle(evt));
        }

        public void Start()
        {
            Init();
        }
    }
}
