using System;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Appaltatore.Commands.Builders
{

    public class ProgrammareInterventoRotManBuilder
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


        public ProgrammareInterventoRotManBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public ProgrammareInterventoRotManBuilder ForPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }

        public ProgrammareInterventoRotManBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

        public ProgrammareInterventoRotManBuilder In(Guid idAreaIntervento)
        {
            _idAreaIntervento = idAreaIntervento;
            return this;
        }

        public ProgrammareInterventoRotManBuilder OfType(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public ProgrammareInterventoRotManBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public ProgrammareInterventoRotManBuilder OfCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public ProgrammareInterventoRotManBuilder OfDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public ProgrammareInterventoRotManBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

      

        public ProgrammareInterventoRotMan Build()
        {
            return new ProgrammareInterventoRotMan(_id,
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
