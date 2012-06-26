using System;
using System.Configuration;
using System.Linq;
using CommonDomain.Core;
using Super.Contabilita.Events.Lotto;
using Super.ReadModel;

namespace Super.Contabilita.Projection
{
    public class LottoProjection : IEventHandler<LottoCreated>,
                                   IEventHandler<LottoUpdated>,
                                   IEventHandler<LottoDeleted>
    {
        public void Handle(LottoCreated @event, IEventHandler<LottoCreated> next)
        {
            using (var container = Container.GetContainer())
            {
                var ai = container.Lottoes.SingleOrDefault(x => x.Id == @event.Id);
                if (ai != null)
                    throw new Exception("Entity already created with the same id");

                ai = new Lotto()
                         {
                             Id = @event.Id,
                             CreationDate = @event.CreationDate,
                             Deleted = false,
                             Description = @event.Description,
                             End = @event.Period.End,
                             Start = @event.Period.Start
                         };

                container.Lottoes.AddObject(ai);
                container.SaveChanges();
            }
        }

        public void Handle(LottoUpdated @event, IEventHandler<LottoUpdated> next)
        {
            using (var container = Container.GetContainer())
            {
                var ai = container.Lottoes.SingleOrDefault(x => x.Id == @event.Id);
                if (ai == null)
                    throw new Exception("Entity not found");

                ai.Description = @event.Description;
                ai.End = @event.Period.End;
                ai.Start = @event.Period.Start;

                container.SaveChanges();
            }
        }

        public void Handle(LottoDeleted @event, IEventHandler<LottoDeleted> next)
        {
            using (var container = Container.GetContainer())
            {
                var ai = container.Lottoes.SingleOrDefault(x => x.Id == @event.Id);
                if (ai == null)
                    throw new Exception("Entity not found");

                ai.Deleted = true;

                container.SaveChanges();
            }
        }
    }
}
