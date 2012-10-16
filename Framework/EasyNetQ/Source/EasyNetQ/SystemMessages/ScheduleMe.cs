using System;
using CommonDomain;

namespace EasyNetQ.SystemMessages
{
    [Serializable]
    public class ScheduleMe  
    {
        public DateTime WakeTime { get; set; }
        public string BindingKey { get; set; }
        public byte[] InnerMessage { get; set; }

        
    }
}