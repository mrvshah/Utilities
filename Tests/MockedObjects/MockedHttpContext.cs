using System.IO;
using System.Web;

namespace Tests.MockedObjects
{
	public static class MockedHttpContext
	{
		public static HttpContext GetHttpContext()
		{
			return new HttpContext(MockedHttpRequest.GetHttpRequest(), new HttpResponse(new StringWriter()));
		}
	}
}