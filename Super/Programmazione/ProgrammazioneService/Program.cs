﻿using System;
using System.Configuration;
using System.ServiceModel;
using CommandService;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Actions;
using CommonDomain.Persistence.EventStore;
using EventStore;
using EventStore.Persistence.SqlPersistence.SqlDialects;
using Super.Programmazione.Handlers;
using Super.Programmazione.Projection;

namespace Super.Programmazione.ProgrammazioneService
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
            var commandRepository = new SqlServerCommandRepository(ConfigurationManager.ConnectionStrings["EventStore"].ToString());
            var actionRepository = new ActionHandler();

            var commandHandlerService = new CommandHandlerService(userRepository);
            commandHandlerService.Subscribe(bus);
            commandHandlerService.InitCommandHandlers(commandRepository, eventRepository, actionRepository);


            var projectionHandler = new ProjectionHandlerAsyncService();
            var projectionRepositoryBuilder = new ProjectionRepositoryBuilder();
            projectionHandler.InitHandlers(projectionRepositoryBuilder, bus);

            var commandWebService = new CommandWebService(commandHandlerService);




            using (var commandServiceHost = new ServiceHost(commandWebService))
            {
                commandServiceHost.Open();
                Console.WriteLine("Programmazione service started");
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
