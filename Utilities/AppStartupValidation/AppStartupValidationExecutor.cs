using System.Collections.Generic;
using Utilities.AppStartupValidators;
using Utilities.Arguments;

namespace Utilities.AppStartupValidation
{
	/// <summary>
	/// Class to validate all validators
	/// </summary>
	public static class AppStartupValidationExecutor
	{
		/// <summary>
		/// Calls Validate method on all validators
		/// </summary>
		/// <param name="validators">The validators</param>
		public static void ValidateAll(IEnumerable<IValidator> validators)
		{
			validators.ThrowIfNull();

			foreach (var validator in validators)
			{
				validator.Validate();
			}
		}
	}
}