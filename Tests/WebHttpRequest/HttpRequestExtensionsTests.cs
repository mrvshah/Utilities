using NUnit.Framework;
using Tests.MockedObjects;
using Utilities.WebHttpRequest;

namespace Tests.WebHttpRequest
{
	[TestFixture]
	public class HttpRequestExtensionsTests
	{
		[Test]
		public void CanGZipReturnsFalseWhenEncodingIsNotSupported()
		{
			var httpRequest = MockedHttpRequest.GetHttpRequest();
			Assert.That(httpRequest.CanGZip(), Is.False);
		}

		[TestCase("gzip")]
		[TestCase("deflate")]
		public void CanGZipReturnsTrueWhenEncodingIsEitherGZipOrDeflate(string acceptedEncoding)
		{
			Assert.That(HttpRequestExtensions.CanGZip(acceptedEncoding), Is.True);
		}
	}
}