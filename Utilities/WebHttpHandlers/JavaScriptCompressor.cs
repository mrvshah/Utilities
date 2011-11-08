namespace Utilities.WebHttpHandlers
{
	/// <summary>
	/// Wrapper around Yahoo JavaScriptCompressor
	/// </summary>
	public class JavaScriptCompressor : ICompressor
	{
		/// <summary>
		/// Compress javascript using Yahoo JavaScriptCompressor
		/// </summary>
		/// <param name="dataToCompress">Script to compress</param>
		/// <returns>Compressed javascript</returns>
		public string Compress(string dataToCompress)
		{
			return Yahoo.Yui.Compressor.JavaScriptCompressor.Compress(dataToCompress);
		}
	}
}