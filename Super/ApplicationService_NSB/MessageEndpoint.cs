using NServiceBus;
using Executors;

namespace ApplicationService_NSB
{
    public class MessageEndpoint : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        public void Init()
        {
            var config = Configure.With()
                                   .DefaultBuilder()
                                   .BinarySerializer()
                                   .InstallNcqrs();

            var executorsAssembly = typeof(CreareAreaInterventoExecutor).Assembly;

            config.RegisterExecutorsForMappedCommandsInAssembly(executorsAssembly);

            config.MsmqTransport()
                  .PurgeOnStartup(true);
        }
    }
}
