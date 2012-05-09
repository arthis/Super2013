using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence.EventStore;
using EasyNetQ;
using EventStore;
using EventStore.Serialization;
using Super.Administration.Commands.AreaIntervento;
using Super.Administration.Handlers;

namespace Super.Administration.CommandService
{
	
	public class ServiceAdministration : IService
	{
        private CommandHandlerService _commandHandlerService;
        private IBus _bus;

        private readonly byte[] EncryptionKey = new byte[]
        {
            0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 0x9, 0xa, 0xb, 0xc, 0xd, 0xe, 0xf
        };

        private  IStoreEvents WireupEventStore()
        {
            return Wireup.Init()
               .LogToOutputWindow()
               .UsingMongoPersistence("EventStore", new DocumentObjectSerializer())
                   .InitializeStorageEngine()
                   .UsingJsonSerialization()
                       .Compress()
                       .EncryptWith(EncryptionKey)
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
        }

        private void DispatchCommit(Commit commit)
        {
            // This is where we'd hook into our messaging infrastructure, such as NServiceBus,
            // MassTransit, WCF, or some other communications infrastructure.
            // This can be a class as well--just implement IDispatchCommits.
            try
            {
                foreach (var @event in commit.Events)
                    _bus.Publish(@event);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

	    public ServiceAdministration()
	    {
            Init();
            string subscriptionId = "Super";

            _bus.Subscribe<CreateAreaIntervento>(subscriptionId, cmd => _commandHandlerService.Execute(cmd));
            _bus.Subscribe<UpdateAreaIntervento>(subscriptionId, cmd => _commandHandlerService.Execute(cmd));
            _bus.Subscribe<DeleteAreaIntervento>(subscriptionId, cmd => _commandHandlerService.Execute(cmd));
            ;
	    }

	    public CommandResponse Execute(ICommand composite)
	    {
	        throw new NotImplementedException();
	    }
	}
}
