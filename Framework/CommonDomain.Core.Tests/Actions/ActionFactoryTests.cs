using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CommonDomain.Core.Handlers.Actions;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;
using MIt = Moq.It;


namespace CommonDomain.Core.Tests.Actions
{
    public class When_action_factory_is_created_without_action_repository
    {
        private static ActionFactory _actionFactory;
        private static Exception _exception;

        Establish context = () =>
        {
            
        };

        private Because of = () =>
            {
                _exception= Catch.Exception(() => _actionFactory = new ActionFactory(null));
            };

        private It should_have_thrown_an_exception = () => _exception.ShouldNotBeNull();
        private It and_should_be_an_ArgumentNullException  = () => _exception.ShouldBeOfType<ArgumentNullException>();

        private Cleanup after = () => { };
    }

    public class When_action_factory_is_created_with_action_repository
    {
        private static ActionFactory _actionFactory;
        private static Exception _exception;
        private static Mock<IActionHandler> _actionHandler;

        Establish context = () =>
        {
            _actionHandler = new Mock<IActionHandler>();
        };

        private Because of = () =>
            {
                _exception= Catch.Exception(() => _actionFactory = new ActionFactory(_actionHandler.Object));
            };

        private It should_not_throw_an_exception = () => _exception.ShouldBeNull();
        private It should_acknowledge_its_construction  = () => _actionFactory.ShouldNotBeNull();

        private Cleanup after = () => { };
    }

    public class When_action_factory_creates_action
    {
        private static ActionFactory _actionFactory;
        private static Exception _exception;
        private static Mock<IActionHandler> _actionHandler;
        private static FakeCommandForActionTest _commandToBeExecuted;
        private static IAction _action;

        Establish context = () =>
        {
            _actionHandler = new Mock<IActionHandler>();
            _actionHandler.Setup(x => x.ContainsKey(MIt.IsAny<string>())).Returns(true);
            _actionFactory = new ActionFactory(_actionHandler.Object);
            _commandToBeExecuted= new FakeCommandForActionTest();
        };

        private Because of = () =>
            {
                _action = _actionFactory.CreateAction(_commandToBeExecuted);
            };

        private It should_check_if_it_exists = () => _actionHandler.Verify(x=> x.ContainsKey(_commandToBeExecuted.GetType().ToString()));
        private It should_gives_the_action = () => _actionHandler.Verify(x=> x.GetAction(_commandToBeExecuted.GetType().ToString()));

        private Cleanup after = () => { };
    }

    public class When_action_factory_creates_action_for_an_unknown_command
    {
        private static ActionFactory _actionFactory;
        private static Exception _exception;
        private static Mock<IActionHandler> _actionHandler;
        private static FakeCommandForActionTest _commandToBeExecuted;
        private static IAction _action;

        Establish context = () =>
        {
            _actionHandler = new Mock<IActionHandler>();
            _actionHandler.Setup(x => x.ContainsKey(MIt.IsAny<string>())).Returns(false);
            _actionFactory = new ActionFactory(_actionHandler.Object);
            _commandToBeExecuted= new FakeCommandForActionTest();
        };

        private Because of = () =>
            {
                _exception = Catch.Exception(() =>  _actionFactory.CreateAction(_commandToBeExecuted));
            };

        private It should_throw_an__exception = () => _exception.ShouldNotBeNull();
        private It of_type_ArgumentException = () => _exception.ShouldBeOfType<ArgumentException>();

        private Cleanup after = () => { };
    }

    public class When_action_factory_creates_a_CommandContrainedAction
    {
        private static ActionFactory _actionFactory;
        private static Exception _exception;
        private static Mock<IActionHandler> _actionHandler;
        private static FakeCommandForActionTest _commandToBeExecuted;
        private static IAction _action;
        private static IEnumerable<Regex> _commands;



        Establish context = () =>
        {
            _actionHandler = new Mock<IActionHandler>();
            _actionHandler.Setup(x => x.ContainsKey(MIt.IsAny<string>())).Returns(true);
            _actionHandler.Setup(x => x.GetAction(MIt.IsAny<string>())).Returns(new ActionCommandConstrainedOnly<FakeCommandForActionTest>());
            _actionFactory = new ActionFactory(_actionHandler.Object);
            _commands = new List<Regex>(){ new Regex(".*")};
            _commandToBeExecuted = new FakeCommandForActionTest();
        };

