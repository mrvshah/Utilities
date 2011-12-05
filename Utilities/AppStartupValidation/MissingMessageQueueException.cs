using System;

namespace Utilities.AppStartupValidation
{
	/// <summary>
	/// Represents a missing message queue
	/// </summary>
	public class MissingMessageQueueException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MissingMessageQueueException"/> class
		/// </summary>
		/// <param name="message">The exception message</param>
		public MissingMessageQueueException(string message)
			: base(message)
		{

		}
	}
}