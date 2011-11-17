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

		[Test]
		public void CanConvertDescriptionToEnum()
		{
			var description = "MasterCard credit card type.";

			Assert.That(description.ToEnumOfType<CreditCardType>(true), Is.EqualTo(CreditCardType.MasterCard));
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void ArgumentExceptionIsThrownIfRequestedTypeIsNotEnum()
		{
			var description = "MasterCard credit card type.";

			description.ToEnumOfType<StringExtensionsTests>(true);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void ArgumentExceptionIsThrownIfEnumTypeIsNotFoundFromRequestedType()
		{
			var description = "Some credit card type.";

			description.ToEnumOfType<StringExtensionsTests>(true);
		}
	}
}