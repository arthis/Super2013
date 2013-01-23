using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CommonDomain.Core.Handlers.Actions;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace CommonDomain.Core.Tests.Actions
{
    public class When_action_handler_Contains__unknown_Key
    {
        private static IActionHandler _actionhandler;
        private static Exception _exception;
        private static bool _Contains;

        private Establish context = () =>
            {
                _actionhandler = new ActionHandler();
            };

        private Because of = () =>
            {
                _exception = Catch.Exception(() => _Contains= _actionhandler.ContainsKey("toto"));
            };

        private It should_not_raise_an_exception = () => _exception.ShouldBeNull();
        private It should_gives_false = () => _Contains.ShouldBeFalse();

        private Cleanup after = () => _actionhandler = null;
    }

    public class When_action_handler_Contains__known_Key
    {
        private static IActionHandler _actionhandler;
        private static Exception _exception;
        private static bool _Contains;

        private Establish context = () =>
        {
            _actionhandler = new ActionHandler();
            _actionhandler.AddCommandContrainedAction<FakeCommandForActionTest>();
        };

        private Because of = () =>
        {
            _exception = Catch.Exception(() => _Contains = _actionhandler.ContainsKey(typeof(FakeCommandForActionTest).ToString()));
        };

        private It should_not_raise_an_exception = () => _exception.ShouldBeNull();
        private It should_gives_true = () => _Contains.ShouldBeTrue();


        private Cleanup after = () => _actionhandler = null;
    }

    public class When_action_handler_AddCommandTypeConstrainedActionHandlerFor_FakeCommandForActionTest_and_execute_this_command
    {
        private static IActionHandler _actionhandler;
        private static Exception _exception;
        private static bool _Contains;
        private static IAction _action; 

        private Establish context = () =>
        {
            _actionhandler = new ActionHandler();
            _actionhandler.AddCommandContrainedAction<FakeCommandForActionTest>();
        };

        private Because of = () =>
            {
                _action = _actionhandler.GetAction(typeof(FakeCommandForActionTest).ToString());
            };

        private It should_gives_a_function_to_create_the_action = () => _action.ShouldNotBeNull();
        

    }
}
