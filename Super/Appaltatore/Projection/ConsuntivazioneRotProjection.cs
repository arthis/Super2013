using System;
using System.Configuration;
using System.Linq;
using CommonDomain.Core;
using Super.Administration.Events.AreaIntervento;
using Super.Administration.ReadModel;
using Super.Appaltatore.Events.Programmazione;

namespace Super.Appaltatore.Projection
{
    public class ConsuntivazioneRotProjection : IEventHandler<InterventoRotProgrammato>
    {

        private AppaltatoreContainer GetContainer()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Super2013.Appaltatore"].ConnectionString;
            return new AppaltatoreContainer(connectionString);
        }



        public void Handle(InterventoRotProgrammato evt)
        {
            using (var container = GetContainer())
            {
                ConsuntivazioneRot cons = container.ConsuntivazioneRots.SingleOrDefault(x => x.IdIntervento == evt.Id);
                if (cons != null)
                    throw new Exception("Entity already created with the same id");

                cons = new ConsuntivazioneRot()
                         {
                             IdIntervento = evt.Id,
                             CreationDate = DateTime.Now,
                             Start = evt.Start,
                             End = evt.End,
                             IdLotto = Guid.Empty,
                             IdAreaIntervento = evt.IdAreaIntervento,
                             IdTipoIntervento = evt.IdTipoIntervento,
                             IdCommittente = Guid.Empty,
                             Deleted = false,
                             NumeroTrenoPartenza = evt.NumeroTrenoPartenza,
                             DataTrenoPartenza = evt.DataTrenoPartenza,
                             StartDateProgrammata = evt.Start,
                             EndDateProgrammata = evt.End,
                             ComposizioneProgrammata = "to be done",
                             StartDateConsuntivataAppaltatore = evt.Start,
                             EndDateConsuntivataAppaltatore = evt.End
                         };

                container.ConsuntivazioneRots.AddObject(cons);
                container.SaveChanges();
            }
        }

       

    }
}
