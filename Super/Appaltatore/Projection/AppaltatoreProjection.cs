using System;
using System.Configuration;
using System.Linq;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using Super.Contabilita.Events.Appaltatore;
using Super.Appaltatore.ReadModel;

namespace Super.Appaltatore.Projection
{
    public class AppaltatoreProjection : IEventHandler<AppaltatoreCreated>,
                                            IEventHandler<AppaltatoreUpdated>,
                                            IEventHandler<AppaltatoreDeleted>
    {

        public void Handle(AppaltatoreCreated @event)
        {
            using (var container = Container.GetEntities())
            {
                throw new NotImplementedException();
                //var app = container.Appaltatores.SingleOrDefault(x => x.Id == @event.Id);
                //if (app != null)
                //    throw new Exception("Entity already created with the same id");

                //app = new Appaltatore()
                //         {
                //             Id = @event.Id,
                //             CreationDate = DateTime.Now,
                //             Deleted = false,
                //             Description = @event.Description,
                //             Version = @event.Version
                //         };

                //container.Appaltatores.AddObject(ai);
                //container.SaveChanges();
            }
        }

        public void Handle(AppaltatoreUpdated @event)
        {
            using (var container = Container.GetEntities())
            {
                var ai = container.Appaltatores.SingleOrDefault(x => x.Id == @event.Id);
                if (ai == null)
                    throw new Exception("Entity not found");

                ai.Description = @event.Description;
                ai.Version = @event.Version;
                
                container.SaveChanges();
            }
        }

        public void Handle(AppaltatoreDeleted @event)
        {
            using (var container = Container.GetEntities())
            {
                var ai = container.Appaltatores.SingleOrDefault(x => x.Id == @event.Id);
                if (ai == null)
                    throw new Exception("Entity not found");

                ai.Deleted = true;
                ai.Version = @event.Version;

                container.SaveChanges();
            }
        }
    }
}
