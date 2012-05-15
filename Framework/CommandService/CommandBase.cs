using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using CommonDomain;

namespace CommandService
{
    [Serializable]
    [DataContract]
    [KnownType("GetKnownTypes")]
    public abstract class CommandBase : ICommand
    {
        public abstract string ToDescription();

        public static Type[] GetKnownTypes()
        {
            var types = from asm in AppDomain.CurrentDomain.GetAssemblies()
                        from type in asm.GetTypes()
                        where typeof(CommandBase).IsAssignableFrom(type)
                        select type;

            return types.ToArray();
        }
    }
}
