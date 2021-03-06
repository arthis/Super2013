//using System;
//using CommonDomain.Core.Handlers.Commands;
//using CommonDomain.Persistence;
//using Machine.Specifications;
//using Moq;
//using It = Machine.Specifications.It;

//namespace CommonDomain.Core.Tests
//{
//    public class when_a_command_is_executed_by_the_session_handler_and_the_token_is_known
//    {
//        static SecurityCommandHandler<MyMessage> sessionHandler;
//        private static MyCommandHandlerWithSession<MyMessage> _commandHandlerWithSession;
//        static Guid securityToken = Guid.NewGuid();
//        static Guid wrongSecurityToken = Guid.NewGuid();
//        private static Guid userId = Guid.NewGuid();
//        private static Exception exception; 

        
//        Establish context = () =>
//                                {
//                                    _commandHandlerWithSession = new MyCommandHandlerWithSession<MyMessage>();
//                                    var repo = new Mock<ISecurityUserRepository>();
//                                    repo.Setup(x => x.GetSecurityUser(securityToken)).Returns(new ActionFullyConstrained(userId));
//                                    sessionHandler = new SecurityCommandHandler<MyMessage>(repo.Object, _commandHandlerWithSession);
//                                };

//        private Cleanup after = () => sessionHandler = null;

//        private Because of = () => exception = Catch.Exception (()=> sessionHandler.Execute(new MyMessage() { SecurityToken = wrongSecurityToken }));

//        It should_raise_an_exception = () => exception.ShouldNotBeNull();
//    }
//}