using System;

namespace Utilities.Arguments
{
	/// <summary>
	/// Extension class for method parameters
	/// </summary>
	public static class ArgumentExtensions
	{
		/// <summary>
		/// Throw <see cref="ArgumentNullException"/> if argument is null
		/// </summary>
		/// <param name="arg">Parameter to check for null</param>
		/// <param name="exceptionMessage">The exception message</param>
		public static void ThrowIfNull(this object arg, string exceptionMessage = null)
		{
			if (arg == null)
			{
				throw new ArgumentNullException(exceptionMessage);
			}
		}
	}
}