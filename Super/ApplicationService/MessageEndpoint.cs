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
using System.Configuration;

namespace ApplicationService
{
    public class MessageEndpoint : IConfigureThisEndpoint, AsA_Publisher, IWantCustomInitialization
    {
        static IWindsorContainer _Container;



        public void Init()
        {
            _Container = new WindsorContainer();
            string eventStoreConnectionString = ConfigurationManager.AppSettings["EventStore"];

            if (string.IsNullOrEmpty(eventStoreConnectionString))
                throw new Exception("eventStoreConnectionString not initialised");

            var db = new RavenDBEventStore(eventStoreConnectionString);
            var ss = new RavenDBSnapshotStore(eventStoreConnectionString);



            Configure.With()
                     .DefaultBuilder()
                     .CastleWindsorBuilder(_Container)
                     .DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("Events"))
                     .MsmqTransport()
                     .PurgeOnStartup(true)
                     .UnicastBus()
                     .CreateBus();

            Assembly asm = Assembly.LoadFrom("Domain.dll");
            _Container.AddFacility(new DynamicSnapshotFacility(asm));

            _Container.Register(
              Component.For<ISnapshottingPolicy>().ImplementedBy<SimpleSnapshottingPolicy>(),
              Component.For<IEventBus>().ImplementedBy<NsbEventBus>(),
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


    }
}
