using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using EventStore;

namespace CommonDomain.Core
{
    public class CommonDispatcher : IDispatcher
    {
        private readonly IBus _bus;

        public CommonDispatcher(IBus bus)
        {
            Contract.Requires(bus != null);

            _bus = bus;
        }

        public  void DispatchCommit(Commit commit)
        {
            Contract.Requires(commit != null);
            Contract.Requires(commit.Events != null);

            try
            {
                for (var i = 0; i < commit.Events.Count; i++)
                {
                    var eventMessage = commit.Events[i];
                    var busMessage = eventMessage.Body as IMessage;

                    if (busMessage != null)
                    {
                        if (busMessage.WakeTime.HasValue)
                            _bus.FuturePublish(busMessage.WakeTime.Value, busMessage);
                        else
                            _bus.Publish(busMessage);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
