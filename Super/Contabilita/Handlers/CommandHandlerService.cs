using CommonDomain;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Handlers.Commands.Appaltatore;
using Super.Contabilita.Handlers.Commands.CategoriaCommerciale;
using Super.Contabilita.Handlers.Commands.Committente;
using Super.Contabilita.Handlers.Commands.DirezioneRegionale;
using Super.Contabilita.Handlers.Commands.Lotto;
using Super.Contabilita.Handlers.Commands.MeasuringUnit;
using Super.Contabilita.Handlers.Commands.PeriodoProgrammazione;
using Super.Contabilita.Handlers.Commands.TipoIntervento;
using Super.Contabilita.Handlers.Impianto;
using Super.Contabilita.Handlers.Repositories;

namespace Super.Contabilita.Handlers
{
    public class CommandHandlerService : CommandHandlerServiceBase
    {
        private readonly ISecurityUserRepository _repositorySecurityUser;

        public CommandHandlerService(ISecurityUserRepository repositorySecurityUser)
        {
            _repositorySecurityUser = repositorySecurityUser;
        }

        public override void InitCommandHandlers(ICommandRepository commandRepository, IEventRepository eventRepository, IActionFactory actionFactory)
        {
            var handlerHelper = new CommandHandlerHelper(commandRepository, actionFactory,_repositorySecurityUser, Handlers);

            handlerHelper.AddFullyConstrainedCommand( new CreateImpiantoHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new UpdateImpiantoHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new DeleteImpiantoHandler(eventRepository));

            handlerHelper.AddFullyConstrainedCommand( new CreateLottoHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new UpdateLottoHandler(eventRepository, new SqlLottoRepository()));
            handlerHelper.AddFullyConstrainedCommand( new DeleteLottoHandler(eventRepository));

            handlerHelper.AddFullyConstrainedCommand( new CreateAppaltatoreHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new UpdateAppaltatoreHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new DeleteAppaltatoreHandler(eventRepository));


            handlerHelper.AddFullyConstrainedCommand( new CreateCategoriaCommercialeHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new UpdateCategoriaCommercialeHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new DeleteCategoriaCommercialeHandler(eventRepository));

            handlerHelper.AddFullyConstrainedCommand( new CreateCommittenteHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new UpdateCommittenteHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new DeleteCommittenteHandler(eventRepository));

            handlerHelper.AddFullyConstrainedCommand( new CreateDirezioneRegionaleHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new UpdateDirezioneRegionaleHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new DeleteDirezioneRegionaleHandler(eventRepository));

            handlerHelper.AddFullyConstrainedCommand( new CreateMeasuringUnitHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new UpdateMeasuringUnitHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new DeleteMeasuringUnitHandler(eventRepository));

            handlerHelper.AddFullyConstrainedCommand( new CreatePeriodoProgrammazioneHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new UpdatePeriodoProgrammazioneHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new DeletePeriodoProgrammazioneHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new ClosePeriodoProgrammazioneHandler(eventRepository));

            handlerHelper.AddFullyConstrainedCommand( new CreateTipoInterventoAmbHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new UpdateTipoInterventoAmbHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new DeleteTipoInterventoAmbHandler(eventRepository));

            handlerHelper.AddFullyConstrainedCommand( new CreateTipoInterventoRotHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new UpdateTipoInterventoRotHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new DeleteTipoInterventoRotHandler(eventRepository));

            handlerHelper.AddFullyConstrainedCommand( new CreateTipoInterventoRotManHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new UpdateTipoInterventoRotManHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new DeleteTipoInterventoRotManHandler(eventRepository));

        }

        public override void Subscribe(IBus bus)
        {
            //do nothing
        }


        
    }

}
