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
        public  static ContabilitaContainer GetContainer()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Super2013"].ConnectionString;
            return new ContabilitaContainer(connectionString);
        }
    }
}
