using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;
using Cqrs.Commanding.ServiceModel;
using System.Diagnostics.Contracts;

namespace ApplicationService
{

    //public class CommandHandler : IHandleMessages<Cqrs.Commanding.ICommand>
    //{
    //    public readonly ICommandService _CommandService;

    //    public CommandHandler()
    //    {
    //    }

    //    public CommandHandler(ICommandService commandService)
    //    {
    //        Contract.Requires(commandService != null);

    //        _CommandService = commandService;

    //    }

    //    public  void Handle(Cqrs.Commanding.ICommand command)
    //    {
    //        //try
    //        //{
    //            _CommandService.Execute(command);
    //        //}
    //        //catch (Exception ex)
    //        //{

    //        //    throw new FaultException<CommandWebServiceFault>(
    //        //        new CommandWebServiceFault(executeRequest.Command, ex), "An exception occured while trying to execute the command");
    //        //}
    //    }
    //}
}
