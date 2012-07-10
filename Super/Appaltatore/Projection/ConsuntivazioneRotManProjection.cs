using System;
using System.Configuration;
using System.Linq;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using Super.ReadModel;
using Super.Appaltatore.Events.Programmazione;

namespace Super.Appaltatore.Projection
{
    public class ConsuntivazioneRotManProjection : IEventHandler<InterventoRotManProgrammato>
    {

        private AppaltatoreContainer GetContainer()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Super2013"].ConnectionString;
            return new AppaltatoreContainer(connectionString);
        }

        public void Handle(InterventoRotManProgrammato evt)
        {

            throw  new NotImplementedException();

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
            //                 IdImpianto = evt.IdImpianto,
            //                 IdTipoIntervento = evt.IdTipoIntervento,
            //                 IdCommittente = Guid.Empty,
            //                 ImpiantoDescription = "to be fetched",
            //                 TipoInterventoDescription = "to be fetched",
            //                 Deleted = false,
            //                 //etc... to be done later
            //             };

            //    container.ConsuntivazioneRots.AddObject(cons);
            //    container.SaveChanges();
            //}
        }

    }
}
