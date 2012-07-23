using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Newtonsoft.Json;
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Commands.Lotto;
using UI_Console.Contabilita;


namespace UI_Console
{
    //class MyInspector : IClientMessageInspector
    //{
    //    public HashSet<string> oneWayActions;

    //    public MyInspector(ServiceEndpoint endpoint)
    //    {
    //        this.oneWayActions = new HashSet<string>();
    //        foreach (var operation in endpoint.Contract.Operations)
    //        {
    //            if (operation.IsOneWay)
    //            {
    //                oneWayActions.Add(operation.Messages[0].Action);
    //            }
    //        }
    //    }

    //    public void AfterReceiveReply(ref Message reply, object correlationState)
    //    {
    //        Console.WriteLine("In AfterReceiveReply");
    //    }

    //    public object BeforeSendRequest(ref Message request, IClientChannel channel)
    //    {
    //        Console.WriteLine("In BeginSendRequest");
    //        if (this.oneWayActions.Contains(request.Headers.Action))
    //        {
    //            Console.WriteLine("This is a one-way operation");
    //        }

    //        return null;
    //    }
    //}
    //class MyBehavior : IEndpointBehavior
    //{
    //    public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
    //    {
    //    }

    //    public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
    //    {
    //        clientRuntime.MessageInspectors.Add(new MyInspector(endpoint));
    //    }

    //    public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
    //    {
    //    }

    //    public void Validate(ServiceEndpoint endpoint)
    //    {
    //    }
    //}

    class Program
    {
        static IBus Bus;


        static void Main(string[] args)
        {

            //var id = Guid.NewGuid();
            //var cmdCreate = Build.CreateLotto
            //    .ForCreationDate(DateTime.Now)
            //    .ForDescription("test")
            //    .ForInterval(new Interval(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2)))
            //    .Build(id);


            //string baseAddress = "http://localhost:1338/Contabilita";
            //var factory = new ChannelFactory<ICommandWebService>(new BasicHttpBinding(), new EndpointAddress(baseAddress));
            //factory.Endpoint.Behaviors.Add(new MyBehavior());
            //ICommandWebService proxy = factory.CreateChannel();

            //proxy.Execute(cmdCreate);

            //((IClientChannel)proxy).Close();
            //factory.Close();

            var id = Guid.NewGuid();
            var commitId = Guid.NewGuid();
            var cmdCreate = Build.CreateLotto
                .ForCreationDate(DateTime.Now)
                .ForDescription("test")
                .ForInterval(new Interval(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2)))
                .Build(id, commitId,0);

            var client = new Contabilita.CommandWebServiceClient();

            client.Execute(cmdCreate);

            client.Execute(cmdCreate);

            var cmdUpdate = Build.UpdateLotto
               .ForDescription("test updated")
               .ForInterval(new Interval(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2)))
               .Build(id,1);

            client.Execute(cmdUpdate);

            //var id = Guid.NewGuid();
            //var idAppaltatore = Guid.NewGuid();
            //var trenoArrivo = new Treno("99", DateTime.Now.AddHours(-12));
            //var trenoPartenza = new Treno("999", DateTime.Now.AddHours(-1));
            //string convoglio = "convoglio";

            //var noteCons = "noteCons";
            //var period = new WorkPeriod(DateTime.Now.AddHours(-4), DateTime.Now.AddHours(-2));



            //InterventoRotGenerated evt = new InterventoRotGenerated()
            //                                  {
            //                                      CommitId = Guid.NewGuid(),
            //                                      Convoglio = convoglio,
            //                                      TrenoArrivo = trenoArrivo,
            //                                      TrenoPartenza = trenoPartenza,
            //                                      Id = id,
            //                                      IdAppaltatore = idAppaltatore,
            //                                      IdImpianto = Guid.NewGuid(),
            //                                      IdCategoriaCommerciale = Guid.NewGuid(),
            //                                      IdDirezioneRegionale = Guid.NewGuid(),
            //                                      Note = "note",
            //                                      IdTipoIntervento = Guid.NewGuid(),
            //                                      Interval = new WorkPeriod(DateTime.Now.AddHours(-5),DateTime.Now.AddHours(-4)),
            //                                      RigaTurnoTreno = "riga",
            //                                      TurnoTreno = "turno",
            //                                      Oggetti = new List<OggettoRot>() { new OggettoRot("desc",12, Guid.NewGuid())}
            //                                                                       .ToArray()
            //                                  };

            ////client.Execute(cmd);    
            //Bus = RabbitHutch.CreateBus("host=localhost");

            //Bus.Publish(evt);

            //var service = new Appaltatore.CommandWebServiceClient();
            //var builder = new ConsuntivareRotResoBuilder();
            //builder.
            //var executeRequest = new Appaltatore.ExecuteRequest()
            //                         { Message = };
            //service.Execute()
        }







        //static void ExecutorMessage(CreareNuovoImpianto cmd)
        //{
        //    Console.WriteLine("---------------------------------");

        //    var evt = new ImpiantoCreata()
        //    {
        //        Id = Guid.NewGuid(),
        //        CreationDate = DateTime.Now,
        //        Description = "test description",
        //        Start = DateTime.Now,
        //        End = DateTime.Now,
        //        IdImpiantoSuper = 12
        //    };

        //    Bus.Publish<ImpiantoCreata>(evt);



        //}
    }


}
