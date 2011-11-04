using System;
using NUnit.Framework;
using Utilities.Arguments;

namespace Tests.Arguments
{
	[TestFixture]
	public class ArgumentExtensionsTests
	{
		[Test]
		[ExpectedException(typeof(ArgumentNullException), ExpectedMessage = null)]
		public void CanThrowAnExceptionWhenArgumentIsNull()
		{
			string s = null;

			s.ThrowIfNull();
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CanThrowExceptionForEachNullArgument()
		{
			Customer customer = null;

			var parameters = new object[] { 1, customer };

			parameters.ThrowIfNull();
		}
	}

	class Customer
	{

	}
}