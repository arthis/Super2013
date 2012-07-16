using System.Configuration;
using Super.ReadModel;

namespace Super.Contabilita.Handlers.Repositories
{
    public static class Container
    {
        public  static ContabilitaContainer GetContainer()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Super2013"].ConnectionString;
            return new ContabilitaContainer(connectionString);
        }
    }
}
