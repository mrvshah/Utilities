using System;
using System.Collections.Generic;
using System.Configuration;
using NUnit.Framework;
using Utilities.AppStartupValidation;

namespace Tests.AppStartupValidation
{
	[TestFixture]
	public class AppSettingsValidatorTests
	{
		[Test]
		public void ConstructorRequiresListOfKeysToValidate()
		{
			var keysToValidate = new List<string>();

			new AppSettingsValidator(keysToValidate);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ConstructorThrowsArgumentNullExceptionWhenListOfKeysToValidateIsNull()
		{
			new AppSettingsValidator(null);
		}

		[Test]
		public void ValidationPassesWhenAllKeysArePresent()
		{
			new AppSettingsValidator(GetAllValidKeys());
		}

		[Test]
		[ExpectedException(typeof(ConfigurationErrorsException))]
		public void ValidationFailsWhenAnInValidKeyIsEncountered()
		{
			new AppSettingsValidator(GetKeysWithAtleastOneInValid()).Validate();
		}

		private IEnumerable<string> GetAllValidKeys()
		{
			return new[] { "CacheTimeout", "IsValid" };
		}

		private IEnumerable<string> GetKeysWithAtleastOneInValid()
		{
			return new[] { "CacheTimeout", "InValidSetting" };
		}
	}
}