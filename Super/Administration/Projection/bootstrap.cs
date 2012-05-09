using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyNetQ;
using Super.Administration.Events.AreaIntervento;

namespace Super.Administration.Projection
{
    

    public class Rabbit
    {
        private readonly IBus _bus;

        public Rabbit(IBus bus)
        {
            _bus = bus;
        }

        public void Start()
        {

            string subscriptionId = "Super";
            //_bus.Subscribe<AreaInterventoCreated>(subscriptionId, msg => ExecutorMessage(msg));
        }

      
    }
}
