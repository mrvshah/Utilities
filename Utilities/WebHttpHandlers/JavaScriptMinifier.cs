namespace Utilities.WebHttpHandlers
{
	///<summary>
	/// JavsScript http handler
	///</summary>
	public class JavaScriptMinifier : BaseHttpHandler
	{
		/// <summary>
		/// Gets the content type for javascript
		/// </summary>
		protected override string ContentType
		{
			get { return "application/x-javascript"; }
		}

		/// <summary>
		/// Gets the javascript content compressor
		/// </summary>
		protected override ICompressor Compressor
		{
			get { return new JavaScriptCompressor(); }
		}
	}
}