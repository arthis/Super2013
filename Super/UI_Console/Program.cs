using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Ncqrs.CommandService;
using Ncqrs.CommandService.Contracts;
using Commands;
using Commands.Interventi;


namespace UI_Console
{
    class Program
    {
        private static ChannelFactory<ICommandWebServiceClient> _channelFactory;

        static void Main(string[] args)
        {

            _channelFactory = new ChannelFactory<ICommandWebServiceClient>("CommandWebServiceClient");

            //ServiceReference.MassiveServiceClient client = new ServiceReference.MassiveServiceClient();
            //client.Execute(new SendEmailCommand() { Body = "body", Subject = "subject" });

            Guid g = Guid.NewGuid();
            Guid gAi = Guid.NewGuid();
            DateTime inizio = DateTime.Today;
            DateTime fine = DateTime.Today.AddMonths(1);

            //CreareNuovoAreaIntervento nuovaAreaIntervento = new CreareNuovoAreaIntervento()
            //{
            //    Inizio = inizio,
            //    Fine = fine,
            //    Id = gAi
            //};

            //ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
            //                 client.Execute(new ExecuteRequest(nuovaAreaIntervento)));


            //CreareNuovoInterventoRotabile nuovoIntervento = new CreareNuovoInterventoRotabile()
            //{
            //    Id = g,
            //    InterventoIdSuper = 999,
            //    Inizio = inizio,
            //    Fine = fine,
            //    IdAreaIntervento = gAi
            //};

            //ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
            //                    client.Execute(new ExecuteRequest(nuovoIntervento)));

            //ConsuntivareRotabileResoDaAppaltatore consAppaltatore = new ConsuntivareRotabileResoDaAppaltatore()
            //{
            //    Id = g,
            //    InterventoIdAppaltatore = "idAppa",
            //    Inizio = inizio,
            //    Fine = fine,
            //};

            //ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
            //                    client.Execute(new ExecuteRequest(consAppaltatore)));



            //ConsuntivareDaAppaltatore consAppaltatore = new ConsuntivareDaAppaltatore()
            //{
            //    Id = g,
            //    InterventoIdAppaltatore = "21212sds",
            //    Inizio = inizio.AddMinutes(2),
            //    Fine = fine.AddMinutes(-2)
            //};

            //ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
            //                    client.Execute(new ExecuteRequest(consAppaltatore)));

            //ConsuntivareDaTrenitalia consTrenitalia = new ConsuntivareDaTrenitalia()
            //{
            //    Id = g,
            //    IsResoTrenitalia = true,
            //    Inizio = inizio.AddMinutes(2),
            //    Fine = fine.AddMinutes(1)
            //};


            //ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
            //                   client.Execute(new ExecuteRequest(consTrenitalia)));



        }
    }
}
