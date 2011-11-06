using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Utilities.AppStartupValidation;

namespace Tests.AppStartupValidation
{
	[TestFixture]
	public class FileValidatorTests
	{
		[Test]
		public void ConstructorRequiresListOfPathsToValidate()
		{
			var physicalPathsToValidate = new List<string>();

			new FileValidator(physicalPathsToValidate);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ConstructorThrowsArgumentNullExceptionWhenListOfPathsToValidateIsNull()
		{
			new FileValidator(null);
		}

		[Test]
		public void ValidationPassesWhenAllPathsArePresent()
		{
			new FileValidator(GetAllValidPaths());
		}

		[Test]
		[ExpectedException(typeof(FileNotFoundException))]
		public void ValidationFailsWhenAnInValidKeyIsEncountered()
		{
			new FileValidator(GetPathsWithAtleastOneInValid()).Validate();
		}

		private IEnumerable<string> GetAllValidPaths()
		{
			var currentDirecotry = Directory.GetCurrentDirectory();
			var path1 = string.Format(@"{0}\FileValidatorData\File1.txt", currentDirecotry);
			var path2 = string.Format(@"{0}\FileValidatorData\File2.txt", currentDirecotry);

			return new[] { path1, path2 };
		}

		private IEnumerable<string> GetPathsWithAtleastOneInValid()
		{
			var currentDirecotry = Directory.GetCurrentDirectory();
			var validPath = string.Format(@"{0}\FileValidatorData\File1.txt", currentDirecotry);
			var invalidPath = string.Format(@"{0}\FileValidatorData\NonExistentFile.txt", currentDirecotry);

			return new[] { validPath, invalidPath };
		}
	}
}