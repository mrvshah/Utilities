using System.ServiceModel;
using NUnit.Framework;
using Utilities.Wcf;

namespace Tests.Wcf
{
	[TestFixture]
	public class WcfServiceRunnerTests
	{
		private WcfServiceRunner<Service> sut;

		[SetUp]
		public void SetUp()
		{
			sut = new WcfServiceRunner<Service>();
		}

		[Test]
		public void ImplementsIDisposable()
		{
			using (new WcfServiceRunner<Service>())
			{

			}
		}

		[Test]
		public void ConstructorCreatesServiceHost()
		{
			Assert.That(sut.Host, Is.Not.Null);
		}

		[Test]
		public void CanStartService()
		{
			sut.Start();

			Assert.That(sut.Host.State, Is.EqualTo(CommunicationState.Opened));
		}
	}

	public class Service
	{

	}
}