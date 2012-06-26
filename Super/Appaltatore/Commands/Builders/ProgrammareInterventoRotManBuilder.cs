using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Appaltatore.Commands.Builders
{

    public class ProgrammareInterventoRotManBuilder : ICommandBuilder<ProgrammareInterventoRotMan>
    {
        private Guid _idImpianto;
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

        public ProgrammareInterventoRotManBuilder In(Guid idImpianto)
        {
            _idImpianto = idImpianto;
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

        public ProgrammareInterventoRotManBuilder ForArea(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public ProgrammareInterventoRotManBuilder ForTipo(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }
      

        public ProgrammareInterventoRotMan Build(Guid id)
        {
            var cmd = new  ProgrammareInterventoRotMan(id,
                                      _idImpianto,
                                      _idTipoIntervento,
                                      _idAppaltatore,
                                      _idCategoriaCommerciale,
                                      _idDirezioneRegionale,
                                      _period,
                                      _note,
                                      _oggetti);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }


       
    }
}
