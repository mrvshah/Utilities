using NUnit.Framework;
using Tests.MockedObjects;
using Utilities.WebCache;

namespace Tests.WebCache
{
	[TestFixture]
	public class CacheReaderTests
	{
		private const string CACHE_KEY = "CacheKey";

		[Test]
		public void CanReadFromCache()
		{
			var customer = new Customer { FirstName = "Viral", LastName = "Shah" };

			var context = MockedHttpContext.GetHttpContext();

			context.Cache.Insert(CACHE_KEY, customer);

			Assert.That(CacheReader.Read<Customer>(CACHE_KEY, MockedHttpContext.GetHttpContext()), Is.EqualTo(customer));
		}

		[Test]
		public void CanCheckIfCacheObjectExists()
		{
			var context = MockedHttpContext.GetHttpContext();

			Assert.That(CacheReader.Contains("NonExistentCacheKey", context), Is.False);
		}
	}

	class Customer
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}