using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CommonDomain
{
    [Serializable]
    [DataContract]
    [KnownType("GetKnownTypes")]
    public abstract class ICommandValidation
    {
        public abstract IEnumerable<IValidationMessage> GetErrors();
        public abstract void Add(IValidationMessage error);

        public static Type[] GetKnownTypes()
        {
            var types = from asm in AppDomain.CurrentDomain.GetAssemblies()
                        from type in asm.GetTypes()
                        where typeof(ICommandValidation).IsAssignableFrom(type)
                        select type;

            return types.ToArray();
        }
    }

    [Serializable]
    [DataContract]
    [KnownType("GetKnownTypes")]
    public abstract class IValidationMessage
    {
        public static Type[] GetKnownTypes()
        {
            var types = from asm in AppDomain.CurrentDomain.GetAssemblies()
                        from type in asm.GetTypes()
                        where typeof(IValidationMessage).IsAssignableFrom(type)
                        select type;

            return types.ToArray();
        }
    }
}
