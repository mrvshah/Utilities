using System;
using System.Diagnostics;

namespace Utilities.Stopwatch
{
	/// <summary>
	/// Traces execution time in milliseconds
	/// </summary>
	public class ExecutionTimeTracer : IDisposable
	{
		/// <summary>
		/// An instance of <see cref="Stopwatch"/> class
		/// </summary>
		private readonly System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

		/// <summary>
		/// Initializes a new instance of the <see cref="ExecutionTimeTracer"/> class
		/// </summary>
		/// <param name="messageToTrace">Message to trace</param>
		public ExecutionTimeTracer(string messageToTrace = null)
		{
			if (string.IsNullOrEmpty(messageToTrace))
			{
				messageToTrace = "{0}";
			}

			MessageToTrace = messageToTrace;
			sw.Start();
		}

		/// <summary>
		/// Gets or sets an action to invoke in dispose call
		/// </summary>
		public string MessageToTrace { get; set; }

		/// <summary>
		/// Dispose method
		/// </summary>
		public void Dispose()
		{
			sw.Stop();

			var elapsedTimeInMilliseconds = string.Format("{0} ms", sw.ElapsedMilliseconds);
			Trace.WriteLine(string.Format(MessageToTrace, elapsedTimeInMilliseconds));

			sw.Reset();
		}
	}
}