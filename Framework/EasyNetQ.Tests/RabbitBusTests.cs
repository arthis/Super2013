using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Actions;
using Machine.Specifications;
using NUnit.Framework;
using Newtonsoft.Json;

namespace EasyNetQ.Tests
{
    [TestFixture]
    public class SerializationTests
    {
        public class MyMessage : IMessage
        {
            public Guid Id
            {
                get ; set; 
            }
            public Guid CommitId
            {
                get;
                set; 
            }
            public DateTime Date { get; set; }

            public string ToDescription()
            {
                throw new NotImplementedException();
            }
        }

      


        public class when_a_user_handles_a_known_type_command
        {
            static IAction _action;
            private static ISecurityUser _securityUser;
            private static List<Regex> _commands = new List<Regex>();
            private static List<Guid> _committenti = new List<Guid>();
            private static List<Guid> _lotti = new List<Guid>();
            private static List<Guid> _tipiIntervento = new List<Guid>();
            private static IActionFactory _actionfactory;
            private static MyMessage _command;
            private static bool _canBeExecuted;

            Establish context = () =>
            {
                //_command = new MyCommand();
                //_commands.Add(new Regex(typeof(MyCommand).ToString()));
                //_actionfactory = new ActionFactory();
                //_actionfactory.AddCommandTypeConstrainedActionHandlerFor<MyCommand>();
                //_securityUser = new SecurityUser(Guid.NewGuid(), _commands, _committenti, _lotti, _tipiIntervento);

            };

            private Cleanup after = () => _action = null;

            private Because of = () =>
            {
                //_action = _securityUser.CreateAction(_actionfactory, _command);
                //_canBeExecuted = _action.CanBeExecuted();
            };

            private It should_acknowledge_its_execution = () => _canBeExecuted.ShouldBeTrue();

        }
    }
}
