using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using NUnit.Framework;
using Utilities.AppStartupValidation;

namespace Tests.AppStartupValidation
{
	[TestFixture]
	public class DatabaseConnectionValidatorTests
	{
		[Test]
		public void ConstructorRequiresListOfConnectionStringsToValidate()
		{
			var connectionStringsToValidate = new List<string>();

			new DatabaseConnectionValidator(connectionStringsToValidate);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ConstructorThrowsArgumentNullExceptionWhenListOfConnectionStringNamesToValidateIsNull()
		{
			new DatabaseConnectionValidator(null);
		}

		[Test]
		[ExpectedException(typeof(ConfigurationErrorsException))]
		public void ValidationFailsWhenConnectionStringIsNotFound()
		{
			new DatabaseConnectionValidator(new[] { "NonExistentConnectionString" }).Validate();
		}

		[Test]
		[ExpectedException(typeof(SqlException))]
		public void ValidationFailsWhenAnInValidConnectionStringIsEncountered()
		{
			new DatabaseConnectionValidator(new[] { "ConnString" }).Validate();
		}
	}
}