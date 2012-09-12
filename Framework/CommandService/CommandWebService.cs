using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;
using EventStore;
using EventStore.Persistence.SqlPersistence.SqlDialects;
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
        

        protected IBus _bus;
        private ICommandHandlerService _commandHandler;
        private IProjectionHandlerService _projectionHandler;

        public CommandWebService(IBus bus, ICommandHandlerService commandHandlerService, IProjectionHandlerService projectionHandlerService)
        {
            _commandHandler = commandHandlerService;
            _projectionHandler = projectionHandlerService;
            _bus = bus;
        }


        private IStoreEvents WireupEventStore()
        {
            return Wireup.Init()
                .LogToOutputWindow()
                .UsingSqlPersistence("EventStore")
                .WithDialect(new MsSqlDialect())
                .InitializeStorageEngine()
                .UsingJsonSerialization()
                //.Compress()
                //.EncryptWith(_encryptionKey)
                .HookIntoPipelineUsing(new[] { new AuthorizationPipelineHook() })
                .UsingSynchronousDispatchScheduler()
                .DispatchTo(new DelegateMessageDispatcher(DispatchCommit))
                .Build();
        }

       private ICommandRepository GetCommandRepository()
       {
           return new SqlServerCommandRepository(ConfigurationManager.ConnectionStrings["EventStore"].ToString());
       }

       

        public void Init()
        {
            var storeEvents = WireupEventStore();
            var aggregateFactory = new AggregateFactory();
            var conflictDetector = new ConflictDetector();
            var eventRepository = new EventStoreRepository(storeEvents, aggregateFactory, conflictDetector);
            var projectionRepositoryBuilder = new ProjectionRepositoryBuilder();

            _commandHandler.InitHandlers(GetCommandRepository(), eventRepository);
            _commandHandler.Subscribe(_bus);
            _projectionHandler.InitHandlers(projectionRepositoryBuilder);
            _projectionHandler.Subscribe(_bus);
        }



        public ExecuteResponse Execute(CommandBase command)
        {
            Contract.Requires(command != null);
            Contract.Ensures(Contract.Result<ExecuteResponse>() != null);

            try
            {
                var validation = _commandHandler.Execute(command);
                return new ExecuteResponse(validation);
            }
            catch (Exception ex)
            {
                return new ExecuteResponse( new CommandValidation(new ValidationMessage("Error",ex.ToString())));
            }

        }

        
        private void DispatchCommit(Commit commit)
        {
            try
            {
                for (var i = 0; i < commit.Events.Count; i++)
                {
                    var eventMessage = commit.Events[i];
                    var busMessage = eventMessage.Body as IMessage;
                   _bus.Publish(busMessage);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        public string Login(string username, string password)
        {
            return Guid.NewGuid().ToString();
        }
    }


}