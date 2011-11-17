using NUnit.Framework;
using Utilities.Threading;

namespace Tests.Threading
{
	[TestFixture]
	public class ThreadExtensionsTests
	{
		[Test]
		public void TrySetThreadNameDoesNotThrowInvalidOperationExceptionOnRenamingThread()
		{
			var threadName = "Main";

			var success = System.Threading.Thread.CurrentThread.TrySetName(threadName);
			Assert.That(System.Threading.Thread.CurrentThread.Name, Is.EqualTo(threadName));
			Assert.That(success, Is.True);

			success = System.Threading.Thread.CurrentThread.TrySetName("Worker");

			Assert.That(System.Threading.Thread.CurrentThread.Name, Is.EqualTo(threadName));
			Assert.That(success, Is.False);
		}
	}
}