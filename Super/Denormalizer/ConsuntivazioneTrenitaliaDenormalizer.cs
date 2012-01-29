using System.Linq;
using Events;
using Ncqrs.Eventing.ServiceModel.Bus;
using System;
using System.Diagnostics.Contracts;
using PEC = Denormalizers.DTO.PEC;
using Mail;


namespace Denormalizers
{
    public class ConsuntivazioneTrenitaliaDenormalizer : IEventHandler<InterventoConsuntivatoDaTrenitalia>
    {
        

        public ConsuntivazioneTrenitaliaDenormalizer()
        {
        }

        public void Handle(IPublishedEvent<InterventoConsuntivatoDaTrenitalia> evnt)
        {
            ////Contract.Requires<ArgumentNullException>(_SendMessage != null);

            ////send mail
            //string to = "super.testti@cert.trenitalia.it";
            //string from = "super.testti@cert.trenitalia.it";
            //string oggetto = "oggetto";
            //string filename = "filename.xls";

            //PEC.Intervento i = new PEC.Intervento()
            //{
            //    IdInterventoSuper = evnt.Payload.IdInterventoSuper,
            //    IdInterventoAppaltatore = evnt.Payload.IdInterventoAppaltatore,
            //    Inizio = evnt.Payload.Inizio,
            //    Fine = evnt.Payload.Fine
            //};

            //byte[] allegato = Tools.Serialization.SerializeAndCompress(i);

            //_SendMessage.SendMessage(from, to, oggetto, filename, allegato);

        }

    }
}