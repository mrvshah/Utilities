// Type: System.Web.IHttpHandler
// Assembly: System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// Assembly location: C:\Program Files\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\System.Web.dll

namespace System.Web
{
	public interface IHttpHandler
	{
		bool IsReusable { get; }
		void ProcessRequest(HttpContext context);
	}
}
