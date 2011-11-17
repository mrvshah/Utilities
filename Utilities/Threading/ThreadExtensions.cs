using System;
using System.Threading;

namespace Utilities.Threading
{
	/// <summary>
	/// Extension methods around <see cref="Thread"/>
	/// </summary>
	public static class ThreadExtensions
	{
		/// <summary>
		/// <see cref="InvalidOperationException"/> is thrown if an attempt is made to rename thread. This extension method tries to set the name of the thread and returns a success or failure.
		/// </summary>
		/// <param name="thread">The thread</param>
		/// <param name="name">The name of the thread</param>
		/// <returns><see cref="Boolean"/> indicating is naming thread was successful</returns>
		public static bool TrySetName(this Thread thread, string name)
		{
			if (string.IsNullOrEmpty(thread.Name))
			{
				thread.Name = name;
				return true;
			}

			return false;
		}
	}
}