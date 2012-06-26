using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using EasyNetQ;
using Newtonsoft.Json;
using Super.Appaltatore.Commands.Builders;
using Super.Programmazione.Events;


namespace UI_Console
{
    class Program
    {
        static IBus Bus;


        static void Main(string[] args)
        {
            var id = Guid.NewGuid();
            var idAppaltatore = Guid.NewGuid();
            var trenoArrivo = new Treno("99", DateTime.Now.AddHours(-12));
            var trenoPartenza = new Treno("999", DateTime.Now.AddHours(-1));
            string convoglio = "convoglio";

            var noteCons = "noteCons";
            var period = new WorkPeriod(DateTime.Now.AddHours(-4), DateTime.Now.AddHours(-2));



            InterventoRotPianificato evt = new InterventoRotPianificato()
                                              {
                                                  CommitId = Guid.NewGuid(),
                                                  Convoglio = convoglio,
                                                  TrenoArrivo = trenoArrivo,
                                                  TrenoPartenza = trenoPartenza,
                                                  Id = id,
                                                  IdAppaltatore = idAppaltatore,
                                                  IdImpianto = Guid.NewGuid(),
                                                  IdCategoriaCommerciale = Guid.NewGuid(),
                                                  IdDirezioneRegionale = Guid.NewGuid(),
                                                  Note = "note",
                                                  IdTipoIntervento = Guid.NewGuid(),
                                                  Period = new WorkPeriod(DateTime.Now.AddHours(-5),DateTime.Now.AddHours(-4)),
                                                  RigaTurnoTreno = "riga",
                                                  TurnoTreno = "turno",
                                                  Oggetti = new List<OggettoRot>() { new OggettoRot("desc",12, Guid.NewGuid())}
                                                                                   .ToArray()
                                              };

            //client.Execute(cmd);    
            Bus = RabbitHutch.CreateBus("host=localhost");

            Bus.Publish(evt);

            //var service = new Appaltatore.CommandWebServiceClient();
            //var builder = new ConsuntivareRotResoBuilder();
            //builder.
            //var executeRequest = new Appaltatore.ExecuteRequest()
            //                         { CommandBase = };
            //service.Execute()
        }







        //static void ExecutorMessage(CreareNuovoImpianto cmd)
        //{
        //    Console.WriteLine("---------------------------------");

        //    var evt = new ImpiantoCreata()
        //    {
        //        Id = Guid.NewGuid(),
        //        CreationDate = DateTime.Now,
        //        Description = "test descrizione",
        //        Start = DateTime.Now,
        //        End = DateTime.Now,
        //        IdImpiantoSuper = 12
        //    };

        //    Bus.Publish<ImpiantoCreata>(evt);



        //}
    }


}
