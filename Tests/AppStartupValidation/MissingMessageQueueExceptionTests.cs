using NUnit.Framework;
using Utilities.AppStartupValidation;

namespace Tests.AppStartupValidation
{
	[TestFixture]
	public class MissingMessageQueueExceptionTests
	{
		[Test]
		public void ConstructorRequiresExceptionMessage()
		{
			new MissingMessageQueueException(string.Empty);
		}
	}
}