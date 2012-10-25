using System;
using System.Configuration;
using System.ServiceModel;
using CommandService;
using CommonDomain.Core;
using CommonDomain.Persistence.EventStore;
using EasyNetQ;
using EventStore;
using EventStore.Persistence.SqlPersistence.SqlDialects;
using Super.Controllo.Handlers;
using Super.Controllo.Projection;

namespace Super.Controllo.ControlloService
{
    class Program
    {
        static void Main(string[] args)
        {

            var bus = RabbitHutch.CreateBus("host=localhost");
            var projectionHandlerSync = new ProjectionHandlerSyncService();
            var projectionRepositoryBuilderSync = new ProjectionRepositoryBuilder();
            projectionHandlerSync.InitHandlers(projectionRepositoryBuilderSync);
            var syncDispatcher = new SyncDispatcher(projectionHandlerSync, bus);

            var storeEvents = Wireup.Init()
                .LogToOutputWindow()
                .UsingSqlPersistence("EventStore")
                .WithDialect(new MsSqlDialect())
                .InitializeStorageEngine()
                .UsingJsonSerialization()
                //.Compress()
                //.EncryptWith(_encryptionKey)
                .HookIntoPipelineUsing(new[] { new AuthorizationPipelineHook() })
                .UsingSynchronousDispatchScheduler()
                .DispatchTo(new DelegateMessageDispatcher(syncDispatcher.DispatchCommit))
                .Build();
            var aggregateFactory = new AggregateFactory();
            var conflictDetector = new ConflictDetector();
            var eventRepository = new EventStoreRepository(storeEvents, aggregateFactory, conflictDetector);




            var sessionRepository = new SessionRepository();
            var commandRepository = new SqlServerCommandRepository(ConfigurationManager.ConnectionStrings["EventStore"].ToString());
            var sessionFactory = new CommonSessionFactory(sessionRepository);

            var commandHandlerService = new CommandHandlerService<CommonSession>();
            commandHandlerService.Subscribe(bus);
            commandHandlerService.InitCommandHandlers(commandRepository, eventRepository, sessionFactory);


            var projectionHandler = new ProjectionHandlerAsyncService();
            var projectionRepositoryBuilder = new ProjectionRepositoryBuilder();
            projectionHandler.InitHandlers(projectionRepositoryBuilder, bus);

            var commandWebService = new CommandWebService<CommonSession>(commandHandlerService);




            using (var commandServiceHost = new ServiceHost(commandWebService))
            {
                commandServiceHost.Open();
                Console.WriteLine("Controllo service started");
                var quitFlag = false;
                while (!quitFlag)
                {
                    var keyInfo = Console.ReadKey();
                    quitFlag = keyInfo.Key == ConsoleKey.C
                               && keyInfo.Modifiers == ConsoleModifiers.Control;
                }
            }

        }
    }
}
