using System.Web;

namespace Utilities.WebCache
{
	/// <summary>
	/// Wrapper for reading cache data
	/// </summary>
	public static class CacheReader
	{
		/// <summary>
		/// Retrieves cache data based on key
		/// </summary>
		/// <typeparam name="T">Type of return object</typeparam>
		/// <param name="key">Cache key</param>
		/// <param name="httpContext">Current http context</param>
		/// <returns>Instance of type T</returns>
		public static T Read<T>(string key, HttpContext httpContext = null)
		{
			httpContext = httpContext ?? HttpContext.Current;

			return (T)(httpContext.Cache.Get(key));
		}

		/// <summary>
		/// Determines whether cache contains specified key
		/// </summary>
		/// <param name="key">Cache key</param>
		/// <param name="httpContext">Current http context</param>
		/// <returns>
		///   <c>true</c> if cache contains the specified key; otherwise, <c>false</c>.
		/// </returns>
		public static bool Contains(string key, HttpContext httpContext = null)
		{
			httpContext = httpContext ?? HttpContext.Current;

			return httpContext.Cache[key] == null ? false : true;
		}
	}
}