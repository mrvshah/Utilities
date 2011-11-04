using System;
using NUnit.Framework;
using Utilities.Enum;

namespace Tests.Enum
{
	[TestFixture]
	public class StringExtensionsTests
	{
		[Test]
		public void CanConvertStringToEnum()
		{
			Assert.That("Amex".ToEnumOfType<CreditCardType>(), Is.EqualTo(CreditCardType.Amex));
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void ExceptionIsThrownWhenStringCannotBeConvertedToEnum()
		{
			"NonExistentEnumItem".ToEnumOfType<CreditCardType>();
		}
	}
}