//using System;
//using System.Runtime.Serialization;
//using CommonDomain.Core.Handlers.Commands;
//using CommonDomain.Persistence;
//using Machine.Specifications;
//using Moq;
//using It = Machine.Specifications.It;

//namespace CommonDomain.Core.Tests
//{
//    public class when_a_command_is_executed_by_the_session_handler
//    {
//        static SecurityCommandHandler<MyMessage> sessionHandler ;
//        private static MyCommandHandlerWithSession<MyMessage> _commandHandlerWithSession;
//        static Guid securityToken = Guid.NewGuid();
//        private static Guid userId = Guid.NewGuid();

//        Establish context = () =>
//                                {
//                                    _commandHandlerWithSession = new MyCommandHandlerWithSession<MyMessage>();
//                                    var repo = new Mock<ISessionRepository>();
//                                    repo.Setup(x => x.GetSession(securityToken)).Returns(new Session(userId));
//                                    sessionHandler = new SecurityCommandHandler<MyMessage>(repo.Object, _commandHandlerWithSession);
//                                };

//        private Cleanup after = () => sessionHandler = null;

//        private Because of = () => sessionHandler.Execute(new MyMessage() {SecurityToken = securityToken});

//        It should_injects_the_session_into_the_final_handler = () =>
//                                                           {
//                                                               _commandHandlerWithSession.Session.ShouldNotBeNull();
//                                                               _commandHandlerWithSession.Session.UserId.ShouldEqual(userId);
//                                                           };
//    }
//}