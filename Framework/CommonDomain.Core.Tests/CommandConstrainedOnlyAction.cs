using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using CommonDomain.Core.Handlers.Actions;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace CommonDomain.Core.Tests
{
    public class when_a_user_handles_a_known_type_command
    {
        static IAction _action;
        private static ISecurityUser _securityUser;
        private static List<Regex> _commands = new List<Regex>();
        private static List<Guid> _committenti = new List<Guid>(); 
        private static List<Guid> _lotti = new List<Guid>();
        private static List<Guid> _tipiIntervento = new List<Guid>();
        private static IActionFactory _actionfactory;
        private static MyCommand _command;
        private static bool _canBeExecuted;

        Establish context = () =>
                                {
                                    _command = new MyCommand();
                                    _commands.Add(new Regex(typeof(MyCommand).ToString()));
                                    _actionfactory= new ActionFactory();
                                    _actionfactory.AddCommandConstrainedOnlyAction<MyCommand>();
                                    _securityUser = new SecurityUser(Guid.NewGuid(),_commands,_committenti,_lotti,_tipiIntervento);

                                };

        private Cleanup after = () => _action = null;

        private Because of = () =>
                                 {
                                     _action =_securityUser.CreateAction(_actionfactory, _command);
                                     _canBeExecuted = _action.CanBeExecuted();
                                 };

        private It should_acknowledge_its_execution = () => _canBeExecuted.ShouldBeTrue();
                                                       
    }

    public class when_a_user_handles_a_unknown_type_command
    {
        static IAction _action;
        private static ISecurityUser _securityUser;
        private static List<Regex> _commands = new List<Regex>();
        private static List<Guid> _committenti = new List<Guid>();
        private static List<Guid> _lotti = new List<Guid>();
        private static List<Guid> _tipiIntervento = new List<Guid>();
        private static IActionFactory _actionfactory;
        private static MyCommand _command;
        private static bool _canBeExecuted;

        Establish context = () =>
        {
            _command = new MyCommand();
            _commands.Add(new Regex( typeof(MyCommand).ToString()));
            _actionfactory = new ActionFactory();

            _securityUser = new SecurityUser(Guid.NewGuid(), _commands, _committenti, _lotti, _tipiIntervento);

        };

        private Cleanup after = () => _action = null;

        private It should_throw_an_exception = () => typeof(ArgumentException).ShouldBeThrownBy( ()=>_securityUser.CreateAction(_actionfactory, _command));

    }
}