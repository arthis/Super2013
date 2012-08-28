using System;
using System.Configuration;
using System.Linq;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using Super.Contabilita.Events.Impianto;
using Super.ReadModel;

namespace Super.Contabilita.Projection
{
    public class ImpiantoProjection : IEventHandler<ImpiantoCreated>,
                                            IEventHandler<ImpiantoUpdated>,
                                            IEventHandler<ImpiantoDeleted>
    {

        public void Handle(ImpiantoCreated @event)
        {
            using (var container = Container.GetEntities())
            {
                var ai = container.Impiantoes.SingleOrDefault(x => x.Id == @event.Id);
                if (ai != null)
                    throw new Exception("Entity already created with the same id");

                ai = new Impianto()
                         {
                             Id = @event.Id,
                             CreationDate = DateTime.Now,
                             Deleted = false,
                             Description = @event.Description,
                             IdLotto = @event.IdLotto,
                             End = @event.Interval.End,
                             Start = @event.Interval.Start,
                             Version = @event.Version
                         };

                container.Impiantoes.AddObject(ai);
                container.SaveChanges();
            }
        }

        public void Handle(ImpiantoUpdated @event)
        {
            using (var container = Container.GetEntities())
            {
                var ai = container.Impiantoes.SingleOrDefault(x => x.Id == @event.Id);
                if (ai == null)
                    throw new Exception("Entity not found");

                ai.Description = @event.Description;
                ai.End = @event.Period.End;
                ai.Start = @event.Period.Start;
                ai.Version = @event.Version;

                container.SaveChanges();
            }
        }

        public void Handle(ImpiantoDeleted @event)
        {
            using (var container = Container.GetEntities())
            {
                var ai = container.Impiantoes.SingleOrDefault(x => x.Id == @event.Id);
                if (ai == null)
                    throw new Exception("Entity not found");

                ai.Deleted = true;
                ai.Version = @event.Version;

                container.SaveChanges();
            }
        }
    }
}
