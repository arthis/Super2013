//using System.Configuration;
//using Commands;
//using Ncqrs;
//using Ncqrs.Commanding;
//using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
//using Ncqrs.Commanding.ServiceModel;
//using Ncqrs.CommandService.Infrastructure;
//using Ncqrs.EventBus;
//using Ncqrs.Eventing.ServiceModel.Bus;
//using Ncqrs.Eventing.Storage;
//using Ncqrs.Eventing.Storage.SQL;
//using Ncqrs.Eventing.Sourcing.Snapshotting;
//using Ncqrs.Config.Ninject;
//using Ninject;
//using Ncqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot;
//using System.Reflection;
 
//namespace ApplicationService
//{
//    using Domain;
//    using ApplicationService.Executors;
//    using Denormalizers;
//    using Mail;
//    using System;
//    using System.Diagnostics.Contracts;

//    public class BootStrap : Ninject.Modules.NinjectModule
//    {
//        public override void Load()
//        {

//            //Bind<ICDCRepository>().To<CDCRepository>();
//                //DynamicSnapshotFacility
//        }
//    }

//    public static class BootStrapperNInject
//    {
//        static StandardKernel _Container;

       

//        public static void BootUp(InMemoryBufferedBrowsableElementStore buffer)
//        {
//            var connectionString = ConfigurationManager.ConnectionStrings["EventStore"].ConnectionString;
//            var asd = new MsSqlServerEventStore(connectionString);
//            var dsa = new MsSqlServerEventStore(connectionString);

//            Assembly asm = Assembly.LoadFrom("Domain.dll");
//            _Container = new StandardKernel(new BootStrap());
            
            
//            //_Container.AddFacility("ncqrs.ds", new DynamicSnapshotFacility(asm));
//            //_Container.Register(Component.For<MailBox>());
//            //_Container.Register(Component.For<ConsuntivazioneDenormalizer>());
//            //_Container.Register(
//            //    Component.For<ISnapshottingPolicy>().ImplementedBy<SimpleSnapshottingPolicy>(),
//            //    Component.For<ICommandService>().Instance(InitializeCommandService()),
//            //    Component.For<IEventBus>().Instance(InitializeEventBus(buffer)),
//            //    Component.For<IEventStore>().Forward<ISnapshotStore>().Instance(dsa),
//            //    Component.For<IKnownCommandsEnumerator>().Instance(new AllCommandsInAppDomainEnumerator()),
//            //    Component.For<Intervento>().AsSnapshotable()
//            //    );

//            NinjectConfiguration config = new NinjectConfiguration(_Container);

//            NcqrsEnvironment.Configure(config);
//        }

//        private static ICommandService InitializeCommandService()
//        {
//            var commandAssembly = typeof(ConsuntivareDaAppaltatore).Assembly;
//            var executorsAssembly = typeof(ConsuntivareDaAppaltatoreExecutor).Assembly;

//            var service = new CommandService();
//            service.RegisterExecutorsInAssembly(commandAssembly);
//            service.RegisterAllExplicitCommandExecutorsInAssembly(executorsAssembly);
//            service.AddInterceptor(new ThrowOnExceptionInterceptor());

//            return service;
//        }

//        private  static object CreateInstance(Type type)
//        {
//            //Contract.Requires<ArgumentNullException>(type != null);
//            object o  = _Container.Resolve(type);
//            return o;
//        }

//        private static IEventBus InitializeEventBus(InMemoryBufferedBrowsableElementStore buffer)
//        {
//            var denormalizerAssembly = typeof(ConsuntivazioneDenormalizer).Assembly;

//            var bus = new InProcessEventBus();

//            bus.RegisterHandler(new InMemoryBufferedEventHandler(buffer));
//            bus.RegisterAllHandlersInAssembly(denormalizerAssembly, BootStrapper.CreateInstance);

//            return bus;
//        }
//    }
//}