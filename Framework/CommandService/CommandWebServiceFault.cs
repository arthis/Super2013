using System;
using System.Runtime.Serialization;
using CommonDomain;
using CommonDomain.Core;

namespace CommandService
{
    /// <summary>
    /// 
    /// </summary>
    public class CommandWebServiceFault
    {
        /// <summary>
        /// 
        /// </summary>
        public CommandBase CommandBase { get; set; }

        /// <summary>
        /// 
        /// </summary>
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