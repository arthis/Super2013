using System;
using System.Configuration;
using System.ServiceModel;
using CommandService;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Actions;
using CommonDomain.Persistence.EventStore;
using EventStore;
using EventStore.Persistence.SqlPersistence.SqlDialects;
using Super.Contabilita.Handlers;
using Super.Contabilita.Projection;

namespace Super.Contabilita.ContabilitaService
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = new RabbitBus();
            
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




            var userRepository = new SecurityUserRepository();
            var commonSessionFactory = new ActionFactory();
            var commandRepository = new SqlServerCommandRepository(ConfigurationManager.ConnectionStrings["EventStore"].ToString());
            var actionFactory = new ActionFactory();

            

            var commandHandlerService = new CommandHandlerService(userRepository);
            commandHandlerService.Subscribe(bus);
            commandHandlerService.InitCommandHandlers(commandRepository, eventRepository, actionFactory);

            var projectionHandler = new ProjectionHandlerAsyncService();
            var projectionRepositoryBuilderAsync = new ProjectionRepositoryBuilder();
            projectionHandler.InitHandlers(projectionRepositoryBuilderAsync, bus);
            

            var commandWebService = new CommandWebService(commandHandlerService);

            using (var commandServiceHost = new ServiceHost(commandWebService))
            {
                commandServiceHost.Open();
                Console.WriteLine("Contabilita service started");
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
