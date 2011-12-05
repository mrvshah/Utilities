using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;

namespace Utilities.Mef
{
	/// <summary>
	/// Base class for importing type from directory, assembly etc
	/// </summary>
	/// <typeparam name="T">Type to import</typeparam>
	public abstract class ImportManyFromBase<T>
	{
		[ImportMany]
		protected IEnumerable<T> InstancesOfImportedType { get; set; }

		/// <summary>
		/// Creates an <see cref="AggregateCatalog"/> and composes the parts
		/// </summary>
		/// <param name="catalogues">List of catalogues to find specified type</param>
		protected void AggregateAndCompose(IEnumerable<ComposablePartCatalog> catalogues)
		{
			var aggregateCatalog = new AggregateCatalog(catalogues);
			var container = new CompositionContainer(aggregateCatalog);
			var batch = new CompositionBatch();
			batch.AddPart(this);
			container.Compose(batch);
		}
	}
}