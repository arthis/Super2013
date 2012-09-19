using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Appaltatore.Events.Programmazione;

namespace Super.Appaltatore.Events.Builders
{
    public class InterventoRotManProgrammatoBuilder : IEventBuilder<InterventoRotManProgrammato>
    {
        private Guid _idAppaltatore;
        private Guid _idCategoriaCommerciale;
        private Guid _idDirezioneRegionale;
        private Guid _idImpianto;
        private Guid _idTipoIntervento;
        private string _note;
        private OggettoRotMan[] _oggetti;
        private WorkPeriod _period;

        #region IEventBuilder<InterventoRotManProgrammato> Members

        public InterventoRotManProgrammato Build(Guid id, long version)
        {
            return new InterventoRotManProgrammato(id, Guid.NewGuid(),
                                                   version,
                                                   _idImpianto,
                                                   _idTipoIntervento,
                                                   _idAppaltatore,
                                                   _idCategoriaCommerciale,
                                                   _idDirezioneRegionale,
                                                   _period,
                                                   _note,
                                                   _oggetti);
        }

        #endregion

        public InterventoRotManProgrammatoBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public InterventoRotManProgrammatoBuilder ForPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }


        public InterventoRotManProgrammatoBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public InterventoRotManProgrammatoBuilder OfType(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public InterventoRotManProgrammatoBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public InterventoRotManProgrammatoBuilder OfCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public InterventoRotManProgrammatoBuilder OfDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public InterventoRotManProgrammatoBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }
    }
}