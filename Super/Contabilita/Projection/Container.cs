using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Super.ReadModel;

namespace Super.Contabilita.Projection
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
