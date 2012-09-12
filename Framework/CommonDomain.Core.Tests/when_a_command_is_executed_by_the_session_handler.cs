using System;
using System.Runtime.Serialization;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace CommonDomain.Core.Tests
{
    public class when_a_command_is_executed_by_the_session_handler
    {
        static SessionCommandHandler<MyMessage> sessionHandler ;
        private static MyFinalHandler<MyMessage> finalHandler;
        static Guid securityToken = Guid.NewGuid();
        private static Guid userId = Guid.NewGuid();

        Establish context = () =>
                                {
                                    finalHandler = new MyFinalHandler<MyMessage>();
                                    var repo = new Mock<ISessionRepository>();
                                    repo.Setup(x => x.GetSession(securityToken)).Returns(new Session(userId));
                                    sessionHandler = new SessionCommandHandler<MyMessage>(repo.Object, finalHandler);
                                };

        private Cleanup after = () => sessionHandler = null;

        private Because of = () => sessionHandler.Execute(new MyMessage() {SecurityToken = securityToken});

        It should_injects_the_session_into_the_final_handler = () =>
                                                           {
                                                               finalHandler.Session.ShouldNotBeNull();
                                                               finalHandler.Session.UserId.ShouldEqual(userId);
                                                           };
    }
}