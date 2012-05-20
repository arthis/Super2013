using System;
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
        private CommandHandlerService _commandHandlerService;
        private IBus _bus;

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

            _bus = RabbitHutch.CreateBus("host=localhost");

            string subscriptionId = "Super";

            //Events
            //to dry
            _bus.SubscribeToMessage(subscriptionId, typeof(AreaInterventoCreated), evt => new AreaInterventoProjection().Handle((AreaInterventoCreated)evt.PayLoad));
            _bus.SubscribeToMessage(subscriptionId, typeof(AreaInterventoUpdated), evt => new AreaInterventoProjection().Handle((AreaInterventoUpdated)evt.PayLoad));
            _bus.SubscribeToMessage(subscriptionId, typeof(AreaInterventoDeleted), evt => new AreaInterventoProjection().Handle((AreaInterventoDeleted)evt.PayLoad));
            
        }

        private void DispatchCommit(Commit commit)
        {
            try
            {
                foreach (var @event in commit.Events)
                {
                    var message = new Message() { CommitId = commit.CommitId,  PayLoad = (IEvent)@event.Body };

                    _bus.Publish(message, @event.Body.GetType());
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