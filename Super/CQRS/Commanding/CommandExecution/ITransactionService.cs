using System;

namespace Cqrs.Commanding.CommandExecution
{
    public interface ITransactionService
    {
        void ExecuteInTransaction(Action action);
    }
}