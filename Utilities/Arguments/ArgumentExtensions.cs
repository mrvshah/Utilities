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
		public static void ThrowIfNull(this object arg)
		{
			ThrowArgumentNullException(arg);
		}

		/// <summary>
		/// Loops through each argument and throws <see cref="ArgumentNullException"/> for first null encountered
		/// </summary>
		/// <param name="args">Parameters to check for null</param>
		public static void ThrowIfNull(this object[] args)
		{
			ThrowArgumentNullException(args);

			foreach (var arg in args)
			{
				ThrowArgumentNullException(arg);
			}
		}

		private static void ThrowArgumentNullException(object arg)
		{
			if (arg == null)
			{
				throw new ArgumentNullException();
			}
		}
	}
}