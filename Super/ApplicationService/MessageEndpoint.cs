using System.Linq;
using NServiceBus;
using Executors;
using Cqrs.Eventing.Storage.RavenDB;
using System.Reflection;
using Castle.Windsor;
using Cqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot;
using Castle.MicroKernel.Registration;
using Projection;
using Cqrs.Eventing.Sourcing.Snapshotting;
using Cqrs.Commanding.ServiceModel;
using Cqrs.Eventing.ServiceModel.Bus;
using System.Diagnostics.Contracts;
using System;
using Cqrs.Commanding.CommandExecution.Mapping.Attributes;
using Cqrs.Eventing.Storage;
using Cqrs.Commanding;
using Domain.Interventi;
using Cqrs.Domain.Storage;
using Cqrs.Domain;
using Cqrs.Commanding.CommandExecution;
using Commands.AreaIntervento;
using Executors.TipoIntervento;
using Projection.InProcessEventBus;

namespace ApplicationService
{
    public class MessageEndpoint : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        static IWindsorContainer _Container;

       

        public void Init()
        {
            _Container = new WindsorContainer();
            var db = new RavenDBEventStore("http://mercurio:8080/databases/Super2013");
            var ss = new RavenDBSnapshotStore("http://mercurio:8080/databases/Super2013");

            Assembly asm = Assembly.LoadFrom("Domain.dll");
            _Container.AddFacility(new DynamicSnapshotFacility(asm));

            _Container.Register(
              Component.For<ISnapshottingPolicy>().ImplementedBy<SimpleSnapshottingPolicy>(),
              Component.For<IEventBus>().Instance(InitializeEventBus()),
              Component.For<IEventStore>().Instance(db),
              Component.For<ISnapshotStore>().Instance(ss),
              Component.For<IKnownCommandsEnumerator>().ImplementedBy<AllCommandsInAppDomainEnumerator>(),
              Component.For<IAggregateRootCreationStrategy>().ImplementedBy<SimpleAggregateRootCreationStrategy>(),
              Component.For<IAggregateSupportsSnapshotValidator>().ImplementedBy<AggregateSupportsSnapshotValidator>(),
              Component.For<IAggregateSnapshotter>().ImplementedBy<DefaultAggregateSnapshotter>(),
              Component.For<IUnitOfWorkFactory>().ImplementedBy<UnitOfWorkFactory>(),
              Component.For<InterventoRot>().AsSnapshotable()
              );


            var assemblyCommand = typeof(CreareNuovoAreaIntervento).Assembly;
            _Container.Register(AllTypes.FromAssembly(assemblyCommand)
                                        .BasedOn(typeof(IEventHandler<>))
                                        .WithService.Self()
                               );

            var assemblyProjection = typeof(AreaInterventoProjection).Assembly;
            _Container.Register(AllTypes.FromAssembly(assemblyProjection)
                                        .BasedOn(typeof(IEventHandler<>))
                                        .WithService.Self()
                               );

            var assemblyExecutors = typeof(CreareAreaInterventoExecutor).Assembly;
            _Container.Register(AllTypes.FromAssembly(assemblyExecutors)
                                        .BasedOn(typeof(ICommandExecutor<>))
                                        .WithService.Self()
                                );

            _Container.Register(Component.For<ICommandService>().Instance(InitializeCommandService()));


            Configure.With()
                     .DefaultBuilder()
                     .CastleWindsorBuilder(_Container)
                     //.BinarySerializer();
                     .MsmqTransport()
                     .PurgeOnStartup(true);

            
        }

        private ICommandService InitializeCommandService()
        {
            var executorsAssembly = typeof(CreareAreaInterventoExecutor).Assembly;

            var service = new Cqrs.Commanding.ServiceModel.CommandService();
            service.RegisterAllExplicitCommandExecutorsInAssembly(executorsAssembly, CreateInstance);
            //service.AddInterceptor(new ThrowOnExceptionInterceptor());

            return service;
        }

        private object CreateInstance(Type type)
        {
            Contract.Requires<ArgumentNullException>(type != null);
            object o = _Container.Resolve(type);
            return o;
        }

        private IEventBus InitializeEventBus()
        {
            var denormalizerAssembly = typeof(AreaInterventoProjection).Assembly;

            var compositeBus = new CompositeEventBus();
            compositeBus.AddBus(new NsbEventBus());
            compositeBus.AddBus(new InProcessEventBus(true));

            //bus.RegisterHandler(new InMemoryBufferedEventHandler(buffer));
            //compositeBus.RegisterAllHandlersInAssembly(denormalizerAssembly, CreateInstance);

            return compositeBus;
        }
    }
}
