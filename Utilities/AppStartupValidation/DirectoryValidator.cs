using System.Collections.Generic;
using System.IO;
using Utilities.AppStartupValidators;
using Utilities.Arguments;

namespace Utilities.AppStartupValidation
{
	/// <summary>
	/// Directory validator
	/// </summary>
	public class DirectoryValidator : IValidator
	{
		/// <summary>
		/// Physical path of directories to validate
		/// </summary>
		private readonly IEnumerable<string> physicalPathsToValidate;

		/// <summary>
		/// Initializes a new instance of the <see cref="DirectoryValidator"/> class
		/// </summary>
		/// <param name="physicalPathsToValidate">Physical path of directories to validate</param>
		public DirectoryValidator(IEnumerable<string> physicalPathsToValidate)
		{
			physicalPathsToValidate.ThrowIfNull();

			this.physicalPathsToValidate = physicalPathsToValidate;
		}

		/// <summary>
		/// Enables validation by custom validator
		/// </summary>
		public void Validate()
		{
			foreach (var path in physicalPathsToValidate)
			{
				if (!Directory.Exists(path))
				{
					throw new DirectoryNotFoundException(path);
				}
			}
		}
	}
}