using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Domain;

namespace Super.Appaltatore.Handlers
{
    public class ConsuntivareRotResoHandler : CommandHandler<ConsuntivareRotReso>
    {
        public ConsuntivareRotResoHandler(IRepository repository)
            : base(repository)
        {
        }

        public override CommandValidation Execute(ConsuntivareRotReso cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

           var existingIntervento = Repository.GetById<InterventoRot>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new HandlerForDomainEventNotFoundException();

            existingIntervento.ConsuntivareReso(cmd.Id
                                , cmd.DataConsuntivazione
                                , cmd.End
                                , cmd.Start
                                , cmd.IdInterventoAppaltatore
                                , cmd.Note
                                ,cmd.Oggetti
                                ,cmd.Convoglio
                                ,cmd.DataTrenoArrivo
                                ,cmd.DataTrenoPartenza
                                ,cmd.NumeroTrenoArrivo
                                ,cmd.NumeroTrenoPartenza
                                , cmd.RigaTurnoTreno
                                , cmd.TurnoTreno);


            Repository.Save(existingIntervento, cmd.GetCommitId());

            return existingIntervento.CommandValidationMessages;
        }
    }
}