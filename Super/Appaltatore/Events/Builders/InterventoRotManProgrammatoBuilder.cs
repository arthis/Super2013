using System;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Appaltatore.Events.Programmazione;

namespace Super.Appaltatore.Events.Builders
{
    public class InterventoRotManProgrammatoBuilder
    {
        private Guid _id;
        private Guid _idAreaIntervento;
        private Guid _idTipoIntervento;
        private Guid _idAppaltatore;
        private Guid _idCategoriaCommerciale;
        private Guid _idDirezioneRegionale;
        private WorkPeriod _period;
        private string _note;
        private OggettoRotMan[] _oggetti;

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

        public InterventoRotManProgrammatoBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

        public InterventoRotManProgrammatoBuilder In(Guid idAreaIntervento)
        {
            _idAreaIntervento = idAreaIntervento;
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

        public InterventoRotManProgrammato Build()
        {
            return new InterventoRotManProgrammato(_id,
                                                   _idAreaIntervento,
                                                   _idTipoIntervento,
                                                   _idAppaltatore,
                                                   _idCategoriaCommerciale,
                                                   _idDirezioneRegionale,
                                                   _period,
                                                   _note,
                                                   _oggetti);
        }

    }
}