using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Utilities.AppStartupValidation;

namespace Utilities.Mef
{
	/// <summary>
	/// Wrapper to look up through root and subdirectories for type to import
	/// </summary>
	/// <typeparam name="T">Type to import</typeparam>
	public class ImportManyFromDirectory<T> : ImportManyFromBase<T>
	{
		/// <summary>
		/// Loops through directory and each subdirectories to search for type to be imported
		/// </summary>
		/// <returns>List of <see cref="T"/></returns>
		/// <exception cref="DirectoryNotFoundException"/>
		public IEnumerable<T> Get(string lookupDirectoryPath)
		{
			Trace.WriteLine(string.Format("Looking into directory {0} and it's subdirectories for parts", lookupDirectoryPath));

			var directoryValidator = new DirectoryValidator(new[] { lookupDirectoryPath });
			AppStartupValidationExecutor.ValidateAll(new[] { directoryValidator });

			var directoryCatalogues = new List<DirectoryCatalog>();
			directoryCatalogues.Add(new DirectoryCatalog(lookupDirectoryPath));
			directoryCatalogues.AddRange(Directory.GetDirectories(lookupDirectoryPath, "*.*", SearchOption.AllDirectories).Select(directory => new DirectoryCatalog(directory)));

			AggregateAndCompose(directoryCatalogues);

			return InstancesOfImportedType;
		}
	}
}