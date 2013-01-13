using System;
using System.Collections.Generic;
using Machine.Specifications;
using Super.Contabilita.Domain.Schedulazione;

namespace Super.Contabilita.Domain.Tests
{
    public class when_a_schedulazione_Calculate_its_price
    {
        private static SchedulazioneAmb _schedulazione;
        private static Domain.Pricing.Pricing _pricing;

        Establish context = () =>
        {
            _schedulazione = new SchedulazioneAmb();
            _pricing = new Pricing.Pricing();
            

        };

        //private Cleanup after = () => _action = null;

        private Because of = () =>
        {
            _schedulazione.CalculateBasePrice(_pricing);
        };

        //private It should_acknowledge_its_execution = () => _canBeExecuted.ShouldBeTrue();

    }
}
