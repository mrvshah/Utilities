using System.Web;

namespace Utilities.WebHttpRequest
{
	/// <summary>
	/// Extensions for type <see cref="HttpRequest"/> 
	/// </summary>
	public static class HttpRequestExtensions
	{
		/// <summary>
		/// Checks http request header to see if browser supports compression
		/// </summary>
		/// <param name="request">Browser http request</param>
		/// <returns>Boolean indicating if browser supports compression</returns>
		public static bool CanGZip(this HttpRequest request)
		{
			return CanGZip(request.Headers["Accept-Encoding"]);
		}

		/// <summary>
		/// Checks http request header to see if browser supports compression
		/// </summary>
		/// <param name="acceptEncoding">Accept-Encoding request header value</param>
		/// <returns>Boolean indicating if browser supports compression</returns>
		internal static bool CanGZip(string acceptEncoding)
		{
			if (!string.IsNullOrEmpty(acceptEncoding) && (acceptEncoding.Contains("gzip") || acceptEncoding.Contains("deflate")))
			{
				return true;
			}

			return false;
		}
	}
}