using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Programmazione.Events.Builders
{

    public class InterventoRotManGeneratedBuilder : IEventBuilder<InterventoRotManGenerated>
    {
        private Guid _idImpianto;
        private Guid _idTipoIntervento;
        private Guid _idAppaltatore;
        private Guid _idCategoriaCommerciale;
        private Guid _idDirezioneRegionale;
        private WorkPeriod _period;
        private string _note;
        private OggettoRotMan[] _oggetti;


        public InterventoRotManGeneratedBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public InterventoRotManGeneratedBuilder ForPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }

        public InterventoRotManGeneratedBuilder In(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public InterventoRotManGeneratedBuilder OfType(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public InterventoRotManGeneratedBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public InterventoRotManGeneratedBuilder OfCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public InterventoRotManGeneratedBuilder OfDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public InterventoRotManGeneratedBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public InterventoRotManGeneratedBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public InterventoRotManGeneratedBuilder ForTipo(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }


        public InterventoRotManGenerated Build(Guid id, long version)
        {
            var evt = new  InterventoRotManGenerated(id, Guid.NewGuid(),version,
                                      _idImpianto,
                                      _idTipoIntervento,
                                      _idAppaltatore,
                                      _idCategoriaCommerciale,
                                      _idDirezioneRegionale,
                                      _period,
                                      _note,
                                      _oggetti);


            return evt;
        }


       
    }
}
