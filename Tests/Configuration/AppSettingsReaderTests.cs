using NUnit.Framework;
using Utilities.Configuration;

namespace Tests.Configuration
{
	[TestFixture]
	public class AppSettingsReaderTests
	{
		private const string APP_CACHE_TIMEOUT = "CacheTimeout";
		private const string APP_IS_VALID = "IsValid";

		[Test]
		public void CanRetrieveIntSetting()
		{
			Assert.That(AppSettingsReader.Get<int>(APP_CACHE_TIMEOUT), Is.EqualTo(3600));
		}

		[Test]
		public void CanRetrieveBoolSetting()
		{
			Assert.That(AppSettingsReader.Get<bool>(APP_IS_VALID), Is.True);
		}
	}
}