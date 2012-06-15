﻿using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.ValueObjects;
using Super.Controllo.Commands;
using Super.Controllo.Domain;
using CommonDomain.Persistence;
using System.Diagnostics.Contracts;

namespace Super.Controllo.Handlers
{
    public class ControlInterventoAmbResoHandler : CommandHandler<ControlInterventoAmbReso>
    {
        public ControlInterventoAmbResoHandler(IRepository repository)
            : base(repository)
        {
        }

        public override CommandValidation Execute(ControlInterventoAmbReso cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);

            Treno trenoPartenza=null, trenoArrivo=null;


            var existingIntervento = Repository.GetById<InterventoAmb>(cmd.Id);

            if (existingIntervento.IsNull())
                throw new AggregateRootInstanceNotFoundException();


            existingIntervento.ControlReso(cmd.IdUtente, cmd.ControlDate, new RangeDate(cmd.Start, cmd.End),   cmd.Note, cmd.Quantita, cmd.Descrizione);

            Repository.Save(existingIntervento, cmd.GetCommitId());

            return existingIntervento.CommandValidationMessages; 
        }
    }
}
