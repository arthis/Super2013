using System;
using System.Linq;
using System.Reflection.Emit;
using Castle.DynamicProxy;
using Castle.MicroKernel.Facilities;
using Castle.Windsor;
using Cqrs.Commanding;
using Cqrs.Commanding.CommandExecution;
using Cqrs.Commanding.ServiceModel;
using Cqrs.Domain;
using Castle.Core;

namespace Cqrs.Config.Windsor
{
    public class WindsorCommandService : ICommandService
    {
        readonly IWindsorContainer _container;

        public WindsorCommandService(IWindsorContainer container)
        {
            _container = container;
        }

        public virtual void Execute(ICommand command)
        {
            var context = new CommandContext(command);
            var interceptors = _container.ResolveAll<ICommandServiceInterceptor>();
            try
            {
                
                interceptors.ToList().ForEach(i => i.OnBeforeBeforeExecutorResolving(context));


                var executor = GetExecutorForCommand(command);
                if (executor == null) throw new ExecutorForCommandNotFoundException(command.GetType());
                context = new CommandContext(command, CommandExecutionState.Resolved);
                interceptors.ToList().ForEach(i => i.OnBeforeExecution(context));
                executor.Execute((dynamic) command);
                context = new CommandContext(command, CommandExecutionState.Called);
            }
            catch (Exception ex)
            {
                context = new CommandContext(command, CommandExecutionState.Called, ex); 
                throw;
            }
            finally
            {
                interceptors.ToList().ForEach(i => i.OnAfterExecution(context));
            }
        }

        dynamic GetExecutorForCommand(ICommand command)
        {
            Type commandType = command.GetType();
            var exType = typeof(ICommandExecutor<>).MakeGenericType(commandType);
            return _container.Resolve(exType);
        }
    }
}