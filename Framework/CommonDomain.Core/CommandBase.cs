using System;
using System.Linq;
using System.Runtime.Serialization;

namespace CommonDomain.Core
{
    [Serializable]
    [KnownType("GetKnownTypes")]
    public abstract class CommandBase : Message, ICommand
    {
        public bool IsExecuted { get; set; }
        public Guid SecurityToken { get; set; }
        

        public CommandBase()
        {
            
        }

        public CommandBase(Guid id, Guid commitId, long version)
            :base(id,commitId,version)
        {
            
        }

        public static Type[] GetKnownTypes()
        {
            var types = from asm in AppDomain.CurrentDomain.GetAssemblies()
                        from type in asm.GetTypes()
                        where
                            typeof(CommandBase).IsAssignableFrom(type) && !type.IsAbstract
                        select type;

            return types.ToArray();
        }
    }
}
