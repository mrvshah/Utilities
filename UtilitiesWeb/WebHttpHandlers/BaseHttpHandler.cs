using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Web;
using System.Web.Caching;
using Utilities.Configuration;
using Utilities.WebCache;
using Utilities.WebHttpRequest;

namespace Utilities.WebHttpHandlers
{
	///<summary>
	/// Base handler containing common code for all handlers
	///</summary>
	/// <example>
	///     <code lang="config" title="Add the following in web.config file">
	///         <code 
	///             source="..\..\UtilitiesSnippets\WebHttpHandlers\SnippetWeb.config" 
	///         />
	///     </code>
	///     <code lang="html" title="Add version number when requesting css">
	///         <code 
	///             source="..\..\UtilitiesSnippets\WebHttpHandlers\SnippetCssRequest.html" 
	///         />
	///     </code>
	/// </example>
	public abstract class BaseHttpHandler : IHttpHandler
	{
		/// <summary>
		/// Response content type
		/// </summary>
		protected abstract string ContentType { get; }

		/// <summary>
		/// Content compressor
		/// </summary>
		protected abstract ICompressor Compressor { get; }

		public virtual bool IsReusable
		{
			get { return true; }
		}

		private bool EnableMinification
		{
			get { return AppSettingsReader.Get<bool>("EnableMinification"); }
		}

		/// <summary>
		/// Server and client side cache duration
		/// </summary>
		protected virtual TimeSpan CacheDuration
		{
			get
			{
				return new TimeSpan(AppSettingsReader.Get<int>("CacheDurationInDays"), 0, 0, 0);
			}
		}

		/// <summary>
		/// Process current request
		/// </summary>
		/// <param name="context">Current http request</param>
		public virtual void ProcessRequest(HttpContext context)
		{
			bool isCompressed = context.Request.CanGZip();

			var file = Path.GetFileName(context.Request.FilePath);
			var version = context.Request["v"] ?? string.Empty;
			var cacheKey = string.Format("{0}_{1}", file, version);

			if (!WriteFromCache(cacheKey, isCompressed, ContentType, context))
			{
				using (var memoryStream = new MemoryStream(8092))
				{
					using (var writer = isCompressed ? (Stream)(new GZipStream(memoryStream, CompressionMode.Compress)) : memoryStream)
					{
						var script = File.ReadAllText(context.Server.MapPath(context.Request.FilePath));

						byte[] bts;
						if (!EnableMinification)
						{
							bts = Encoding.UTF8.GetBytes(script);
						}
						else
						{
							var compressedScript = Compressor.Compress(script);

							bts = Encoding.UTF8.GetBytes(compressedScript);
						}

						writer.Write(bts, 0, bts.Length);
					}

					byte[] response = memoryStream.ToArray();
					context.Cache.Insert(cacheKey, response, null, DateTime.Now.Add(CacheDuration), Cache.NoSlidingExpiration);

					WriteBytes(response, isCompressed, ContentType, context);
				}
			}
		}

		/// <summary>
		/// Write compressed data in response and flush response to client
		/// </summary>
		/// <param name="bytes">Response data</param>
		/// <param name="isCompressed">Used to drive Content-Encoding response header setting</param>
		/// <param name="contentType">Response data content type. e.g. javascript, css</param>
		/// <param name="currentContext">Current http context</param>
		private void WriteBytes(byte[] bytes, bool isCompressed, string contentType, HttpContext currentContext)
		{
			HttpResponse response = currentContext.Response;

			response.AppendHeader("Content-Length", bytes.Length.ToString());
			response.ContentType = contentType;
			if (isCompressed)
			{
				response.AppendHeader("Content-Encoding", "gzip");
			}
			else
			{
				response.AppendHeader("Content-Encoding", "utf-8");
			}

			currentContext.Response.Cache.SetCacheability(HttpCacheability.Public);
			currentContext.Response.Cache.SetExpires(DateTime.Now.Add(CacheDuration));
			currentContext.Response.Cache.SetMaxAge(CacheDuration);

			response.ContentEncoding = Encoding.Unicode;
			response.OutputStream.Write(bytes, 0, bytes.Length);
			response.Flush();
		}

		/// <summary>
		/// Check and send response from cache if it exists
		/// </summary>
		/// <param name="cacheKey">Cache key</param>
		/// <param name="isCompressed">Used to drive Content-Encoding response header setting</param>
		/// <param name="contentType">Response data conent type. e.g. javascript, css</param>
		/// <returns>Boolean indicating where response was from cache</returns>
		/// <param name="currentContext">Current http context</param>
		protected bool WriteFromCache(string cacheKey, bool isCompressed, string contentType, HttpContext currentContext)
		{
			if (!EnableMinification)
			{
				return false;
			}

			byte[] responseBytes = CacheReader.Contains(cacheKey) ? CacheReader.Read<byte[]>(cacheKey) : null;

			if (responseBytes == null || responseBytes.Length == 0)
			{
				return false;
			}

			WriteBytes(responseBytes, isCompressed, contentType, currentContext);
			return true;
		}
	}
}