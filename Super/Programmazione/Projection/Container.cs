using System.Configuration;
using Super.ReadModel;

namespace Super.Programmazione.Projection
{
    public static class Container
    {
        public  static ProgrammazioneEntities GetEntities()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Super2013.Programmazione.ReadStore"].ConnectionString;
            return new ProgrammazioneEntities(connectionString);
        }
    }
}
