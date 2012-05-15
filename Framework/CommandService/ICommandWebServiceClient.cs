using System.ServiceModel;

namespace CommandService
{
    public interface ICommandWebServiceClient : ICommandWebService, IClientChannel { }
}