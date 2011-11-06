using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Utilities.Arguments;

namespace Utilities.AppStartupValidation
{
	///<summary>
	/// Validates by checking if application settings exist in config file
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
		/// <exception cref="ArgumentNullException"/>
		public AppSettingsValidator(IEnumerable<string> keysToValidate)
		{
			keysToValidate.ThrowIfNull();

			this.keysToValidate = keysToValidate;
		}

		/// <summary>
		/// Loops through each required setting and checks if it exists in config file
		/// </summary>
		/// <exception cref="ConfigurationErrorsException"/>
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