using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CommonDomain.Core;

namespace CommandService
{
    /// <summary>
    /// 
    /// </summary>
    [ServiceContract]
    public interface ICommandWebService
    {
        /// <summary>
        /// 
        /// </summary>
        [OperationContract]
        ExecuteResponse Execute(CommandBase command);
    }
}
