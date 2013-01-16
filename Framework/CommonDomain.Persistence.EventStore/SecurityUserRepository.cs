using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CommonDomain.Core;

namespace CommonDomain.Persistence.EventStore
{
    public class SecurityUserRepository : ISecurityUserRepository
    {

        public ISecurityUser GetUser(Guid securityToken)
        {
            //fetch admin rights
            var commandi = new List<Regex>() { new Regex(".*") };
            var committenti = new List<Guid>();
            var lotti = new List<Guid>();
            var tiipiIntervento = new List<Guid>();
            //fetch the correct user in the database
            return new SecurityUser(Guid.NewGuid(), commandi, committenti, lotti, tiipiIntervento);
        }
    }
    

}
