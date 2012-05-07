using System;
using Cqrs.Commanding.ServiceModel;
using NServiceBus;
using Commands;


namespace ApplicationService
{
    /// <summary>
    /// NServiceBus message handler for messages transporting Cqrs commands.
    /// </summary>
    public class CqrsMessageHandler : IHandleMessages<Cqrs.Commanding.ICommand>
    {
        /// <summary>
        /// Command service which is injected by NServiceBus infrastructure.
        /// </summary>
        public ICommandService CommandService { get; set; }
        public IBus Bus { get; set; }

        public CqrsMessageHandler(ICommandService commandService)
        {
            if (commandService == null)
                throw new Exception("ICommandService cannot be null");

            CommandService = commandService;
        }

        public void Handle(Cqrs.Commanding.ICommand command)
        {
            try
            {
                CommandService.Execute(command);
                
                Bus.Return(ErrorCodes.None);
            }
            catch (Exception e)
            {
                Bus.Return(ErrorCodes.Fail);
            }
        }
    }
}