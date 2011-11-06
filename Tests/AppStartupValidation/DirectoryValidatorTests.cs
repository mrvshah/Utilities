using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Utilities.AppStartupValidation;

namespace Tests.AppStartupValidation
{
	[TestFixture]
	public class DirectoryValidatorTests
	{
		[Test]
		public void ConstructorRequiresListOfPathsToValidate()
		{
			var physicalPathsToValidate = new List<string>();

			new DirectoryValidator(physicalPathsToValidate);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ConstructorThrowsArgumentNullExceptionWhenListOfPathsToValidateIsNull()
		{
			new DirectoryValidator(null);
		}

		[Test]
		public void ValidationPassesWhenAllPathsArePresent()
		{
			new DirectoryValidator(GetAllValidPaths());
		}

		[Test]
		[ExpectedException(typeof(DirectoryNotFoundException))]
		public void ValidationFailsWhenAnInValidKeyIsEncountered()
		{
			new DirectoryValidator(GetPathsWithAtleastOneInValid()).Validate();
		}

		private IEnumerable<string> GetAllValidPaths()
		{
			var currentDirecotry = Directory.GetCurrentDirectory();
			var path1 = currentDirecotry.Replace(@"bin\Debug", @"AppStartupValidation\DirectoryValidatoryTestPath1");
			var path2 = currentDirecotry.Replace(@"bin\Debug", @"AppStartupValidation\DirectoryValidatoryTestPath2");

			return new[] { path1, path2 };
		}

		private IEnumerable<string> GetPathsWithAtleastOneInValid()
		{
			var currentDirecotry = Directory.GetCurrentDirectory();
			var validPath = currentDirecotry.Replace(@"bin\Debug", @"AppStartupValidation\DirectoryValidatoryTestPath1");
			var invalidPath = currentDirecotry.Replace(@"bin\Debug", @"AppStartupValidation\InvalidPath");

			return new[] { validPath, invalidPath };
		}
	}
}