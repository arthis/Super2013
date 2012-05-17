using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.ServiceModel;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Super.Administration.Commands.AreaIntervento;
using UI_Console.ServiceReference1;



namespace UI_Console
{
    class Program
    {
        //static IBus Bus;

        static void Main(string[] args)
        {

            var cmd = new CreateAreaIntervento()
                          {
                              CommitId = Guid.NewGuid(),
                              Id = Guid.NewGuid(),
                              CreationDate = DateTime.Now,
                              Description = "ttt",
                              End = DateTime.Now,
                              Start = DateTime.Now,

                          };
            var client = new CommandWebServiceClient();

            client.Endpoint.Behaviors.Add(
                   new SimpleEndpointBehavior()
                   );
            var executeRequest = new ExecuteRequest(){ CommandBase = cmd};


            var validation = client.Execute(executeRequest);

            string s = "dfdf";

            //client.Execute(cmd);    
            //Bus = RabbitHutch.CreateBus("host=localhost");

            //string subscriptionId = "Super";
            //Bus.Subscribe<CreareNuovoAreaIntervento>(subscriptionId, msg => ExecutorMessage(msg));
        }

        //static void ExecutorMessage(CreareNuovoAreaIntervento cmd)
        //{
        //    Console.WriteLine("---------------------------------");

        //    var evt = new AreaInterventoCreata()
        //    {
        //        Id = Guid.NewGuid(),
        //        CreationDate = DateTime.Now,
        //        Descrizione = "test descrizione",
        //        Inizio = DateTime.Now,
        //        Fine = DateTime.Now,
        //        IdAreaInterventoSuper = 12
        //    };

        //    Bus.Publish<AreaInterventoCreata>(evt);



        //}
    }

    public class SimpleEndpointBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        { }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(
                new SimpleMessageInspector()
                );
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        { }
        public void Validate(ServiceEndpoint endpoint)
        { }
    }

    public class SimpleMessageInspector : IClientMessageInspector, IDispatchMessageInspector
    {
        #region IClientMessageInspector Members

        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        { }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {

            Console.WriteLine("====SimpleMessageInspector+BeforeSendRequest is called=====");

            

            return null;
        }




        #endregion



        #region IDispatchMessageInspector Members

        public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
        {
            return null;
        }

        public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        { }
        #endregion
    }
}
