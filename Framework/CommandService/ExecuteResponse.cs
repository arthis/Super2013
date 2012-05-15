using System.ServiceModel;

namespace CommandService
{
    [MessageContract(WrapperName = "ExecuteResponse")]
    public class ExecuteResponse
    {
    }
}