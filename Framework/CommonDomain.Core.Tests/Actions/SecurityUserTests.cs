using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CommonDomain.Core.Handlers.Actions;
using CommonDomain.Super;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;
using MIt = Moq.It ;

namespace CommonDomain.Core.Tests.Actions
{

    public class FakeCommandForActionTest : ICommand, IContextCommand
    {
        public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public string ToDescription()
        {
            throw new NotImplementedException();
        }

        public long? Version { get; private set; }
        public DateTime? WakeTime { get; private set; }
        public bool IsExecuted { get; private set; }
        public Guid SecurityToken { get; private set; }
        public Guid IdCommittente { get; set; }
        public Guid IdLotto { get; set; }
        public Guid IdTipoIntervento { get; set; }
    }

    public class When_security_user_is_created_with_idUser_commands_available_committenti_lotti_tipi_intervento
    {
        private static SecurityUser _user;
        private static Guid _idUser;
        private static IEnumerable<Guid> _committenti;
        private static IEnumerable<Guid> _lotti;
        private static IEnumerable<Guid> _tipiIntervento;
        private static IEnumerable<Regex> _commands;
        

        Establish context = () =>
            {
                _idUser = Guid.NewGuid();
                _committenti = new List<Guid>();
                _lotti = new List<Guid>();
                _tipiIntervento = new List<Guid>();
                _commands = new List<Regex>();
            };

        private Because of = () =>
        {
            _user = new SecurityUser(_idUser, _commands,_committenti,_lotti,_tipiIntervento);
        };

        private It should_acknowledge_its_construction = () => _user.ShouldNotBeNull();

        private Cleanup after = () => _user = null;
    }

    public class When_security_user_creates_action_with_no_factory_action
    {
        private static SecurityUser _user;
        private static Guid _idUser;
        private static IEnumerable<Guid> _committenti;
        private static IEnumerable<Guid> _lotti;
        private static IEnumerable<Guid> _tipiIntervento;
        private static IEnumerable<Regex> _commands;
        private static Mock<ICommand> _commandToBeExecuted;
        private static Exception _exception;
        


        Establish context = () =>
        {
            _idUser = Guid.NewGuid();
            _committenti = new List<Guid>();
            _lotti = new List<Guid>();
            _tipiIntervento = new List<Guid>();
            _commands = new List<Regex>();
            _user = new SecurityUser(_idUser, _commands, _committenti, _lotti, _tipiIntervento);
            _commandToBeExecuted = new Mock<ICommand>();
        };

        private Because of = () =>
            {
                _exception= Catch.Exception(() => _user.CreateAction(null, _commandToBeExecuted.Object));
            };

        private It should_have_thrown_an_exception = () => _exception.ShouldNotBeNull();
        private It and_should_be_an_ArgumentNullException  = () => _exception.ShouldBeOfType<ArgumentNullException>(); 

        private Cleanup after = () => _user = null;
    }

    public class When_security_user_creates_action_with_no_command
    {
        private static SecurityUser _user;
        private static Guid _idUser;
        private static IEnumerable<Guid> _committenti;
        private static IEnumerable<Guid> _lotti;
        private static IEnumerable<Guid> _tipiIntervento;
        private static IEnumerable<Regex> _commands;
        private static Mock<IActionHandler> _actionRepository;
        private static Exception _exception;
        


        Establish context = () =>
        {
            _idUser = Guid.NewGuid();
            _committenti = new List<Guid>();
            _lotti = new List<Guid>();
            _tipiIntervento = new List<Guid>();
            _commands = new List<Regex>();
            _user = new SecurityUser(_idUser, _commands, _committenti, _lotti, _tipiIntervento);
            _actionRepository = new Mock<IActionHandler>();
        };

        private Because of = () =>
            {
                _exception= Catch.Exception(() => _user.CreateAction<ICommand>(_actionRepository.Object, null));
            };

        private It should_have_thrown_an_exception = () => _exception.ShouldNotBeNull();
        private It and_should_be_an_ArgumentNullException  = () => _exception.ShouldBeOfType<ArgumentNullException>(); 

        private Cleanup after = () => _user = null;
    }

    public class When_security_user_creates_action
    {
        private static SecurityUser _user;
        private static Guid _idUser;
        private static IEnumerable<Guid> _committenti;
        private static IEnumerable<Guid> _lotti;
        private static IEnumerable<Guid> _tipiIntervento;
        private static IEnumerable<Regex> _commands;
        private static Mock<ICommand> _commandToBeExecuted;
        private static Mock<IActionHandler> IActionRepository;
        private static Exception _exception;
        private static IAction _action;
        

        Establish context = () =>
        {
            _idUser = Guid.NewGuid();
            _committenti = new List<Guid>();
            _lotti = new List<Guid>();
            _tipiIntervento = new List<Guid>();
            _commands = new List<Regex>();
            _user = new SecurityUser(_idUser, _commands, _committenti, _lotti, _tipiIntervento);
            _commandToBeExecuted = new Mock<ICommand>();
            IActionRepository = new Mock<IActionHandler>();

            IActionRepository.Setup(x => x.ContainsKey(typeof(ICommand).ToString())).Returns(true);
            IActionRepository.Setup(x => x.GetAction(typeof(ICommand).ToString())).Returns(new ActionCommandConstrainedOnly<ICommand>());
        };

        private Because of = () =>
            {
                _action = _user.CreateAction<ICommand>(IActionRepository.Object, _commandToBeExecuted.Object);

            };

        private It should_gives_an_action = () => _action.ShouldNotBeNull();
        private It should_gives_an_action_of_type_ActionCommandConstrainedOnly_ICommand= () => _action.ShouldBeOfType<ActionCommandConstrainedOnly<ICommand>>();

        private Cleanup after = () => _user = null;
    }

    public class When_security_user_creates_action_for_FakeCommandForActionTest
    {
        private static SecurityUser _user;
        private static Guid _idUser;
        private static IEnumerable<Guid> _committenti;
        private static IEnumerable<Guid> _lotti;
        private static IEnumerable<Guid> _tipiIntervento;
        private static IEnumerable<Regex> _commands;
        private static FakeCommandForActionTest _commandToBeExecuted;
        private static IActionHandler _actionHandler;
        private static Exception _exception;
        private static IAction _action;

        Establish context = () =>
        {
            _commandToBeExecuted = new FakeCommandForActionTest();
            _commandToBeExecuted.IdCommittente = Guid.NewGuid();
            _commandToBeExecuted.IdLotto = Guid.NewGuid();
            _commandToBeExecuted.IdTipoIntervento = Guid.NewGuid();

            _idUser = Guid.NewGuid();
            _committenti = new List<Guid>() {_commandToBeExecuted.IdCommittente};
            _lotti = new List<Guid>() {_commandToBeExecuted.IdLotto};
            _tipiIntervento = new List<Guid>() {_commandToBeExecuted.IdTipoIntervento};
            _commands = new List<Regex>() {new Regex(".*")};
            _user = new SecurityUser(_idUser, _commands, _committenti, _lotti, _tipiIntervento);

            _actionHandler = new ActionHandler();
            _actionHandler.AddCommandContrainedAction<FakeCommandForActionTest>();
            

        };

        private Because of = () =>
            {
                _action = _user.CreateAction(_actionHandler, _commandToBeExecuted);
            };  

        private It should_gives_an_action = () => _action.ShouldNotBeNull();
        private It this_action_should_be_executed = () => _action.CanBeExecuted().ShouldBeTrue();

        private Cleanup after = () => _user = null;
    }
}
