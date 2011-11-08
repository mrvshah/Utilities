using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Messaging;
using Utilities.Arguments;
using Utilities.Configuration;
using Utilities.Exceptions;

namespace Utilities.AppStartupValidation
{
	///<summary>
	/// Validates by checking if the queue exists
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
		/// <exception cref="ArgumentNullException"/>
		public MsmqValidator(IEnumerable<string> appSettingQueueNamesToValidate)
		{
			appSettingQueueNamesToValidate.ThrowIfNull();

			this.appSettingQueueNamesToValidate = appSettingQueueNamesToValidate;
		}

		/// <summary>
		/// Loops through each queue and checks if queue exists
		/// </summary>
		/// <exception cref="ArgumentException"/>
		public void Validate()
		{
			Trace.WriteLine("Starting MsmqValidator validation");

			foreach (var queueName in appSettingQueueNamesToValidate)
			{
				var queue = AppSettingsReader.Get<string>(queueName);

				if (!MessageQueue.Exists(queue))
				{
					throw new MissingMessageQueueException(string.Format("Queue {0} does not exist", queue));
				}
			}

			Trace.WriteLine("MsmqValidator validation complete");
		}
	}
}