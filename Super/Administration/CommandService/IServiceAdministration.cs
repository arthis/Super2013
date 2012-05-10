using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonCommands;
using CommonDomain;

namespace CommandService
{
    public interface IServiceAdministration
    {
        void Start();
        void Execute(ICommand command);
    }
}
