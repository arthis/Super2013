using System.Configuration;
using Commands;
using Ncqrs;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.CommandService.Infrastructure;
using Ncqrs.EventBus;
using Ncqrs.Eventing.ServiceModel.Bus;
using Ncqrs.Eventing.Storage;
using Ncqrs.Eventing.Storage.SQL;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Ncqrs.Eventing.Sourcing.Snapshotting;
using Ncqrs.Config.Windsor;
using Ncqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot;
using System.Reflection;

namespace ApplicationService
{
    using Domain.Interventi;
    using ApplicationService.Executors;
    using Denormalizers;
    using System;
    using System.Diagnostics.Contracts;
    using Events;
    using Ncqrs.Eventing.Storage.RavenDB;
    using Mail;
    using Denormalizer;

    public static class BootStrapper
    {
        static IWindsorContainer _Container;

        //public static void BootUp(InMemoryBufferedBrowsableElementStore buffer)
        public static void BootUp()
        {
            //var connectionString = ConfigurationManager.ConnectionStrings["EventStore"].ConnectionString;

            //var dsa = new MsSqlServerEventStore(connectionString);
            var db = new RavenDBEventStore("http://localhost:8080/databases/Super2012");
            var ss = new RavenDBSnapshotStore("http://localhost:8080/databases/Super2012");


            Assembly asm = Assembly.LoadFrom("Domain.dll");
            _Container = new WindsorContainer();
            _Container.AddFacility("ncqrs.ds", new DynamicSnapshotFacility(asm));
            _Container.Register(Component.For<ISendMessage>().ImplementedBy<MailBox>());
            _Container.Register(Component.For<ConsuntivazioneResoDaAppaltatoreRejectedDenormalizer>().ImplementedBy<ConsuntivazioneResoDaAppaltatoreRejectedDenormalizer>());
            _Container.Register(Component.For<AreaInterventoDenormalizer>().ImplementedBy<AreaInterventoDenormalizer>());
            _Container.Register(
                Component.For<ISnapshottingPolicy>().ImplementedBy<SimpleSnapshottingPolicy>(),
                Component.For<ICommandService>().Instance(InitializeCommandService()),
                Component.For<IEventBus>().Instance(InitializeEventBus()),
                Component.For<IEventStore>().Instance(db),
                Component.For<ISnapshotStore>().Instance(ss),
                Component.For<IKnownCommandsEnumerator>().Instance(new AllCommandsInAppDomainEnumerator()),
                Component.For<InterventoRotabile>().AsSnapshotable()
                );


            WindsorConfiguration config = new WindsorConfiguration(_Container);

            NcqrsEnvironment.Configure(config);
        }

        private static ICommandService InitializeCommandService()
        {
            var commandAssembly = typeof(CreareNuovaCausale).Assembly;
            var executorsAssembly = typeof(ConsuntivareResoDaAppaltatoreExecutor).Assembly;

            var service = new CommandService();
            service.RegisterExecutorsInAssembly(commandAssembly);
            service.RegisterAllExplicitCommandExecutorsInAssembly(executorsAssembly);
            service.AddInterceptor(new ThrowOnExceptionInterceptor());

            return service;
        }

        private static object CreateInstance(Type type)
        {
            Contract.Requires<ArgumentNullException>(type != null);
            object o = _Container.Resolve(type);
            return o;
        }

        //private static IEventBus InitializeEventBus(InMemoryBufferedBrowsableElementStore buffer)
        private static IEventBus InitializeEventBus()
        {
            var denormalizerAssembly = typeof(ConsuntivazioneResoDaAppaltatoreRejectedDenormalizer).Assembly;

            var bus = new InProcessEventBus();

            //bus.RegisterHandler(new InMemoryBufferedEventHandler(buffer));
            bus.RegisterAllHandlersInAssembly(denormalizerAssembly, BootStrapper.CreateInstance);

            return bus;
        }
    }
}