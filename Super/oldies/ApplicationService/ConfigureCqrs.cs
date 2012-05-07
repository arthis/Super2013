using Cqrs;
using Cqrs.Commanding.CommandExecution.Mapping;
using ApplicationService;
using Executors;

namespace NServiceBus
{
    public static class ConfigureCqrs
    {
        /// <summary>
        /// Instructs NServiceBus to install Cqrs message handler. All <see cref="CommandMessage"/>s
        /// will be routed to Cqrs where they will be handled.
        /// 
        /// By default, all commands will be executed using <see cref="MappedCommandExecutor{TCommand}"/>.
        /// To customize this, you can use <see cref="ConfigCqrs.RegisterExecutor{TCommand}"/>.
        /// </summary>
        /// <param name="config">The config object.</param>
        /// <returns></returns>
        public static ConfigCqrs InstallCqrs(this Configure config)
        {
            var configCqrs = new ConfigCqrs();
            configCqrs.Configure(config);

            var executorsAssembly = typeof(CreareAreaInterventoExecutor).Assembly;

            configCqrs.RegisterAllExplicitCommandExecutorsInAssembly(executorsAssembly);
            return configCqrs;
        }
    }
}