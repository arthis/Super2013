using System;
using System.Runtime.Serialization;
using CommonDomain;
using CommonDomain.Core;

namespace CommandService
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class CommandWebServiceFault
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Order = 0)]
        public CommandBase CommandBase { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Order = 1)]
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CommandWebServiceFault()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandBase"></param>
        /// <param name="ex"></param>
        public CommandWebServiceFault(CommandBase commandBase, Exception ex)
        {
            CommandBase = commandBase;
            Message = ex.Message;
        }
    }
}