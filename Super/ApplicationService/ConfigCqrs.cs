using System;
using Cqrs.Commanding;
using Cqrs.Commanding.CommandExecution;
using Cqrs.Commanding.ServiceModel;
using Cqrs.Eventing;
using Cqrs.Eventing.ServiceModel.Bus;
using NServiceBus;
using Cqrs.Commanding.CommandExecution.Mapping.Attributes;
using Cqrs;
using Cqrs.Eventing.Storage.RavenDB;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Cqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot;
using Projection;
using Cqrs.Eventing.Sourcing.Snapshotting;
using Cqrs.Eventing.Storage;
using Domain.Interventi;

namespace ApplicationService
{
    public class ConfigCqrs : Configure
    {
        private CommandService _commandService;
        private InProcessEventBus _inProcessEventBus;
        static IWindsorContainer _Container;

        public void Configure(Configure config)
        {
           

            Builder = config.Builder;
            Configurer = config.Configurer;
            

            CqrsEnvironment.Configure(new NsbEnvironmentConfiguration(Builder));
            
          
            CqrsEnvironment.SetDefault<IEventBus>(compositeBus);

            _commandService = new CommandService();
            config.Configurer.RegisterSingleton(typeof(ICommandService),
                                                _commandService);

          
        }

        /// <summary>
        /// Registers custom executor in Cqrs runtime.
        /// </summary>
        /// <typeparam name="TCommand">Type of command which will be affected.</typeparam>
        /// <param name="executor">Custom executor instance.</param>
        /// <returns>Self.</returns>
        public ConfigCqrs RegisterExecutor<TCommand>(ICommandExecutor<TCommand> executor) where TCommand : Cqrs.Commanding.ICommand
        {
            _commandService.RegisterExecutor(executor);
            return this;
        }

        /// <summary>
        /// Registers the executors for mapped commands in assembly.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns></returns>
        public ConfigCqrs RegisterExecutorsForMappedCommandsInAssembly(System.Reflection.Assembly assembly)
        {
            _commandService.RegisterExecutorsInAssembly(assembly);
            return this;
        }

        public ConfigCqrs RegisterAllExplicitCommandExecutorsInAssembly(System.Reflection.Assembly assembly)
        {
            _commandService.RegisterAllExplicitCommandExecutorsInAssembly(assembly);
            return this;
        }

        /// <summary>
        /// Register a handler that will receive all messages that are published.
        /// </summary>
        /// <param name="handler">The handler to register.</param>
        public ConfigCqrs RegisterInProcessEventHandler<TEvent>(IEventHandler<TEvent> handler) where TEvent : Cqrs.Eventing.IEvent
        {
            _inProcessEventBus.RegisterHandler(handler);
            return this;
        }


        /// <summary>
        /// Register a handler that will receive all messages that are published.
        /// </summary>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="handler">The handler to register.</param>
        public ConfigCqrs RegisterInProcessEventHandler(Type eventType, Action<Cqrs.Eventing.IEvent> handler)
        {
            _inProcessEventBus.RegisterHandler(eventType, handler);
            return this;
        }
    }
}