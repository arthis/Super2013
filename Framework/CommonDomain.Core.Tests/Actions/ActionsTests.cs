using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CommonDomain.Core.Handlers.Actions;
using CommonDomain.Super;
using Machine.Specifications;

namespace CommonDomain.Core.Tests.Actions
{

    

    public class When_commandConstrainedOnlyAction_asks_can_execute_and_all_commands_are_ok
    {

        private static IEnumerable<Regex> _commands;
        private static ActionCommandConstrainedOnly<FakeCommandForActionTest> _action;
        private static bool _isExecuted;
            
            
        private Establish context = () =>
        {
            _commands = new List<Regex>() { new Regex(".*") };
            _action = new ActionCommandConstrainedOnly<FakeCommandForActionTest>() {CommandsAvailableToTheUser = _commands};
        };

        private Because of = () =>
            {
                _isExecuted = _action.CanBeExecuted();
            };

        private It should_be_executed = () => _isExecuted.ShouldBeTrue();

        private Cleanup after = () => _action = null;
    }

    public class When_ContextuallyConstrained_asks_can_execute_and_the_command_is_ok
    {

        private static IEnumerable<Regex> _commands;
        private static IEnumerable<Guid> _lotti;
        private static IEnumerable<Guid> _committenti;
        private static IEnumerable<Guid> _tipiIntervento;
        private static FakeCommandForActionTest _command;

        private static IAction _action;
        private static bool _isExecuted;


        private Establish context = () =>
        {
            _command = new FakeCommandForActionTest() { 
                IdLotto= Guid.NewGuid(),
                IdCommittente =   Guid.NewGuid(),
                IdTipoIntervento = Guid.NewGuid()
            };
            _commands = new List<Regex>() { new Regex(".*") };
            _lotti = new List<Guid>() {_command.IdLotto};
            _committenti = new List<Guid>() {_command.IdCommittente};
            _tipiIntervento = new List<Guid>() {_command.IdTipoIntervento};

            _action = new ActionContextuallyConstrained<FakeCommandForActionTest>()
                {
                    CommandToBeExecuted = _command,
                    CommandsAvailableToTheUser =_commands,
                    CommittentiAvailableToTheUser =_committenti,
                    LottiAvailableToTheUser = _lotti,
                    TipiInterventoAvailableToTheUser = _tipiIntervento
                };
        };
        
        private Because of = () =>
        {
            _isExecuted = _action.CanBeExecuted();
        };

        private It should_be_executed = () => _isExecuted.ShouldBeTrue();

        private Cleanup after = () => _action = null;
    }
}
