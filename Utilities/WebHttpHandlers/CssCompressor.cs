namespace Utilities.WebHttpHandlers
{
	/// <summary>
	/// Wrapper around Yahoo CssCompressor
	/// </summary>
	public class CssCompressor : ICompressor
	{
		/// <summary>
		/// Compress css using Yahoo CssCompressor
		/// </summary>
		/// <param name="dataToCompress">Css to compress</param>
		/// <returns>Compressed css</returns>
		public string Compress(string dataToCompress)
		{
			return Yahoo.Yui.Compressor.CssCompressor.Compress(dataToCompress);
		}
	}
}