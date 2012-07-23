﻿using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Programmazione.Events.Builders
{
    public abstract class InterventoGeneratedBuilder
    {
        protected Guid _idPeriodoProgrammazione;
        protected Guid _idPlan;
        protected Guid _idCommittente;
        protected Guid _idLotto;
        protected Guid _idImpianto;
        protected Guid _idTipoIntervento;
        protected Guid _idAppaltatore;
        protected Guid _idCategoriaCommerciale;
        protected Guid _idDirezioneRegionale;
        protected string _note;
        protected WorkPeriod _workPeriod;

        public InterventoGeneratedBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public InterventoGeneratedBuilder ForPlan(Guid idPlan)
        {
            _idPlan = idPlan;
            return this;
        }

        public InterventoGeneratedBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public InterventoGeneratedBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public InterventoGeneratedBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public InterventoGeneratedBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public InterventoGeneratedBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public InterventoGeneratedBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public InterventoGeneratedBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public InterventoGeneratedBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public InterventoGeneratedBuilder ForPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

    }

    public class InterventoRotGeneratedBuilder : InterventoGeneratedBuilder, IEventBuilder<InterventoRotGenerated>
    {
        private OggettoRot[] _oggetti;
        private Treno _trenoPartenza;
        private Treno _trenoArrivo;
        private string _turnoTreno;
        private string _rigaTurnoTreno;
        private string _convoglio;

        public InterventoRotGeneratedBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }



        public InterventoRotGeneratedBuilder WithTrenoArrivo(Treno trenoArrivo)
        {
            _trenoArrivo = trenoArrivo;
            return this;
        }

        public InterventoRotGeneratedBuilder WithTrenoPartenza(Treno trenoPartenza)
        {
            _trenoPartenza = trenoPartenza;
            return this;
        }

        public InterventoRotGeneratedBuilder WithTurnoTreno(string turnoTreno)
        {
            _turnoTreno = turnoTreno;
            return this;
        }

        public InterventoRotGeneratedBuilder WithRigaTurnoTreno(string rigaTurnoTreno)
        {
            _rigaTurnoTreno = rigaTurnoTreno;
            return this;
        }

        public InterventoRotGeneratedBuilder ForConvoglio(string convoglio)
        {
            _convoglio = convoglio;
            return this;
        }






        public InterventoRotGenerated Build(Guid id, long version)
        {
            var evt = new InterventoRotGenerated(id, Guid.NewGuid(),
                                                 version,
                                                 _idPeriodoProgrammazione,
                                                 _idPlan,
                                                 _idCommittente,
                                                 _idLotto,
                                                 _idImpianto,
                                                 _idTipoIntervento,
                                                 _idAppaltatore,
                                                 _idCategoriaCommerciale,
                                                 _idDirezioneRegionale,
                                                 _workPeriod,
                                                 _note,
                                                 _oggetti,
                                                 _trenoArrivo,
                                                 _trenoPartenza,
                                                 _turnoTreno,
                                                 _rigaTurnoTreno,
                                                 _convoglio);

            return evt;
        }

    }

    public class InterventoRotManGeneratedBuilder : InterventoGeneratedBuilder, IEventBuilder<InterventoRotManGenerated>
    {
        private OggettoRotMan[] _oggetti;

        public InterventoRotManGeneratedBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }


        public InterventoRotManGenerated Build(Guid id, long version)
        {
            var evt = new InterventoRotManGenerated(id, Guid.NewGuid(),
                                                 version,
                                                 _idPeriodoProgrammazione,
                                                 _idPlan,
                                                 _idCommittente,
                                                 _idLotto,
                                                 _idImpianto,
                                                 _idTipoIntervento,
                                                 _idAppaltatore,
                                                 _idCategoriaCommerciale,
                                                 _idDirezioneRegionale,
                                                 _workPeriod,
                                                 _note,
                                                 _oggetti);

            return evt;
        }

    }

    public class InterventoAmbGeneratedBuilder : InterventoGeneratedBuilder, IEventBuilder<InterventoAmbGenerated>
    {
        private int _quantity;
        private string _description;

        public InterventoAmbGeneratedBuilder ForQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public InterventoAmbGeneratedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }


        public InterventoAmbGenerated Build(Guid id, long version)
        {
            var evt = new InterventoAmbGenerated(id, Guid.NewGuid(),
                                                 version,
                                                 _idPeriodoProgrammazione,
                                                 _idPlan,
                                                 _idCommittente,
                                                 _idLotto,
                                                 _idImpianto,
                                                 _idTipoIntervento,
                                                 _idAppaltatore,
                                                 _idCategoriaCommerciale,
                                                 _idDirezioneRegionale,
                                                 _workPeriod,
                                                 _note,
                                                 _quantity,
                                                 _description);

            return evt;
        }

    }


}
