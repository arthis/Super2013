using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence.EventStore;
using EasyNetQ;
using EventStore;
using EventStore.Serialization;
using Super.Administration.Commands.AreaIntervento;
using Super.Administration.Events.AreaIntervento;
using Super.Administration.Handlers;
using Super.Administration.Projection;

namespace Super.Administration.AdministrationService
{
    public class Service : ICommandService
    {
        private const string AggregateIdKey = "AggregateId";
        private const string CommitVersionKey = "CommitVersion";
        private const string EventVersionKey = "EventVersion";
        private const string BusPrefixKey = "Bus.";
        private CommandHandlerService _commandHandlerService;
        private IBus bus;

        private readonly byte[] _encryptionKey = new byte[]
                                                     {
                                                         0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 0x9, 0xa, 0xb, 0xc, 0xd, 0xe, 0xf
                                                     };

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

            _commandHandlerService = new CommandHandlerService();
            _commandHandlerService.InitHandlers(eventRepository);

            bus = RabbitHutch.CreateBus("host=localhost");

            string subscriptionId = "Super";

            //Events
            //to dry
            bus.Subscribe<AreaInterventoCreated>(subscriptionId, evt => new AreaInterventoProjection().Handle(evt));
            bus.Subscribe<AreaInterventoUpdated>(subscriptionId, evt => new AreaInterventoProjection().Handle(evt));
            bus.Subscribe<AreaInterventoDeleted>(subscriptionId, evt => new AreaInterventoProjection().Handle(evt));
            
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
                    this.bus.Publish(busMessage);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        public CommandValidation Execute(ICommand command)
        {
            try
            {
                return _commandHandlerService.Execute(command);

            }
            catch (Exception e)
            {
                return new CommandValidation(new ValidationMessage(e.ToString()));
            }
        }
    }
}