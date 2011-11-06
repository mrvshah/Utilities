using System;
using NUnit.Framework;
using Rhino.Mocks;
using Utilities.AppStartupValidation;

namespace Tests.AppStartupValidation
{
	[TestFixture]
	public class AppStartupValidationExecutorTests
	{
		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void WhenValidatorIsNotProvidedArgumentNullExceptionIsThrown()
		{
			AppStartupValidationExecutor.ValidateAll(null);
		}

		[Test]
		public void ValidateAllCallsValidateMethodOnAllValidators()
		{
			var appSettingsValidator = MockRepository.GenerateMock<IValidator>();
			var databaseConnectionValidator = MockRepository.GenerateMock<IValidator>();

			AppStartupValidationExecutor.ValidateAll(new[] { appSettingsValidator, databaseConnectionValidator });

			appSettingsValidator.AssertWasCalled(asv => asv.Validate());
			databaseConnectionValidator.AssertWasCalled(dcv => dcv.Validate());
		}
	}
}