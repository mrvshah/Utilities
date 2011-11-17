using NUnit.Framework;
using Utilities.Enum;

namespace Tests.Enum
{
	[TestFixture]
	public class EnumExtensionsTests
	{
		[Test]
		public void CanGetDescriptionOfAnEnum()
		{
			Assert.That(CreditCardType.MasterCard.GetDescription(), Is.EqualTo("MasterCard credit card type."));
		}

		[Test]
		public void EmptyStringIsReturnedWhenDescriptionAttributeIsNotSetOfAnEnum()
		{
			Assert.That(CreditCardType.Unspecified.GetDescription(), Is.EqualTo(string.Empty));
		}
	}
}