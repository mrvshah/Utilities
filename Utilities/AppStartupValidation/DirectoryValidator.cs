using System;
using System.Collections.Generic;
using System.IO;
using Utilities.Arguments;

namespace Utilities.AppStartupValidation
{
	/// <summary>
	/// Validates by checking if directory exists
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
		/// <exception cref="ArgumentNullException"/>
		public DirectoryValidator(IEnumerable<string> physicalPathsToValidate)
		{
			physicalPathsToValidate.ThrowIfNull();

			this.physicalPathsToValidate = physicalPathsToValidate;
		}

		/// <summary>
		/// Loops through each path and validate if it exists
		/// </summary>
		/// <exception cref="DirectoryNotFoundException"/>
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