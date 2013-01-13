using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Super.Programmazione.Domain.Programma;

namespace Super.Controllo.Domain
{
    public class SecurityUserControllo : CommonDomain.Core.SecurityUser
    {
        public SecurityUserControllo(Guid idUser, IEnumerable<Regex> commands, IEnumerable<Guid> committenti, IEnumerable<Guid> lotti, IEnumerable<Guid> tipiIntervento) 
            : base(idUser, commands, committenti, lotti, tipiIntervento)
        {
        }

        public void CancelScenario(Scenario scenario)
        {
            scenario.Cancel(IdUser);
        }
    }
}
