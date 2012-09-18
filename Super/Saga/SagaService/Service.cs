using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Persistence.EventStore;
using EventStore;
using EventStore.Persistence.SqlPersistence.SqlDialects;
using Super.Saga.Handlers;


namespace Super.Saga.SagaService
{
    public class Service
    {
        private readonly MessageHandlerService _messageHandlerService;
        private readonly IBus _bus;
        private readonly byte[] _encryptionKey = new byte[]
                                                     {
                                                         0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 0x9, 0xa, 0xb, 0xc, 0xd, 0xe, 0xf
                                                     };


        public Service(MessageHandlerService messageHandlerService,IBus bus)
        {
            _messageHandlerService = messageHandlerService;
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
                .Compress()
                .EncryptWith(_encryptionKey)
                .HookIntoPipelineUsing(new[] { new AuthorizationPipelineHook() })
                .UsingSynchronousDispatchScheduler()
                .Build();

        }

        public void Init()
        {

            var storeEvents = WireupEventStore();
            
            var repository = new SagaEventStoreRepository(storeEvents);

            _messageHandlerService.InitHandlers(repository, _bus);
            
        }

      

        public void Start()
        {
            Init();
        }
    }
}
