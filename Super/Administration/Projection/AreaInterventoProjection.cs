using System;
using System.Configuration;
using System.Linq;
using CommonDomain.Core;
using Super.Administration.Events.AreaIntervento;
using Super.Administration.ReadModel;

namespace Super.Administration.Projection
{
    public class AreaInterventoProjection : IEventHandler<AreaInterventoCreated>,
                                            IEventHandler<AreaInterventoUpdated>,
                                            IEventHandler<AreaInterventoDeleted>
    {

        private Super2013Container GetContainer()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Super2013Entities"].ConnectionString;
            return new Super2013Container(connectionString);
        }

        public void Handle(AreaInterventoCreated @event)
        {
            using (var container = GetContainer())
            {
                var ai = container.AreaInterventoes.SingleOrDefault(x => x.Id == @event.Id);
                if (ai != null)
                    throw new Exception("Entity already created with the same id");

                ai = new AreaIntervento()
                         {
                             Id = @event.Id,
                             CreationDate = @event.CreationDate,
                             Deleted = false,
                             Description = @event.Description,
                             End = @event.End,
                             Start = @event.Start
                         };

                container.AreaInterventoes.AddObject(ai);
                container.SaveChanges();
            }
        }

        public void Handle(AreaInterventoUpdated @event)
        {
            using (var container = GetContainer())
            {
                var ai = container.AreaInterventoes.SingleOrDefault(x => x.Id == @event.Id);
                if (ai == null)
                    throw new Exception("Entity not found");

                ai.Description = @event.Description;
                ai.End = @event.End;
                ai.Start = @event.Start;

                container.SaveChanges();
            }
        }

        public void Handle(AreaInterventoDeleted @event)
        {
            using (var container = GetContainer())
            {
                var ai = container.AreaInterventoes.SingleOrDefault(x => x.Id == @event.Id);
                if (ai == null)
                    throw new Exception("Entity not found");

                ai.Deleted = true;

                container.SaveChanges();
            }
        }
    }
}
