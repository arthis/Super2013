using System;
using NServiceBus;

namespace Server
{
   public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher  
   {
      public void Init()
      {
         Configure.With()
            .DefaultBuilder()
            .BinarySerializer()
            .InstallNcqrs()
            .MsmqTransport()
            .PurgeOnStartup(true);
      }
   }
}