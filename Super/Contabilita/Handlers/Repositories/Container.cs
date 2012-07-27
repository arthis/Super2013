using System.Configuration;
using Super.ReadModel;

namespace Super.Contabilita.Handlers.Repositories
{
    public static class Container
    {
        public  static ContabilitaEntities GetEntities()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Super2013.Contabilita.ReadStore"].ConnectionString;
            return new ContabilitaEntities(connectionString);
        }
    }
}
