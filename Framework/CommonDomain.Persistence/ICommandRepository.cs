using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain.Persistence
{
    public interface ICommandRepository
    {
        TCommand GetById<TCommand>(Guid commitId) where TCommand : ICommand;
        bool IsExecuted(Guid commitId);
        void Save(ICommand command);
        void SaveAsExecuted(ICommand command);
    }
}
