﻿using log4net.Config;
using Topshelf;

namespace EasyNetQ.SagaHost
{
    class Program
    {
        // The name of the folder under the service's bin directory where saga assemblies and their dependencies
        // should be dropped.
        private const string sagaDirectory = "Sagas";

        static void Main()
        {
            XmlConfigurator.Configure();

            HostFactory.Run(hostConfiguration =>
            {
                hostConfiguration.RunAsLocalSystem();
                hostConfiguration.SetDescription("EasyNetQ.SagaHost");
                hostConfiguration.SetDisplayName("EasyNetQ.SagaHost");
                hostConfiguration.SetServiceName("EasyNetQ.SagaHost");

                hostConfiguration.Service<ISagaHost>(serviceConfiguration =>
                {
                    serviceConfiguration.SetServiceName("SagaHostingService");
                    serviceConfiguration.ConstructUsing(name => SagaHostFactory.CreateSagaHost(sagaDirectory));

                    serviceConfiguration.WhenStarted(sagaHostingService => sagaHostingService.Start());
                    serviceConfiguration.WhenStopped(sagaHostingService => sagaHostingService.Stop());
                });
            });
        }
    }
}
