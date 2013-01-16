using System;
using System.Diagnostics.Contracts;
using EventStore;
using CommonDomain.Persistence;

namespace CommonDomain.Core
{
    public class SyncDispatcher : IDispatcher
    {
        private readonly IProjectionHandlerSyncService _projectionHandler;
        private readonly IBus _bus;


        public SyncDispatcher(IProjectionHandlerSyncService projectionHandler, IBus bus)
        {
            Contract.Requires(projectionHandler != null);

            _projectionHandler = projectionHandler;
            _bus = bus;
        }

        public void DispatchCommit(Commit commit)
        {
            Contract.Requires(commit != null);
            Contract.Requires(commit.Events != null);

            try
            {
                for (var i = 0; i < commit.Events.Count; i++)
                {
                    var eventMessage = commit.Events[i];

                    SyncDispatch(eventMessage);
                    AsyncDispatch(eventMessage);
                   
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void SyncDispatch(EventMessage eventMessage)
        {
            //dispatch event
            var evt = eventMessage.Body as IEvent;
            if (evt != null && _projectionHandler.IsHandled(evt))
            {
                _projectionHandler.Execute(evt);
            }
        }

        private void AsyncDispatch(EventMessage eventMessage)
        {
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
            if (evt != null)
            {
                _bus.Publish((dynamic)evt);
            }
        }


    }
}