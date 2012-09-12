using System;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace CommonDomain.Core.Tests
{
    public class when_a_command_is_executed_by_the_session_handler_and_the_token_is_known
    {
        static SessionCommandHandler<MyMessage> sessionHandler;
        private static MyFinalHandler<MyMessage> finalHandler;
        static Guid securityToken = Guid.NewGuid();
        static Guid wrongSecurityToken = Guid.NewGuid();
        private static Guid userId = Guid.NewGuid();
        private static Exception exception; 

        
        Establish context = () =>
                                {
                                    finalHandler = new MyFinalHandler<MyMessage>();
                                    var repo = new Mock<ISessionRepository>();
                                    repo.Setup(x => x.GetSession(securityToken)).Returns(new Session(userId));
                                    sessionHandler = new SessionCommandHandler<MyMessage>(repo.Object, finalHandler);
                                };

        private Cleanup after = () => sessionHandler = null;

        private Because of = () => exception = Catch.Exception (()=> sessionHandler.Execute(new MyMessage() { SecurityToken = wrongSecurityToken }));

        It should_raise_an_exception = () => exception.ShouldNotBeNull();
    }
}