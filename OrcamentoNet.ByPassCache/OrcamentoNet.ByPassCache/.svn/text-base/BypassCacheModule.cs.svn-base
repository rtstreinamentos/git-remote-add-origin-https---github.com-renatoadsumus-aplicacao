using System;
using System.Web;

namespace OrcamentoNet.ByPassCache
{
	public class BypassCacheModule : IHttpModule
	{
		#region IHttpModule Members

		void IHttpModule.Dispose() {
		}

		void IHttpModule.Init(HttpApplication context) {
			context.PostMapRequestHandler += (object sender, EventArgs e) => {
				if (!String.Equals(context.Context.Request.HttpMethod, "GET",
					   StringComparison.InvariantCultureIgnoreCase))
				{
					context.Context.Response.Cache.SetNoServerCaching();
				}
			};
		}

		#endregion
	}
}
