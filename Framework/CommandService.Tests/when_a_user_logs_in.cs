using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace CommandService.Tests
{
    //public class when_a_user_logs_in
    //{
    //    static CommandWebService<IAction> _commandWebService;
    //    private static string _username = "username";
    //    private static string _password = "password";
    //    private static string _tokenId ;

    //    Establish context = () =>
    //                            {
    //                                var bus = new Mock<IBus>();
    //                                var handler = new Mock<ICommandHandlerService<IAction>>();
    //                                var projection = new Mock<IProjectionHandlerAsyncService>();
    //                                var sessionFactory = new Mock<IActionFactory<IAction>>();
    //                                _commandWebService = new CommandWebService<IAction>(handler.Object);
    //                            };

    //    private Cleanup after = () => _commandWebService = null;

    //    Because of = () => _tokenId = _commandWebService.Login(_username,_password);

    //    private It should_receive_a_security_token = () =>
    //                                                     {
    //                                                         _tokenId.ShouldNotBeEmpty();
    //                                                         _tokenId.ShouldNotBeNull();
    //                                                     };
    //}
}
