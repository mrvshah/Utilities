using System;

namespace Utilities.Exceptions
{
	/// <summary>
	/// Represents a missing message queue
	/// </summary>
	public class MissingMessageQueueException : Exception
	{
		public MissingMessageQueueException(string message)
			: base(message)
		{

		}
	}
}