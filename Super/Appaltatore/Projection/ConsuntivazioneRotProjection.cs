using System;
using System.Configuration;
using System.Linq;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using Super.Appaltatore.ReadModel;
using Super.ReadModel;
using Super.Appaltatore.Events.Programmazione;

namespace Super.Appaltatore.Projection
{
    public class ConsuntivazioneRotProjection : IEventHandler<InterventoRotProgrammato>
    {

        private AppaltatoreEntities GetEntities()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Super2013.Appaltatore.ReadStore"].ConnectionString;
            return new AppaltatoreEntities(connectionString);
        }



        public void Handle(InterventoRotProgrammato evt)
        {
            using (var container = GetEntities())
            {
                ConsuntivazioneRot cons = container.ConsuntivazioneRots.SingleOrDefault(x => x.IdIntervento == evt.Id);
                if (cons != null)
                    throw new Exception("Entity already created with the same id");

                cons = new ConsuntivazioneRot()
                         {
                             IdIntervento = evt.Id,
                             CreationDate = DateTime.Now,
                             Start = evt.WorkPeriod.StartDate,
                             End = evt.WorkPeriod.EndDate,
                             IdLotto = Guid.Empty,
                             IdImpianto = evt.IdImpianto,
                             IdTipoIntervento = evt.IdTipoIntervento,
                             IdCommittente = Guid.Empty,
                             Deleted = false,
                             NumeroTrenoPartenza = evt.TrenoPartenza.NumeroTreno,
                             DataTrenoPartenza = evt.TrenoPartenza.Data,
                             StartDateProgrammata = evt.WorkPeriod.StartDate,
                             EndDateProgrammata = evt.WorkPeriod.EndDate,
                             ComposizioneProgrammata = "to be done",
                             StartDateConsuntivataAppaltatore = evt.WorkPeriod.StartDate,
                             EndDateConsuntivataAppaltatore = evt.WorkPeriod.EndDate
                         };

                container.ConsuntivazioneRots.AddObject(cons);
                container.SaveChanges();
            }
        }

       

    }
}
