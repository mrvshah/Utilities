using System.Linq;
using NUnit.Framework;
using Tests.Core.Mef.Services;
using Utilities.Mef;

namespace Tests.Mef
{
	[TestFixture]
	public class ImportManyFromDirectoryTests
	{
		private ImportManyFromDirectory<IService> sut;

		[SetUp]
		public void SetUp()
		{
			sut = new ImportManyFromDirectory<IService>();
		}

		[Test, Ignore, Category(TestCategories.INTEGRATION)]
		public void CanRetrieveAllServicesOfTypeIServiceFromAFolder()
		{
			var services = sut.Get("");

			Assert.That(services.Count(), Is.EqualTo(2));
		}
	}
}