using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Appaltatore.Events.Consuntivazione;

namespace Super.Appaltatore.Events.Builders
{
    public class InterventoConsuntivatoRotManResoBuilder : IEventBuilder<InterventoConsuntivatoRotManReso>
    {
        private DateTime _dataConsuntivazione;
        private string _idInterventoAppaltatore;
        private string _note;
        private OggettoRotMan[] _oggetti;
        private WorkPeriod _period;

        #region IEventBuilder<InterventoConsuntivatoRotManReso> Members

        public InterventoConsuntivatoRotManReso Build(Guid id, long version)
        {
            return new InterventoConsuntivatoRotManReso(id, Guid.NewGuid(), version, _idInterventoAppaltatore,
                                                        _dataConsuntivazione, _period, _note,
                                                        _oggetti);
        }

        #endregion

        public InterventoConsuntivatoRotManResoBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public InterventoConsuntivatoRotManResoBuilder ForPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }


        public InterventoConsuntivatoRotManResoBuilder ForInterventoAppaltatore(string IdInterventoAppaltatore)
        {
            _idInterventoAppaltatore = IdInterventoAppaltatore;
            return this;
        }

        public InterventoConsuntivatoRotManResoBuilder When(DateTime dataConsuntivazione)
        {
            _dataConsuntivazione = dataConsuntivazione;
            return this;
        }

        public InterventoConsuntivatoRotManResoBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }
    }
}