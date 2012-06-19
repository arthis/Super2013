using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Super.Domain.ValueObjects;
using EasyNetQ;
using Newtonsoft.Json;
using Super.Programmazione.Events;


namespace UI_Console
{
    class Program
    {
        static IBus Bus;


        static void Main(string[] args)
        {


            InterventoRotPianificato evt = new InterventoRotPianificato()
                                              {
                                                  CommitId = Guid.NewGuid(),
                                                  Convoglio = "convoglio",
                                                  DataTrenoArrivo = DateTime.Now,
                                                  DataTrenoPartenza = DateTime.Now,
                                                  End = DateTime.Now.AddHours(12),
                                                  Id = Guid.NewGuid(),
                                                  IdAppaltatore = Guid.NewGuid(),
                                                  IdAreaIntervento = Guid.NewGuid(),
                                                  IdCategoriaCommerciale = Guid.NewGuid(),
                                                  IdDirezioneRegionale = Guid.NewGuid(),
                                                  Note = "note",
                                                  IdTipoIntervento = Guid.NewGuid(),
                                                  NumeroTrenoArrivo = "999",
                                                  NumeroTrenoPartenza = "888",
                                                  RigaTurnoTreno = "riga",
                                                  Start = DateTime.Now.AddHours(10),
                                                  TurnoTreno = "turno",
                                                  Oggetti = new List<OggettoRot>() { new OggettoRot()
                                                                                     {
                                                                                         Descrizione = "desc",
                                                                                         IdTipoOggettoInterventoRot = Guid.NewGuid(),
                                                                                         Quantita = 12
                                                                                     } 
                                                                                }.ToArray()

                                              };

            //client.Execute(cmd);    
            Bus = RabbitHutch.CreateBus("host=localhost");

            Bus.Publish(evt);

        }







        //static void ExecutorMessage(CreareNuovoAreaIntervento cmd)
        //{
        //    Console.WriteLine("---------------------------------");

        //    var evt = new AreaInterventoCreata()
        //    {
        //        Id = Guid.NewGuid(),
        //        CreationDate = DateTime.Now,
        //        Descrizione = "test descrizione",
        //        Start = DateTime.Now,
        //        End = DateTime.Now,
        //        IdAreaInterventoSuper = 12
        //    };

        //    Bus.Publish<AreaInterventoCreata>(evt);



        //}
    }


}
