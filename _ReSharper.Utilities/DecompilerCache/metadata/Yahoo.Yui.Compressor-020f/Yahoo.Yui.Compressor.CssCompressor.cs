// Type: Yahoo.Yui.Compressor.CssCompressor
// Assembly: Yahoo.Yui.Compressor, Version=1.6.0.2, Culture=neutral, PublicKeyToken=f8b4b81ec75097e2
// Assembly location: D:\MyData\git\Utilities\packages\YUICompressor.NET.1.6.0.2\lib\net35\Yahoo.Yui.Compressor.dll

namespace Yahoo.Yui.Compressor
{
	public static class CssCompressor
	{
		public static string Compress(string css);
		public static string Compress(string css, int columnWidth, CssCompressionType cssCompressionType, bool removeComments);
	}
}
