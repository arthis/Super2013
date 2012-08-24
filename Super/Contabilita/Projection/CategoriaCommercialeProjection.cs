using System;
using System.Configuration;
using System.Linq;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using Super.Contabilita.Events.CategoriaCommerciale;
using Super.ReadModel;

namespace Super.Contabilita.Projection
{
    public class CategoriaCommercialeProjection : IEventHandler<CategoriaCommercialeCreated>,
                                            IEventHandler<CategoriaCommercialeUpdated>,
                                            IEventHandler<CategoriaCommercialeDeleted>
    {

        public void Handle(CategoriaCommercialeCreated @event)
        {
            using (var container = Container.GetEntities())
            {
                var ai = container.CategoriaCommerciales.SingleOrDefault(x => x.Id == @event.Id);
                if (ai != null)
                    throw new Exception("Entity already created with the same id");

                ai = new CategoriaCommerciale()
                         {
                             Id = @event.Id,
                             CreationDate = DateTime.Now,
                             Deleted = false,
                             Description = @event.Description,
                             Version = @event.Version
                         };

                container.CategoriaCommerciales.AddObject(ai);
                container.SaveChanges();
            }
        }

        public void Handle(CategoriaCommercialeUpdated @event)
        {
            using (var container = Container.GetEntities())
            {
                var ai = container.CategoriaCommerciales.SingleOrDefault(x => x.Id == @event.Id);
                if (ai == null)
                    throw new Exception("Entity not found");

                ai.Description = @event.Description;
                ai.Version = @event.Version;
                
                container.SaveChanges();
            }
        }

        public void Handle(CategoriaCommercialeDeleted @event)
        {
            using (var container = Container.GetEntities())
            {
                var ai = container.CategoriaCommerciales.SingleOrDefault(x => x.Id == @event.Id);
                if (ai == null)
                    throw new Exception("Entity not found");

                ai.Deleted = true;
                ai.Version = @event.Version;

                container.SaveChanges();
            }
        }
    }
}
