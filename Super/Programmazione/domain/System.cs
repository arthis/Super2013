using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super.Programmazione.Domain
{
    public static class System
    {
        public static User AddNewUser(Guid id, string firstName, string lastName)
        {
            return new User(id,firstName,lastName);
        }
    }
}
