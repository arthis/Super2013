using System.Diagnostics.Contracts;
using CommonDomain.Core.Handlers;

namespace CommonDomain.Core
{
	using System.Globalization;

	internal static class ExtensionMethods
	{
		public static string FormatWith(this string format, params object[] args)
		{
            Contract.Requires(args != null);
			return string.Format(CultureInfo.InvariantCulture, format ?? string.Empty, args);
		}

		public static void ThrowHandlerNotFound(this IAggregate aggregate, object eventMessage)
		{
            //var exceptionMessage = "Aggregate of type '{0}' raised an event of type '{1}' but not handler could be found to handle the message."
            //    .FormatWith(aggregate.GetType().Name, eventMessage.GetType().Name);

            //throw new HandlerForMessageNotFoundException(exceptionMessage);

            //when the handler is not found we just continue
		}
	}
}