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
			string path1 = null, path2 = null;

#if DEBUG
			path1 = currentDirecotry.Replace(@"bin\Debug", @"AppStartupValidation\DirectoryValidatorTestPath1");
#else
			path1 = currentDirecotry.Replace(@"bin\Release", @"AppStartupValidation\DirectoryValidatorTestPath1");
#endif

#if DEBUG
			path2 = currentDirecotry.Replace(@"bin\Debug", @"AppStartupValidation\DirectoryValidatorTestPath2");
#else
			path2 = currentDirecotry.Replace(@"bin\Release", @"AppStartupValidation\DirectoryValidatorTestPath2");
#endif

			return new[] { path1, path2 };
		}

		private IEnumerable<string> GetPathsWithAtleastOneInValid()
		{
			var currentDirecotry = Directory.GetCurrentDirectory();
			string validPath = null, invalidPath = null;

#if DEBUG
			validPath = currentDirecotry.Replace(@"bin\Debug", @"AppStartupValidation\DirectoryValidatorTestPath1");
#else
			validPath = currentDirecotry.Replace(@"bin\Release", @"AppStartupValidation\DirectoryValidatorTestPath1");
#endif

#if DEBUG
			invalidPath = currentDirecotry.Replace(@"bin\Debug", @"AppStartupValidation\InvalidPath");
#else
			invalidPath = currentDirecotry.Replace(@"bin\Release", @"AppStartupValidation\InvalidPath");
#endif

			return new[] { validPath, invalidPath };
		}
	}
}