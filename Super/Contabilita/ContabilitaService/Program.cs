using System;
using System.Configuration;
using System.ServiceModel;
using CommandService;
using CommonDomain.Core;
using CommonDomain.Persistence.EventStore;
using EasyNetQ;
using EventStore;
using EventStore.Persistence.SqlPersistence.SqlDialects;
using Super.Contabilita.Domain;
using Super.Contabilita.Handlers;
using Super.Contabilita.Handlers.Factories;
using Super.Contabilita.Projection;

namespace Super.Contabilita.ContabilitaService
{
    class Program
    {
        static void Main(string[] args)
        {



            var bus = RabbitHutch.CreateBus("host=localhost");
            var dispatcher = new CommonDispatcher(bus);

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
                .DispatchTo(new DelegateMessageDispatcher(dispatcher.DispatchCommit))
                .Build();
            var aggregateFactory = new AggregateFactory();
            var conflictDetector = new ConflictDetector();
            var eventRepository = new EventStoreRepository(storeEvents, aggregateFactory, conflictDetector);




            var sessionRepository = new SessionRepository();
            var commonSessionFactory = new CommonSessionFactory(sessionRepository);
            var commandRepository = new SqlServerCommandRepository(ConfigurationManager.ConnectionStrings["EventStore"].ToString());
            var sessionFactory = new ContabilitaSessionFactory(commonSessionFactory,eventRepository);

            var commandHandlerService = new CommandHandlerService<SessionContabilita>();
            commandHandlerService.Subscribe(bus);
            commandHandlerService.InitCommandHandlers(commandRepository, eventRepository, sessionFactory);


            var projectionHandler = new ProjectionHandlerService();
            var projectionRepositoryBuilder = new ProjectionRepositoryBuilder();
            projectionHandler.InitHandlers(projectionRepositoryBuilder, bus);

            var commandWebService = new CommandWebService<SessionContabilita>(commandHandlerService);




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
