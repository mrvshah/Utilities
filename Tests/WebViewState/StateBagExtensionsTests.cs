using System.Web.UI;
using NUnit.Framework;
using Utilities.WebViewState;

namespace Tests.WebViewState
{
	[TestFixture]
	public class ViewStateExtensions
	{
		private const string CUSTOMER_ID_KEY = "CustomerId";
		private const int CUSTOMER_ID_VALUE = 1;

		private StateBag sut = new StateBag();

		[Test]
		public void CanWriteAndReadFromStateBag()
		{
			sut.SetValue(CUSTOMER_ID_KEY, CUSTOMER_ID_VALUE);

			Assert.That(sut.GetValue<int>(CUSTOMER_ID_KEY), Is.EqualTo(CUSTOMER_ID_VALUE));
		}
	}
}