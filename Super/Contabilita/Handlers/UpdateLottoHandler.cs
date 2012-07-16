using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Domain.Builders;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.Lotto;
using Super.Contabilita.Domain;
using Super.Contabilita.Handlers.Repositories;

namespace Super.Contabilita.Handlers
{
    public class UpdateLottoHandler : CommandHandler<UpdateLotto>
    {
        private readonly ILottoRepository _lottoRepository;

        public UpdateLottoHandler(IEventRepository eventRepository,ILottoRepository lottoRepository )
            : base(eventRepository)
        {
            Contract.Requires(lottoRepository!=null);

            _lottoRepository = lottoRepository;
        }


        public override CommandValidation Execute(UpdateLotto cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            var lotto= EventRepository.GetById<Lotto>(cmd.Id);
            

            if (lotto.IsNull())
                throw new AggregateRootInstanceNotFoundException();
            if (!_lottoRepository.AreImpiantoAssociatedWihtinIntervall(cmd.Id,cmd.Intervall))
                throw new CommandValidationException("The intervall of the impianti associated are not included in this intervall");

            lotto.Update(Build.Intervall.FromPeriod(cmd.Intervall).Build(), cmd.Description);

            EventRepository.Save(lotto, cmd.CommitId);

            return lotto.CommandValidationMessages;
        }
      
    }
}
