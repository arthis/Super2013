using System;
using System.Diagnostics.Contracts;

namespace CommonDomain.Persistence
{
    public static class RepositoryExtensions
    {
         public static void Save(this IEventRepository eventRepository, IAggregate aggregate, Guid commitId)
         {
             Contract.Requires(eventRepository != null);

             eventRepository.Save(aggregate, commitId, a => {});
         }
    }
}