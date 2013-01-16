using CommandService;
using CommonDomain;
using CommonDomain.Core.Handlers.Events;
using CommonDomain.Persistence;
using Super.Contabilita.Events.Appaltatore;
using Super.Contabilita.Events.CategoriaCommerciale;
using Super.Contabilita.Events.Impianto;
using Super.Contabilita.Events.Lotto;

namespace Super.Contabilita.Projection
{
    public class ProjectionHandlerAsyncService : ProjectionHandlerAsyncServiceBase
    {
        public override void InitHandlers(IProjectionRepositoryBuilder projectionRepositoryBuilder, IBus bus)
        {
            var handlerHelper = new EventHandlerHelper("Contabilita", projectionRepositoryBuilder, _handlers, bus, Execute);

            //handlerHelper.Subscribe<ImpiantoCreated>( new ImpiantoProjection());
            //handlerHelper.Subscribe<ImpiantoUpdated>( new ImpiantoProjection());
            //handlerHelper.Subscribe<ImpiantoDeleted>( new ImpiantoProjection());


            //handlerHelper.Subscribe<LottoCreated>( new LottoProjection());
            //handlerHelper.Subscribe<LottoUpdated>( new LottoProjection());
            //handlerHelper.Subscribe<LottoDeleted>( new LottoProjection());


            handlerHelper.Subscribe<AppaltatoreCreated>(new AppaltatoreProjection());
            handlerHelper.Subscribe<AppaltatoreUpdated>(new AppaltatoreProjection());
            handlerHelper.Subscribe<AppaltatoreDeleted>(new AppaltatoreProjection());

            handlerHelper.Subscribe<AppaltatoreCreated>(new AppaltatoreProjection2());
            handlerHelper.Subscribe<AppaltatoreUpdated>(new AppaltatoreProjection2());
            handlerHelper.Subscribe<AppaltatoreDeleted>(new AppaltatoreProjection2());

            //handlerHelper.Subscribe<CategoriaCommercialeCreated>( new CategoriaCommercialeProjection());
            //handlerHelper.Subscribe<CategoriaCommercialeUpdated>( new CategoriaCommercialeProjection());
            //handlerHelper.Subscribe<CategoriaCommercialeDeleted>( new CategoriaCommercialeProjection());
        }
    }
}
