using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Utilities.AppStartupValidators;
using Utilities.Arguments;

namespace Utilities.AppStartupValidation
{
	///<summary>
	/// Application settings validator
	///</summary>
	public class AppSettingsValidator : IValidator
	{
		/// <summary>
		/// List of application setting keys to validate
		/// </summary>
		private readonly IEnumerable<string> keysToValidate;

		///<summary>
		/// Initializes a new instance of type <see cref="AppSettingsValidator"/>
		///</summary>
		///<param name="keysToValidate">List of application setting keys to validate</param>
		public AppSettingsValidator(IEnumerable<string> keysToValidate)
		{
			keysToValidate.ThrowIfNull();

			this.keysToValidate = keysToValidate;
		}

		/// <summary>
		/// Validate application settings
		/// </summary>
		public void Validate()
		{
			foreach (var key in keysToValidate)
			{
				if (!ConfigurationManager.AppSettings.AllKeys.Contains(key))
				{
					throw new ConfigurationErrorsException(string.Format("Key {0} is missing", key));
				}
			}
		}
	}
}