using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;

namespace Utilities.Mef
{
	/// <summary>
	/// Wrapper to look up into assemblies for type to import
	/// </summary>
	/// <typeparam name="T">Type to import</typeparam>
	public class ImportManyFromAssembly<T> : ImportManyFromBase<T>
	{
		/// <summary>
		/// Gets the specified type from assemblies
		/// </summary>
		/// <param name="assemblies">The assemblies to look up into</param>
		/// <returns>List of <see cref="T"/></returns>
		public IEnumerable<T> Get(params Assembly[] assemblies)
		{
			var assemblyCatalogues = assemblies.Select(assembly => new AssemblyCatalog(assembly)).ToList();

			AggregateAndCompose(assemblyCatalogues);

			return InstancesOfImportedType;
		}
	}
}