namespace Utilities.WebHttpHandlers
{
	///<summary>
	/// Css http handler
	///</summary>
	public class CssMinifier : BaseHttpHandler
	{
		/// <summary>
		/// Gets the content type for css
		/// </summary>
		protected override string ContentType
		{
			get { return "text/css"; }
		}

		/// <summary>
		/// Gets the css content compressor
		/// </summary>
		protected override ICompressor Compressor
		{
			get { return new CssCompressor(); }
		}
	}
}