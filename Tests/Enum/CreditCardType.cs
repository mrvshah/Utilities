using System.ComponentModel;

namespace Tests.Enum
{
	public enum CreditCardType
	{
		[Description("Visa credit card type. Length 16.")]
		Visa,
		[Description("MasterCard credit card type.")]
		MasterCard,
		[Description("Amex credit card type.")]
		Amex,
		[Description("Diners credit card type.")]
		Diners,
		Unspecified
	}
}