using System.Collections.Generic;
using System.IO;
using Utilities.AppStartupValidators;
using Utilities.Arguments;

namespace Utilities.AppStartupValidation
{
	///<summary>
	/// File validator
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
		public FileValidator(IEnumerable<string> filePathsToValidate)
		{
			filePathsToValidate.ThrowIfNull();

			this.filePathsToValidate = filePathsToValidate;
		}

		/// <summary>
		/// Enables validation by custom validator
		/// </summary>
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