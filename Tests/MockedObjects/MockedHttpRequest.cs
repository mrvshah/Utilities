using System.Web;

namespace Tests.MockedObjects
{
	public static class MockedHttpRequest
	{
		public static HttpRequest GetHttpRequest()
		{
			return new HttpRequest("MockPage.aspx", "http://www.webrequest.com/", string.Empty);
		}
	}
}