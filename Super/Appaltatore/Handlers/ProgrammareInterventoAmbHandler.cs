using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Domain;

namespace Super.Appaltatore.Handlers
{
    public class ProgrammareInterventoAmbHandler : CommandHandler<ProgrammareInterventoAmb>
    {
        public ProgrammareInterventoAmbHandler(IRepository repository)
            : base(repository)
        {
        }

        public override CommandValidation Execute(ProgrammareInterventoAmb cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);


            var existingIntervento = Repository.GetById<InterventoAmb>(cmd.Id);

            if (!existingIntervento.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            existingIntervento.Programmare(cmd.Id
                                , cmd.IdAreaIntervento
                                , cmd.IdTipoIntervento
                                , cmd.IdAppaltatore
                                , cmd.IdCategoriaCommerciale
                                , cmd.IdDirezioneRegionale
                                , cmd.Start
                                , cmd.End
                                , cmd.Note);

            Repository.Save(existingIntervento, cmd.GetCommitId());

            return existingIntervento.CommandValidationMessages;
        }
    }
}