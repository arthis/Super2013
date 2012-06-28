using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence.EventStore;
using EasyNetQ;
using EventStore;
using EventStore.Dispatcher;
using EventStore.Persistence.SqlPersistence.SqlDialects;
using EventStore.Serialization;
using Super.Saga.Handlers;
using Super.Programmazione.Events;

namespace Super.Saga.SagaService
{
    public class Service
    {
        private readonly MessageHandlerService _messageHandlerService; 
        private static IBus bus;
        private readonly byte[] _encryptionKey = new byte[]
                                                     {
                                                         0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 0x9, 0xa, 0xb, 0xc, 0xd, 0xe, 0xf
                                                     };


        public Service(MessageHandlerService messageHandlerService)
        {
            _messageHandlerService = messageHandlerService;
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
                .DispatchTo(new DelegateMessageDispatcher(DispatchCommit))
                .Build();

        }

        public void Init()
        {

            var storeEvents = WireupEventStore();
            
            var repository = new SagaEventStoreRepository(storeEvents);

            _messageHandlerService.InitHandlers(repository);
            _messageHandlerService.Subscribe();
        }

        private void DispatchCommit(Commit commit)
        {
            try
            {
                foreach (var @event in commit.Events)
                {
                    //var message = new Message() { CommitKey = commit.CommitKey, PayLoad = (IMessage)@event.Body };

                    //_bus.Publish(message, @event.Body.GetType());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Start()
        {
            Init();
        }
    }
}
