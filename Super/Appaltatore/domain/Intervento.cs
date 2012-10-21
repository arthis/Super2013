using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Appaltatore.Events;
using Super.Appaltatore.Events.Consuntivazione;

namespace Super.Appaltatore.Domain
{
    public abstract class Intervento : AggregateBase
    {
        internal static Guid IdCausaleAppaltatoreAutomatica = new Guid("5c7a22d6-21ef-4470-8d84-14c56c3ea2d3");
        internal static string IdInterventoAppaltatoreAutomatica = "Automatic";

        public enum E_StatoAppaltatore
        {
            NotDeclared,
            Reso,
            NonReso,
            NonResoTrenitalia
        }

        internal WorkPeriod ProgrammedWorkPeriod;
        internal E_StatoAppaltatore StatoAppaltatore;

    }
}
