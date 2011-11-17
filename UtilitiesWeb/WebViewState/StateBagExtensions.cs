using System.Web.UI;

namespace Utilities.WebViewState
{
	/// <summary>
	/// Wrapper for writing and reading from <see cref="StateBag"/>
	/// </summary>
	public static class StateBagExtensions
	{
		/// <summary>
		/// Sets the value in <see cref="StateBag"/>
		/// </summary>
		/// <param name="stateBag">The state bag</param>
		/// <param name="key">The key</param>
		/// <param name="value">The value</param>
		public static void SetValue(this StateBag stateBag, string key, object value)
		{
			stateBag.Add(key, value);
		}

		/// <summary>
		/// Gets the value from <see cref="StateBag"/>
		/// </summary>
		/// <typeparam name="T">Type of return object</typeparam>
		/// <param name="stateBag">The state bag</param>
		/// <param name="key">The key</param>
		/// <returns>Instance of type T</returns>
		public static T GetValue<T>(this StateBag stateBag, string key)
		{
			var value = stateBag[key];

			return value == null ? default(T) : (T)value;
		}
	}
}