        private Because of = () =>
        {
            _action = _actionFactory
                .WithCommands(_commands)
                .CreateAction(_commandToBeExecuted);
        };

        private It should_gives_an_action = () => _action.ShouldNotBeNull();
        private It of_type_ActionCommandConstrainedOnly = () => _action.ShouldBeOfType<ActionCommandConstrainedOnly<FakeCommandForActionTest>>();
        private It with_an_existing_arguments_commands = () => ((ActionCommandConstrainedOnly<FakeCommandForActionTest>)_action).CommandsAvailableToTheUser.ShouldNotBeNull();
        private It commands_equals_the_one_provided_to_the_factory = () => ((ActionCommandConstrainedOnly<FakeCommandForActionTest>)_action).CommandsAvailableToTheUser.ShouldContainOnly(_commands);

        private Cleanup after = () => { };
    }

    public class When_action_factory_creates_a_ActionContextuallyConstrained
    {
        private static ActionFactory _actionFactory;
        private static Exception _exception;
        private static Mock<IActionHandler> _actionHandler;
        private static FakeCommandForActionTest _commandToBeExecuted;
        private static IAction _action;
        private static IEnumerable<Regex> _commands;
        private static IEnumerable<Guid> _committenti;
        private static IEnumerable<Guid> _lotti;
        private static IEnumerable<Guid> _tipiIntervento;



        Establish context = () =>
        {
            _actionHandler = new Mock<IActionHandler>();
            _actionHandler.Setup(x => x.ContainsKey(MIt.IsAny<string>())).Returns(true);
            _actionHandler.Setup(x => x.GetAction(MIt.IsAny<string>())).Returns(new ActionContextuallyConstrained<FakeCommandForActionTest>());
            _actionFactory = new ActionFactory(_actionHandler.Object);
            _commands = new List<Regex>() { new Regex(".*") };
            _commandToBeExecuted = new FakeCommandForActionTest();
            _commandToBeExecuted.IdCommittente = Guid.NewGuid();
            _commandToBeExecuted.IdLotto = Guid.NewGuid();
            _commandToBeExecuted.IdTipoIntervento = Guid.NewGuid();

            _committenti = new List<Guid>() { _commandToBeExecuted.IdCommittente };
            _lotti = new List<Guid>() { _commandToBeExecuted.IdLotto };
            _tipiIntervento = new List<Guid>() { _commandToBeExecuted.IdTipoIntervento };
        };

        private Because of = () =>
        {
            _action = _actionFactory
                .WithCommands(_commands)
                .WithCommittenti(_committenti)
                .WithLotti(_lotti)
                .WithTipiIntervento(_tipiIntervento)
                .CreateAction(_commandToBeExecuted);
        };

        private It should_gives_an_action = () => _action.ShouldNotBeNull();
        private It of_type_ActionContextuallyConstrained = () => _action.ShouldBeOfType<ActionContextuallyConstrained<FakeCommandForActionTest>>();
        private It with_an_existing_arguments_commands = () => ((ActionContextuallyConstrained<FakeCommandForActionTest>)_action).CommandsAvailableToTheUser.ShouldNotBeNull();
        private It commands_equals_the_one_provided_to_the_factory = () => ((ActionContextuallyConstrained<FakeCommandForActionTest>)_action).CommandsAvailableToTheUser.ShouldContainOnly(_commands);
        private It lotti_equals_the_one_provided_to_the_factory = () => ((ActionContextuallyConstrained<FakeCommandForActionTest>)_action).LottiAvailableToTheUser.ShouldContainOnly(_lotti);
        private It committenti_equals_the_one_provided_to_the_factory = () => ((ActionContextuallyConstrained<FakeCommandForActionTest>)_action).CommittentiAvailableToTheUser.ShouldContainOnly(_committenti);
        private It tipiIntervento_equals_the_one_provided_to_the_factory = () => ((ActionContextuallyConstrained<FakeCommandForActionTest>)_action).TipiInterventoAvailableToTheUser.ShouldContainOnly(_tipiIntervento);

        private Cleanup after = () => { };
    }

    
}
