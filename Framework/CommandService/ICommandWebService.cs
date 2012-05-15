using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

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
        [OperationContract(Action = "ExecuteRequest",
                           ReplyAction = "ExecuteResponse")]
        ExecuteResponse Execute(ExecuteRequest executeRequest);
    }
}
