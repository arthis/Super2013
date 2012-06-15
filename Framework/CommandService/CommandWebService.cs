using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence.EventStore;
using EventStore;
using EventStore.Serialization;

namespace CommandService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CommandWebService : ICommandWebService
    {
        protected const string AggregateIdKey = "AggregateId";
        protected const string CommitVersionKey = "CommitVersion";
        protected const string EventVersionKey = "EventVersion";
        protected const string BusPrefixKey = "Bus.";
        private readonly byte[] _encryptionKey = new byte[]
                                                     {
                                                         0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 0x9, 0xa, 0xb, 0xc, 0xd, 0xe, 0xf
                                                     };

        protected IBus _bus;
        private ICommandHandlerService _commandHandler;
        private IProjectionHandlerService _projectionHandler;

        public CommandWebService(IBus bus, ICommandHandlerService commandHandlerService, IProjectionHandlerService projectionHandlerService)
        {

            _commandHandler = commandHandlerService;
            _projectionHandler = projectionHandlerService;
            _bus = bus;
            //do not know if it is really the place to do that....
            Init();
        }

      


        private IStoreEvents WireupEventStore()
        {
            return Wireup.Init()
                .LogToOutputWindow()
                .UsingMongoPersistence("EventStore", new DocumentObjectSerializer())
                .InitializeStorageEngine()
                .UsingJsonSerialization()
                .Compress()
                .EncryptWith(_encryptionKey)
                .HookIntoPipelineUsing(new[] { new AuthorizationPipelineHook() })
                .UsingSynchronousDispatchScheduler()
                .DispatchTo(new DelegateMessageDispatcher(DispatchCommit))
                .Build();

        }

        public void Init()
        {
            var storeEvents = WireupEventStore();
            var aggregateFactory = new AggregateFactory();
            var conflictDetector = new ConflictDetector();
            var eventRepository = new EventStoreRepository(storeEvents, aggregateFactory, conflictDetector);

            _commandHandler.InitHandlers(eventRepository);
            _commandHandler.Subscribe(_bus);
            _projectionHandler.Subscribe(_bus);
        }


        
        public ExecuteResponse Execute(ExecuteRequest executeRequest)
        {
            Contract.Requires(executeRequest != null);
            Contract.Requires(executeRequest.CommandBase != null);
            Contract.Ensures(Contract.Result<ExecuteResponse>() != null);
            //Contract.EnsuresOnThrow<FaultException<CommandWebServiceFault>>(Contract.Result<ExecuteResponse>() == null);

            try
            {
                var validation = _commandHandler.Execute(executeRequest.CommandBase);
                return new ExecuteResponse(validation);
            }
            catch (Exception ex)
            {
                return new ExecuteResponse( new CommandValidation(new ValidationMessage(ex.ToString())));
            }

        }

        private static void AppendHeaders(IMessage message, IEnumerable<KeyValuePair<string, object>> headers)
        {
            headers = headers.Where(x => x.Key.StartsWith(BusPrefixKey));
            foreach (var header in headers)
            {
                var key = header.Key.Substring(BusPrefixKey.Length);
                var value = (header.Value ?? string.Empty).ToString();
                message.SetHeader(key, value);
            }
        }

        private static void AppendVersion(Commit commit, int index)
        {
            var busMessage = commit.Events[index].Body as IMessage;
            busMessage.SetHeader(AggregateIdKey, commit.StreamId.ToString());
            busMessage.SetHeader(CommitVersionKey, commit.StreamRevision.ToString());
            busMessage.SetHeader(EventVersionKey, GetSpecificEventVersion(commit, index).ToString());
        }

        private static int GetSpecificEventVersion(Commit commit, int index)
        {
            // e.g. (StreamRevision: 120) - (5 events) + 1 + (index @ 4: the last index) = event version: 120
            return commit.StreamRevision - commit.Events.Count + 1 + index;
        }

        private void DispatchCommit(Commit commit)
        {
            try
            {
                for (var i = 0; i < commit.Events.Count; i++)
                {
                    var eventMessage = commit.Events[i];
                    var busMessage = eventMessage.Body as IMessage;
                    AppendHeaders(busMessage, commit.Headers); // optional
                    AppendHeaders(busMessage, eventMessage.Headers); // optional
                    AppendVersion(commit, i); // optional
                    _bus.Publish(busMessage);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        
    }


}