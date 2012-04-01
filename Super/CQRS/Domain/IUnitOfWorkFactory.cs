using System;
using Cqrs.Commanding;

namespace Cqrs.Domain
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWorkContext CreateUnitOfWork(Guid commandId);
    }
}
