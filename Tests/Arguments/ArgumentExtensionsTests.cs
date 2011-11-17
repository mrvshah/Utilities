using System;
using NUnit.Framework;
using Utilities.Arguments;

namespace Tests.Arguments
{
	[TestFixture]
	public class ArgumentExtensionsTests
	{
		[Test]
		[ExpectedException(typeof(ArgumentNullException), ExpectedMessage = "Value cannot be null.\r\nParameter name: s")]
		public void CanThrowAnExceptionWhenArgumentIsNull()
		{
			string s = null;

			s.ThrowIfNull("s");
		}
	}

	class Customer
	{

	}
}