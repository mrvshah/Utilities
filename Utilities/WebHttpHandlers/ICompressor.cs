namespace Utilities.WebHttpHandlers
{
	/// <summary>
	/// Contract for script compression
	/// </summary>
	public interface ICompressor
	{
		/// <summary>
		/// Compresses the specified text
		/// </summary>
		/// <param name="dataToCompress">The data to compress</param>
		/// <returns>Compressed text</returns>
		string Compress(string dataToCompress);
	}
}