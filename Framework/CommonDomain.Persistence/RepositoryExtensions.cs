using System;

namespace CommonDomain.Persistence
{
    public static class RepositoryExtensions
    {
         public static void Save(this IEventRepository eventRepository, IAggregate aggregate, Guid commitId)
         {
             eventRepository.Save(aggregate, commitId, a => {});
         }
    }
}