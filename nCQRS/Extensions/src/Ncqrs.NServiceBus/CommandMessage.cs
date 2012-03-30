using System;
using Ncqrs.Commanding;
using NServiceBus;

namespace Ncqrs.NServiceBus
{
   [Serializable]
   public class CommandMessage : IMessage
   {
       public Ncqrs.Commanding.ICommand Payload { get; set; }
   }
}