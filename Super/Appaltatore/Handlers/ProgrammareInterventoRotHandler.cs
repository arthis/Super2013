using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.ValueObjects;
using CommonDomain.Persistence;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Domain;

namespace Super.Appaltatore.Handlers
{
    public class ProgrammareInterventoRotHandler : CommandHandler<ProgrammareInterventoRot>
    {
        public ProgrammareInterventoRotHandler(IRepository repository)
            : base(repository)
        {
        }

        public override CommandValidation Execute(ProgrammareInterventoRot cmd)
        {

            Contract.Requires<ArgumentNullException>(cmd != null);


            var existingIntervento = Repository.GetById<InterventoRot>(cmd.Id);

            if (!existingIntervento.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            existingIntervento.Programmare(cmd.Id
                                , cmd.IdAreaIntervento
                                , cmd.IdTipoIntervento
                                , cmd.IdAppaltatore
                                , cmd.IdCategoriaCommerciale
                                , cmd.IdDirezioneRegionale
                                , new RangeDate(cmd.Start, cmd.End)
                                , cmd.Note
                                , cmd.Oggetti
                                , cmd.NumeroTrenoArrivo
                                , cmd.DataTrenoArrivo
                                , cmd.NumeroTrenoPartenza
                                , cmd.DataTrenoPartenza
                                , cmd.TurnoTreno
                                , cmd.RigaTurnoTreno
                                , cmd.Convoglio);

            Repository.Save(existingIntervento, cmd.GetCommitId());

            return existingIntervento.CommandValidationMessages;
        }
    }
}