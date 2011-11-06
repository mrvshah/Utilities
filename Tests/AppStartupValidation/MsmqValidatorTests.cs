using System;
using System.Collections.Generic;
using NUnit.Framework;
using Utilities.AppStartupValidation;
using Utilities.Exceptions;

namespace Tests.AppStartupValidation
{
	[TestFixture]
	public class MsmqValidatorTests
	{
		[Test]
		public void ConstructorRequiresListOfKeysToValidate()
		{
			var keysToValidate = new List<string>();

			new MsmqValidator(keysToValidate);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ConstructorThrowsArgumentNullExceptionWhenListOfKeysToValidateIsNull()
		{
			new MsmqValidator(null);
		}

		[Test, Ignore, Category(TestCategories.INTEGRATION)]
		public void ValidationPassesWhenAllKeysArePresent()
		{
			new MsmqValidator(GetAllValidKeys());
		}

		[Test, Ignore, Category(TestCategories.INTEGRATION)]
		[ExpectedException(typeof(MissingMessageQueueException))]
		public void ValidationFailsWhenAnInValidKeyIsEncountered()
		{
			new MsmqValidator(GetKeysWithAtleastOneInValid()).Validate();
		}

		private IEnumerable<string> GetAllValidKeys()
		{
			return new[] { "Email", "Logging" };
		}

		private IEnumerable<string> GetKeysWithAtleastOneInValid()
		{
			return new[] { "Email", "NonExistentQueue" };
		}
	}
}