using System.Web;

namespace Utilities.WebHttpHandlers
{
	///<summary>
	/// Base handler for all handlers
	///</summary>
	public abstract class BaseHandler : IHttpHandler
	{
		public virtual bool IsReusable
		{
			get { return true; }
		}

		public abstract void ProcessRequest(HttpContext context);
	}
}