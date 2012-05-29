using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Appaltatore.Commands;

namespace Super.Appaltatore.Handlers
{
    public class ConsuntivareAmbNonResoHandler : CommandHandler<ConsuntivareAmbNonReso>
    {
        public ConsuntivareAmbNonResoHandler(IRepository repository)
            : base(repository)
        {
        }

        public override CommandValidation Execute(ConsuntivareAmbNonReso cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            throw new NotImplementedException();

            //var existingIntervento = Repository.GetById<InterventoAmb>(cmd.Id);

            //if (existingIntervento.IsNull())
            //    throw new HandlerForDomainEventNotFoundException();

            //existingIntervento.(cmd.Id
            //                    , cmd.IdAreaIntervento
            //                    , cmd.IdTipoIntervento
            //                    , cmd.IdAppaltatore
            //                    , cmd.IdCategoriaCommerciale
            //                    , cmd.IdDirezioneRegionale
            //                    , cmd.Start
            //                    , cmd.End
            //                    , cmd.Note);

            //Repository.Save(existingIntervento, cmd.GetCommitId());

            //return existingIntervento.CommandValidationMessages;
        }
    }
}