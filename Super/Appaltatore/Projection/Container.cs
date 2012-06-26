using System.Configuration;
using Super.ReadModel;

namespace Super.Appaltatore.Projection
{
    public static class Container
    {
        public  static AppaltatoreContainer GetContainer()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Super2013"].ConnectionString;
            return new AppaltatoreContainer(connectionString);
        }
    }
}
