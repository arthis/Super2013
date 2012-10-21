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
                    var cmd = eventMessage.Body as ICommand;

                    //dispatch Command
                    if (cmd != null)
                    {
                        if (cmd.WakeTime.HasValue)
                            _bus.FuturePublish(cmd.WakeTime.Value, cmd);
                        else
                            _bus.Publish(cmd);
                    }

                    //dispatch event
                    var evt = eventMessage.Body as IEvent;
                    if(evt!=null)
                    {
                        _bus.Publish(evt);
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
