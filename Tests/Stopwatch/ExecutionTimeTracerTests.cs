using System;
using System.Threading;
using NUnit.Framework;
using Utilities.Stopwatch;

namespace Tests.Stopwatch
{
	[TestFixture]
	public class ExecutionTimeTracerTests
	{
		[Test]
		public void CanMeasureExecutionTime()
		{
			using (new ExecutionTimeTracer())
			{
				MethodToExecute();
			}
		}

		private void MethodToExecute()
		{
			Thread.Sleep(new TimeSpan(0, 0, 0, 2)); // 2 seconds
		}
	}
}