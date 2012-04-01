using System;

namespace Cqrs.Commanding.CommandExecution.Mapping.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public sealed class TransactionalAttribute : Attribute
    {
    }
}