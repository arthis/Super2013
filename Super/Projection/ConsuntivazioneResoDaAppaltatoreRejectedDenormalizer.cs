using System.Linq;
using Events.Interventi;
using Ncqrs.Eventing.ServiceModel.Bus;
using System;
using System.Diagnostics.Contracts;
using PEC = Denormalizers.DTO.PEC;
using Mail;
using System.Text;


namespace Denormalizers
{
    //public class ConsuntivazioneResoDaAppaltatoreRejectedDenormalizer : IEventHandler<ConsuntivazioneResoDaAppaltatoreRejected>
    //{
    //    private readonly ISendMessage _SendMessage;

    //    public ConsuntivazioneResoDaAppaltatoreRejectedDenormalizer(ISendMessage sendMessage)
    //    {
    //        Contract.Requires(sendMessage != null);

    //        _SendMessage = sendMessage;
    //    }

    //    public void Handle(IPublishedEvent<ConsuntivazioneResoDaAppaltatoreRejected> evnt)
    //    {
    //        //Contract.Requires<ArgumentNullException>(_SendMessage != null);

    //        //send mail
    //        //string to = "super.testti@cert.trenitalia.it";
    //        //string from = "super.testti@cert.trenitalia.it";
    //        //string oggetto = "Intervento Consuntivato Da Appaltatore";
    //        //string filename = "consuntivo.xml";

    //        //PEC.Intervento i = new PEC.Intervento()
    //        //{
    //        //    IdInterventoSuper = evnt.Payload.IdInterventoSuper,
    //        //    IdInterventoAppaltatore = evnt.Payload.IdInterventoAppaltatore,
    //        //    Inizio = evnt.Payload.Inizio,
    //        //    Fine = evnt.Payload.Fine
    //        //};

    //        //byte[] allegato =  Encoding.UTF8.GetBytes(Tools.Serialization.Serialize(i));

    //        //_SendMessage.SendMessage(from, to, oggetto, filename, allegato);

    //    }

    //}
}