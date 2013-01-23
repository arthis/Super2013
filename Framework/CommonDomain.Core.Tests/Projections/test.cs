
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CommonDomain.Core.Handlers.Actions;
using CommonDomain.Core.Projections;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;
using MIt = Moq.It;

namespace CommonDomain.Core.Tests.Projections
{
    public class FakeEventProjection : IEvent
    {
        public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public string ToDescription()
        {
            throw new NotImplementedException();
        }

        public long Version { get; private set; }
    }


    public class When_thresholdprojectionner_is_created_with_threshold_and_projectionflusher
    {
        private static ThresholdProjectionner _projectionner;
        private static int _threshold;
        private static Mock<IProjectionFlusher> _projectionFlusher;

        Establish context = () =>
        {
            _threshold = 20;
            _projectionFlusher = new Mock<IProjectionFlusher>();
        };

        private Because of = () =>
        {
            _projectionner = new ThresholdProjectionner(_projectionFlusher.Object,_threshold);
        };

        private Cleanup after = () => _projectionner = null;

        private It should_acknowledge_its_construction = () => _projectionner.ShouldNotBeNull();

    }

    public class When_thresholdprojectionner_is_created_with_threshold_at_zero
    {
        private static int _threshold;
        static Exception _exception;
        private static Mock<IProjectionFlusher> _projectionFlusher;

        Establish context = () =>
        {
            _threshold = 0;
            _projectionFlusher = new Mock<IProjectionFlusher>();
        };

        private Because of = () => _exception = Catch.Exception(()=> new ThresholdProjectionner(_projectionFlusher.Object, _threshold));

        private It should_have_thrown_an_exception = () => _exception.ShouldNotBeNull();
        private It and_should_be_an_ArgumentException  = () => _exception.ShouldBeOfType<ArgumentException>(); 
    }

    public class When_thresholdprojectionner_is_created_without_projectionflusher
    {
        private static int _threshold;
        static Exception _exception;

        Establish context = () =>
        {
            _threshold = 12;
            
        };

        private Because of = () => _exception = Catch.Exception(()=> new ThresholdProjectionner(null, _threshold));
    
        private It should_have_thrown_an_exception = () => _exception.ShouldNotBeNull();
        private It and_should_be_an_ArgumentNullException  = () => _exception.ShouldBeOfType<ArgumentNullException>(); 

    }

    public class When_thresholdprojectionnist_is_moving_next
    {
        private static ThresholdProjectionner _projectionner;
        private static int _threshold;
        private static Mock<IProjectionAction> _projectionAction;
        private static Mock<IProjectionFlusher> _projectionFlusher;

        Establish context = () =>
        {
            _threshold = 1;
            _projectionAction = new Mock<IProjectionAction>();
            _projectionFlusher = new Mock<IProjectionFlusher>();
        };

        private Because of = () =>
        {
            _projectionner = new ThresholdProjectionner(_projectionFlusher.Object, _threshold);
            _projectionner.MoveNext(_projectionAction.Object);
            _projectionner.MoveNext(_projectionAction.Object);
        };

        private It should_flush_if_threshold_is_overtaken = () => _projectionFlusher.Verify(x => x.Flush(MIt.IsAny<IEnumerable<IProjectionAction>>()));

        private Cleanup after = () => _projectionner = null;

    }

    //public class When_an_sql_projectioon_handler_is_created_It_should_get_a_projectionnist
    //{

    //    private static SqlProjectionHandler<FakeEventProjection> _projectionHandler;
    //    private static IEnumerable<IProjectionAction> _projections;
    

    //    Establish context = () =>
    //    {
    //         _projections = new List<IProjectionAction>();

    //    };

    //    private Cleanup after = () => _action = null;

    //    private Because of = () =>
    //    {
    //        _projectionHandler = new SqlProjectionHandler<FakeEventProjection>(_projections);
    //    };

    //    private It should_acknowledge_its_creation = () => _projectionHandler.ShouldNotBeNull();

    //}

    
    //public class When_an_event_is_handled_by_a_sql_projection_it_should_fill_something
    
    //{

    //    private static SqlProjectionHandler<FakeEventProjection> _projectionHandler;
    //    private static IProjectionAction _projectionAction;
    //    private static List<Guid> _committenti = new List<Guid>();
    //    private static List<Guid> _lotti = new List<Guid>();
    //    private static List<Guid> _tipiIntervento = new List<Guid>();
    //    private static IActionFactory _actionfactory;
    //    private static MyCommand _command;
    //    private static bool _canBeExecuted;

    //    Establish context = () =>
    //    {
    //        _command = new MyCommand();
    //        _commands.Add(new Regex(typeof(MyCommand).ToString()));
    //        _actionfactory = new ActionFactory();
    //        _actionfactory.AddCommandTypeConstrainedActionHandlerFor<MyCommand>();
    //        _securityUser = new SecurityUser(Guid.NewGuid(), _commands, _committenti, _lotti, _tipiIntervento);

    //    };

    //    private Cleanup after = () => _action = null;

    //    private Because of = () =>
    //    {
    //        _action = _securityUser.CreateAction(_actionfactory, _command);
    //        _canBeExecuted = _action.CanBeExecuted();
    //    };

    //    private It should_acknowledge_its_execution = () => _canBeExecuted.ShouldBeTrue();

    //}
}
