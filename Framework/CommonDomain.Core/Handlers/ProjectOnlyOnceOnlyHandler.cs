using System.Diagnostics.Contracts;
using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers
{
    public class ProjectOnlyOnceOnlyHandler<T> : IEventHandler<T> where T : IMessage
    {
        private readonly ICommandRepository _commandRepository;
        private readonly IProjectionRepository _repository;
        private IEventHandler<T> _next;

        public ProjectOnlyOnceOnlyHandler(IProjectionRepository repository, IEventHandler<T> next)
        {
            Contract.Requires(next != null);
            Contract.Requires(repository!=null);

            _repository = repository;
            _next = next;
        }

        public void Handle(T evt)
        {
            //check that the commitid is not part of the eventstore already
            var isHandled = _repository.IsHandled(evt.CommitId);

            if (isHandled)
            {
                var msg = string.Format("The event '{0}' was already projected", evt.CommitId);
                throw new EventAlreadyProjectedException(msg);
            }

            _next.Handle(evt);

            _repository.Save(evt);
        }
    }
}