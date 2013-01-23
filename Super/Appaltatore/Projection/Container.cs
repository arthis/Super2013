using System.Configuration;
using Super.Appaltatore.ReadModel;

namespace Super.Appaltatore.Projection
{
    public static class Container
    {
        public  static   AppaltatoreEntities GetEntities()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Super2013.Appaltatore.ReadStore"].ConnectionString;
            return new AppaltatoreEntities(connectionString);
        }
    }
}
