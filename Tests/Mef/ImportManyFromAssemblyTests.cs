using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Tests.Core.Mef.Services;
using Tests.Mef.Services;
using Utilities.Mef;

namespace Tests.Mef
{
	[TestFixture]
	public class ImportManyFromAssemblyTests
	{
		[Test]
		public void CanRetrieveAllServiceOfTypeIServiceFromCurrentAssembly()
		{
			var sut = new ImportManyFromAssembly<IService>();

			var services = sut.Get(Assembly.Load("Tests.Mef.EmailService"), Assembly.Load("Tests.Mef.FileWatcherService"));

			Assert.That(services.Count(), Is.EqualTo(2));
			Assert.That(services.OfType<EmailService.EmailService>().FirstOrDefault(), Is.Not.Null);
			Assert.That(services.OfType<FileWatcherService.FileWatcherService>().FirstOrDefault(), Is.Not.Null);
		}

		[Test]
		public void ServicesIsEmptyWhenServiceToImportIsNotExported()
		{
			var sut = new ImportManyFromAssembly<IServiceThatIsNotExported>();

			var services = sut.Get(Assembly.GetExecutingAssembly());

			Assert.That(services.Count(), Is.EqualTo(0));
		}
	}
}