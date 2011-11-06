using NUnit.Framework;
using Utilities.Exceptions;

namespace Tests.Exceptions
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