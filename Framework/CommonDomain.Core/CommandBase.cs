using System;
using System.Linq;
using System.Runtime.Serialization;

namespace CommonDomain.Core
{
    [Serializable]
    [DataContract]
    [KnownType("GetKnownTypes")]
    public abstract class CommandBase : ICommand
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public Guid CommitId { get; set; }
    
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
