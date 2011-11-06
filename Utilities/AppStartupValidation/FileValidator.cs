using System;
using System.Collections.Generic;
using System.IO;
using Utilities.Arguments;

namespace Utilities.AppStartupValidation
{
	///<summary>
	/// Validates by checking if file exists
	///</summary>
	public class FileValidator : IValidator
	{
		/// <summary>
		/// Physical path of files to validate
		/// </summary>
		private readonly IEnumerable<string> filePathsToValidate;

		/// <summary>
		/// Initializes a new instance of the <see cref="FileValidator"/> class
		/// </summary>
		/// <param name="filePathsToValidate">Physical path of files to validate</param>
		/// <exception cref="ArgumentNullException"/>
		public FileValidator(IEnumerable<string> filePathsToValidate)
		{
			filePathsToValidate.ThrowIfNull();

			this.filePathsToValidate = filePathsToValidate;
		}

		/// <summary>
		/// Loops through each path and check if it exists
		/// </summary>
		/// <exception cref="FileNotFoundException"/>
		public void Validate()
		{
			foreach (var path in filePathsToValidate)
			{
				if (!File.Exists(path))
				{
					throw new FileNotFoundException(path);
				}
			}
		}
	}
}