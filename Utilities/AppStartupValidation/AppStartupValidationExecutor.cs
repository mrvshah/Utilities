using System;
using System.Collections.Generic;
using Utilities.Arguments;

namespace Utilities.AppStartupValidation
{
	/// <summary>
	/// Class to validate all validators
	/// </summary>
	/// <example>
	///     <code lang="cs" title="The following code example demonstrates the usage of AppStartupValidationExecutor">
	///         <code 
	///             source="..\..\UtilitiesSnippets\AppStartupValidation\Program.cs" 
	///         />
	///     </code>
	/// </example>
	public static class AppStartupValidationExecutor
	{
		/// <summary>
		/// Calls Validate method on all validators
		/// </summary>
		/// <param name="validators">The validators</param>
		/// <exception cref="ArgumentNullException"/>
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