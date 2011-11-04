using System;
using System.Configuration;

namespace Utilities.Configuration
{
	///<summary>
	///</summary>
	public class AppSettingsReader
	{
		///<summary>
		/// Get app setting value
		///</summary>
		///<param name="key">App setting key</param>
		///<typeparam name="T">Requested type of value</typeparam>
		///<returns>App setting value</returns>
		public static T Get<T>(string key)
		{
			return (T)Convert.ChangeType(ConfigurationManager.AppSettings[key], typeof(T));
		}
	}
}