using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Domain;

namespace Super.Appaltatore.Handlers
{
    public class ProgrammareInterventoRotManHandler : CommandHandler<ProgrammareInterventoRotMan>
    {
        public ProgrammareInterventoRotManHandler(IRepository repository)
            : base(repository)
        {
        }

        public override CommandValidation Execute(ProgrammareInterventoRotMan cmd, ICommandHandler<ProgrammareInterventoRotMan> next)
        {

            Contract.Requires<ArgumentNullException>(cmd != null);


            var existingIntervento = Repository.GetById<InterventoRotMan>(cmd.Id);

            if (!existingIntervento.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            existingIntervento.Programmare(cmd.Id
                                , cmd.IdImpianto
                                , cmd.IdTipoIntervento
                                , cmd.IdAppaltatore
                                , cmd.IdCategoriaCommerciale
                                , cmd.IdDirezioneRegionale
                                , WorkPeriod.FromMessage(cmd.Period)
                                , cmd.Note
                                , cmd.Oggetti.ToValueObject());

            Repository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages;
        }
    }
}