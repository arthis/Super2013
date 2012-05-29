using System;
using System.Configuration;
using System.Linq;
using CommonDomain.Core;
using Super.Administration.Events.AreaIntervento;
using Super.Administration.ReadModel;
using Super.Appaltatore.Events.Programmazione;

namespace Super.Appaltatore.Projection
{
    public class ConsuntivazioneRotProjection : IEventHandler<InterventoRotProgrammato>,
                                                IEventHandler<AreaInterventoUpdated>

    {

        private AppaltatoreContainer GetContainer()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Super2013"].ConnectionString;
            return new AppaltatoreContainer(connectionString);
        }



        public void Handle(InterventoRotProgrammato evt)
        {
            throw new NotImplementedException();

            //Do something useful here ...

            //using (var container = GetContainer())
            //{
            //    ConsuntivazioneRot cons = container.ConsuntivazioneRots.SingleOrDefault(x => x.IdIntervento == @event.Id);
            //    if (cons != null)
            //        throw new Exception("Entity already created with the same id");

            //    cons = new ConsuntivazioneRot()
            //             {
            //                 IdIntervento = evt.Id,
            //                 CreationDate = DateTime.Now,
            //                 Start = evt.Start,
            //                 End = evt.End,
            //                 IdLotto = Guid.Empty,
            //                 IdAreaIntervento = evt.IdAreaIntervento,
            //                 IdTipoIntervento = evt.IdTipoIntervento,
            //                 IdCommittente = Guid.Empty,
            //                 AreaInterventoDescrizione = "to be fetched",
            //                 TipoInterventoDescrizione = "to be fetched",
            //                 Deleted = false,
            //                 //etc... to be done later
            //             };

            //    container.ConsuntivazioneRots.AddObject(cons);
            //    container.SaveChanges();
            //}
        }

        public void Handle(AreaInterventoUpdated evt)
        {
            using (var container = GetContainer())
            {
                var cons = container.ConsuntivazioneRots.ToList();


                foreach (var consuntivazioneRot in cons)
                {
                    consuntivazioneRot.AreaInterventoDescription = evt.Description;
                }

                container.SaveChanges();
            }
        }

    }
}
