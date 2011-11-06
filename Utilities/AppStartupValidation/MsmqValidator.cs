using System;
using System.Collections.Generic;
using System.Messaging;
using Utilities.AppStartupValidators;
using Utilities.Arguments;
using Utilities.Configuration;

namespace Utilities.AppStartupValidation
{
	///<summary>
	/// Msmq validator
	///</summary>
	public class MsmqValidator : IValidator
	{
		/// <summary>
		/// List of queues to validate
		/// </summary>
		private readonly IEnumerable<string> appSettingQueueNamesToValidate;

		/// <summary>
		/// Initializes a new instance of the <see cref="MsmqValidator"/> class.
		/// </summary>
		/// <param name="appSettingQueueNamesToValidate">List of queues to validate</param>
		public MsmqValidator(IEnumerable<string> appSettingQueueNamesToValidate)
		{
			appSettingQueueNamesToValidate.ThrowIfNull();

			this.appSettingQueueNamesToValidate = appSettingQueueNamesToValidate;
		}

		/// <summary>
		/// Enables validation by custom validator
		/// </summary>
		public void Validate()
		{
			foreach (var queueName in appSettingQueueNamesToValidate)
			{
				var queue = AppSettingsReader.Get<string>(queueName);

				if (!MessageQueue.Exists(queue))
				{
					throw new ArgumentException(string.Format("Queue {0} does not exist", queue));
				}
			}
		}
	}
}